using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IDeliveryService
    {
        Task<string> CreateDeliveryOrderAsync(string orderId);
        Task<string> CalculateDeliveryFeeAsync(string orderId);
        Task<ApiProvinceResponse> GetProvincesAsync();
        Task<ApiDistrictResponse> GetDistrictsAsync(int provinceId);
        Task<ApiWardResponse> GetWardsAsync(int districtId);
        Task<CancelDeleveryResponse> CancelOrderAsync(string ordercodes);
        Task<string> ViewDeliveryStatuslAsync(string orderCode);
    }

    public class DeliveryService : IDeliveryService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _token;
        private readonly string _shopId;
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<DeliveryService> _logger;

        public DeliveryService(IConfiguration config, IOrderRepository orderRepository, IAccountRepository accountRepository)
        {
            _config = config;
            _httpClient = new HttpClient();
            _baseUrl = _config["GhnConfig:BaseUrl"];
            _token = _config["GhnConfig:Token"];
            _shopId = _config["GhnConfig:ShopId"];
            _orderRepository = orderRepository;
            _accountRepository = accountRepository;
        }

        public async Task<string> CreateDeliveryOrderAsync(string orderId)
        {
            var senderConfig = _config.GetSection("GhnConfig:Sender").Get<SenderConfig>();
            var orderResult = await _orderRepository.GetProductsByOrderId(orderId);
            var ord = await _orderRepository.GetOrderById(orderId);
            var acc = await _accountRepository.GetAccount(ord.AccountId);
            var items = orderResult.Select(op => new ItemRequest
            {
                name = op.ProductName,
                code = op.ProductName, // Gán ProductName cho code luôn
                quantity = op.Quantity ?? 0,
                price = (int)Math.Ceiling(op.Price ?? 0),
                length = op.length,
                width = op.width,
                height = op.height,
                weight = op.weight
            }).ToList();

            var totalInsuranceValue = Math.Min(items.Sum(i => i.price), 5000000);
            var totalWeight = items.Sum(i => i.weight);
            var averageLength = items.Any() ? (int)Math.Ceiling(items.Average(i => i.length)) : 0;
            var totalWidth = items.Sum(i => i.width);
            var maxHeight = items.Any() ? items.Max(i => i.height) : 0;
            var fullOrder = new
            {
                payment_type_id = 1,
                note = "CCSS Product",
                required_note = "KHONGCHOXEMHANG",

                from_name = senderConfig.from_name,
                from_phone = senderConfig.from_phone,
                from_address = senderConfig.from_address,
                from_ward_name = senderConfig.from_ward_name,
                from_district_name = senderConfig.from_district_name,
                from_province_name = senderConfig.from_province_name,
                return_phone = senderConfig.return_phone,
                return_address = senderConfig.return_address,

                to_name = acc.Name,
                to_phone = ord.Phone,
                to_address = ord.Address,
                to_ward_code = ord.to_ward_code,
                to_district_id = ord.to_district_id,

                cod_amount = 0,
                content = "CCSS Product",
                weight = totalWeight,
                length = averageLength,
                width = totalWidth,
                height = maxHeight,

                //cod_failed_amount = order.cod_failed_amount,
                pick_station_id = 0,
                deliver_station_id = 0,
                insurance_value = totalInsuranceValue,
                service_id = 0,
                service_type_id = 2,
                coupon = (string)null,
                pick_shift = new List<int> { 2 },
                items = items
            };

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}shiip/public-api/v2/shipping-order/create");
            request.Headers.Add("Token", _token);
            request.Headers.Add("ShopId", _shopId);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(fullOrder);
            Console.WriteLine("aaaaaaaaaaaa"+json);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"GHN API Error: {result}");
            }
            var responseObject = JObject.Parse(result);  // Parse JSON string thành JObject
            var orderCode = responseObject["data"]["order_code"].ToString();  // Lấy order_code

            ord.ShipCode = orderCode;
            var status = await ViewDeliveryStatuslAsync(orderId);
            ord.ShipCode = orderCode;
            ord.ShipStatus = ShipStatus.WaitConfirm ;
            await _orderRepository.UpdateOrder(ord);
            return result;
        }
        public async Task<string> CalculateDeliveryFeeAsync(string orderId)
        {
            var senderConfig = _config.GetSection("GhnConfig:Sender").Get<SenderConfig>();
            var orderResult = await _orderRepository.GetProductsByOrderId(orderId);
            var ord = await _orderRepository.GetOrderById(orderId);

            var items = orderResult.Select(op => new
            {
                name = op.ProductName,
                quantity = op.Quantity ?? 0,
                height = op.height,
                weight = op.weight,
                length = op.length,
                width = op.width
            }).ToList();

            var totalWeight = items.Sum(i => i.weight);
            var averageLength = items.Any() ? (int)Math.Ceiling(items.Average(i => i.length)) : 0;
            var totalWidth = items.Sum(i => i.width);
            var maxHeight = items.Any() ? items.Max(i => i.height) : 0;
            var insuranceValue = Math.Min(orderResult.Sum(op => (int)Math.Ceiling(op.Price ?? 0)), 5000000);

            var feeRequest = new
            {
                from_district_id = senderConfig.from_district_id,   
                from_ward_code = senderConfig.from_ward_code,
                service_id = 0, 
                service_type_id = 2,
                to_district_id = ord.to_district_id,
                to_ward_code = ord.to_ward_code,
                height = maxHeight,
                length = averageLength,
                weight = totalWeight,
                width = totalWidth,
                insurance_value = insuranceValue,
                cod_failed_amount = 0,
                coupon = (string)null,
                items = items
            };

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}shiip/public-api/v2/shipping-order/fee");
            request.Headers.Add("Token", _token);
            request.Headers.Add("ShopId", _shopId);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(feeRequest);
            Console.WriteLine("Fee Request: " + json);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"GHN Fee API Error: {result}");
            }
            var jsonResult = JObject.Parse(result);
            var serviceFee = jsonResult["data"]?["service_fee"]?.Value<int>() ?? 0;
            return serviceFee.ToString(); 
        }
        public async Task<string> ViewDeliveryStatuslAsync(string orderId)
        {
            var url = $"{_baseUrl}shiip/public-api/v2/shipping-order/detail";

            // Thêm các header cần thiết vào yêu cầu
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Token", _token);  // Thay _token bằng token thực tế của bạn
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var ord = await _orderRepository.GetOrderById(orderId);

            // Tạo nội dung JSON cho body request
            var requestBody = new
            {
                order_code = ord.ShipCode
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            // Gửi yêu cầu POST đến API và nhận phản hồi
            var response = await _httpClient.PostAsync(url, content);

            // Kiểm tra phản hồi
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                // Deserialize kết quả từ API
                var jsonResponse = JObject.Parse(result);
                var status = jsonResponse["data"]?["status"]?.ToString();

                return status;
            }
            else
            {
                throw new Exception("Failed to fetch delivery detail");
            }
        }



        public async Task<ApiProvinceResponse> GetProvincesAsync()
        {
            var url = $"{_baseUrl}shiip/public-api/master-data/province";

            // Thêm các header cần thiết vào yêu cầu
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Token", _token);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Gửi yêu cầu GET đến API và nhận phản hồi
            var response = await _httpClient.GetAsync(url);

            // Kiểm tra phản hồi
            if (response.IsSuccessStatusCode)
            {
                // Đọc nội dung phản hồi thành chuỗi
                var result = await response.Content.ReadAsStringAsync();

                // Deserialize JSON thành đối tượng ApiResponse
                var apiResponse = JsonConvert.DeserializeObject<ApiProvinceResponse>(result);

                // Trả về danh sách các tỉnh (ProvinceResponse)
                return apiResponse;
            }
            else
            {
                // Xử lý lỗi nếu phản hồi không thành công
                throw new Exception("Failed to fetch provinces data");
            }
        }



        public async Task<ApiDistrictResponse> GetDistrictsAsync(int provinceId)
        {
            var url = $"{_baseUrl}shiip/public-api/master-data/district";

            // Thêm các header cần thiết vào yêu cầu
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Token", _token);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Tạo nội dung JSON cho body request
            var requestBody = new
            {
                province_id = provinceId
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            // Gửi yêu cầu POST đến API và nhận phản hồi
            var response = await _httpClient.PostAsync(url, content);

            // Kiểm tra phản hồi
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiDistrictResponse>(result);

                

                return apiResponse;
            }
            else
            {
                throw new Exception("Failed to fetch districts data");
            }
        }

        public async Task<ApiWardResponse> GetWardsAsync(int districtId)
        {
            var url = $"{_baseUrl}shiip/public-api/master-data/ward";

            // Thêm các header cần thiết vào yêu cầu
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Token", _token);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Tạo nội dung JSON cho body request
            var requestBody = new
            {
                district_id = districtId
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            // Gửi yêu cầu POST đến API và nhận phản hồi
            var response = await _httpClient.PostAsync(url, content);

            // Kiểm tra phản hồi
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiWardResponse>(result);

                
                return apiResponse;
            }
            else
            {
                throw new Exception("Failed to fetch districts data");
            }
        } 
        
        public async Task<CancelDeleveryResponse> CancelOrderAsync(string ordercodes)
        {
            var url = $"{_baseUrl}shiip/public-api/v2/switch-status/cancel";

            // Thêm các header cần thiết vào yêu cầu
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("ShopId", _shopId);
            _httpClient.DefaultRequestHeaders.Add("Token", _token);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Tạo nội dung JSON cho body request
            var requestBody = new
            {
                order_codes = new string[] { ordercodes }
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            // Gửi yêu cầu POST đến API và nhận phản hồi
            var response = await _httpClient.PostAsync(url, content);

            // Kiểm tra phản hồi
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<CancelDeleveryResponse>(result);

                
                return apiResponse;
            }
            else
            {
                throw new Exception("Failed to fetch districts data");
            }
        }
        
    }
}
