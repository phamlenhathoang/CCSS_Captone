using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace CCSS_Service.Libraries
{
    public interface IPdfService
    {
        Task<IFormFile> ConvertBytesToIFormFile(Request request, int deposit);
    }
    public class Pdf : IPdfService
    {
        private readonly ICharacterRepository characterRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IRequestRepository requestRepository;
        private readonly IAccountCouponRepository accountCouponRepository;
        private readonly IPackageRepository packageRepository;

        public Pdf(IPackageRepository packageRepository, ICharacterRepository characterRepository, IAccountRepository accountRepository, IRequestRepository requestRepository, IAccountCouponRepository accountCouponRepository)
        {
            this.characterRepository = characterRepository;
            this.accountRepository = accountRepository;
            this.requestRepository = requestRepository;
            this.accountCouponRepository = accountCouponRepository;
            this.packageRepository = packageRepository;
        }
        public async Task<byte[]> GeneratePdf(Request request, int deposit)
        {
            try
            {
                if (request == null)
                {
                    throw new Exception("Request does not exist");
                }

                AccountCoupon accountCoupon = null;

                if (request.AccountCouponId != null)
                {
                    accountCoupon = await accountCouponRepository.GetAccountCoupon(request.AccountCouponId);
                    if (accountCoupon == null)
                    {
                        throw new Exception("AccountCoupon does not exist");
                    }
                }

                Package package = null;

                if (request.PackageId != null)
                {
                    package = await packageRepository.GetPackage(request.PackageId);

                    if (package == null)
                    {
                        throw new Exception("Package does not exist");
                    }
                }

                using (var document = new PdfDocument())
                {
                    string htmlContent = "<style> h1, h2, h3 { text-align: center; } </style>";
                    htmlContent += "<h2>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</h2>";
                    htmlContent += "<h3><u>Độc lập - Tự do - Hạnh phúc</u></h3>";
                    DateTime now = DateTime.Now;
                    string formattedDate = now.ToString("dd 'tháng' MM 'năm' yyyy");
                    htmlContent += $"<p style='text-align: right; margin-right: 10px;'>TPHCM, ngày {formattedDate}</p>";
                    htmlContent += $"<h1>{request.Service.ServiceName.ToUpper()}</h1>";
                    htmlContent += "<p><b>BÊN A:</b> BÊN CHO THUÊ</p>";
                    htmlContent += "<p>Tên cơ quan: Hệ thống cho thuê Cosplayer và tổ chức sự kiện</p>";
                    htmlContent += "<p>Địa chỉ: TPHCM</p>";
                    htmlContent += "<p>Ông (Bà): Trương Tuấn Anh</p>";
                    htmlContent += "<p>Chức vụ: Giám đốc</p>";
                    htmlContent += "<p><b>BÊN B:</b> BÊN THUÊ</p>";
                    htmlContent += $"<p>Họ và tên: {request.Account.Name.ToUpper()}</p>";
                    htmlContent += $"<p>Địa chỉ: {request.Location}</p>";
                    htmlContent += $"<p>Số điện thoại: {request.Account.Phone}</p>";
                    string formattedStartDate = now.ToString("hh:mm tt dd 'tháng' MM 'năm' yyyy");
                    string formattedEndDate = now.ToString("hh:mm tt dd 'tháng' MM 'năm' yyyy");
                    htmlContent += $"<p><i>Xét yêu cầu của bên B. Hai bên thỏa thuận ký hợp đồng {request.Service.ServiceName.ToLower()}, sự kiện sẽ bắt đầu vào {formattedEndDate} và kết thúc vào {formattedEndDate}. Hợp đồng thuê sẽ bao gồm các nội dung quan trọng sau:</i></p>";

                    // Thêm CSS để làm đẹp bảng

                    if (request.Service.ServiceId.Equals("S001"))
                    {
                        int index = 1;
                        htmlContent += @"<style>
            table {
                width: 100%;
                border-collapse: collapse;
                font-family: Arial, sans-serif;
            }
            th, td {
                border: 1px solid black;
                padding: 8px;
                text-align: center;
            }
            th {
                background-color: #f2f2f2;
                font-weight: bold;
            }
            td {
                font-size: 14px;
            }
            tr:nth-child(even) {
                background-color: #f9f9f9;
            }
            tr:hover {
                background-color: #e6f7ff;
            }
            .right-align {
                text-align: right;
                font-weight: bold;
            }
        </style>";

                        // Bắt đầu bảng
                        htmlContent += @"<table>
            <tr>
                <th>STT</th>
                <th>Tên trang phục, cosplayer</th>
                <th>Đơn vị tính</th>
                <th>Số lượng</th>
                <th>Đơn giá</th>
                <th>Thành tiền</th>
            </tr>";
                        foreach (RequestCharacter requestCharacter in request.RequestCharacters)
                        {
                            Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);

                            htmlContent += $@"<tr>
                        <td>{index}</td>
                        <td>{character.CharacterName}</td>
                        <td>Bộ</td>
                        <td>{requestCharacter.Quantity}</td>
                        <td>{character.Price}</td>
                        <td>{(double)requestCharacter.Quantity * character.Price * 5}</td>
                    </tr>";
                            index++;
                        }

                        // Xử lý coupon
                        double amount = accountCoupon?.Coupon?.Amount ?? 0.0;
                        string formattedAmount = amount.ToString("0.##");

                        htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Coupon</td>
                    <td>{formattedAmount}</td>
                </tr>";

                        // Tính tổng số tiền
                        double totalAmount = await CalculateTotalAmount(request, formattedAmount, 0);

                        htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Tổng</td>
                    <td>{totalAmount}</td>
                </tr>";

                        htmlContent += "</table>";
                    }
                    else
                    {
                        int index = 1;
                        htmlContent += @"<style>
            table {
                width: 100%;
                border-collapse: collapse;
                font-family: Arial, sans-serif;
            }
            th, td {
                border: 1px solid black;
                padding: 8px;
                text-align: center;
            }
            th {
                background-color: #f2f2f2;
                font-weight: bold;
            }
            td {
                font-size: 14px;
            }
            tr:nth-child(even) {
                background-color: #f9f9f9;
            }
            tr:hover {
                background-color: #e6f7ff;
            }
            .right-align {
                text-align: right;
                font-weight: bold;
            }
        </style>";

                        // Bắt đầu bảng
                        htmlContent += @"<table>
            <tr>
                <th>STT</th>
                <th>Tên trang phục, cosplayer</th>
                <th>Đơn vị tính</th>
                <th>Số lượng</th>
                <th>Đơn giá</th>
                <th>Thành tiền</th>
            </tr>";
                        foreach (RequestCharacter requestCharacter in request.RequestCharacters)
                        {
                            Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);

                            htmlContent += $@"<tr>
                        <td>{index}</td>
                        <td>{character.CharacterName}</td>
                        <td>Bộ</td>
                        <td>{requestCharacter.Quantity}</td>
                        <td>{character.Price}</td>
                        <td>{(double)requestCharacter.Quantity * character.Price}</td>
                    </tr>";
                            index++;

                            if (requestCharacter.CosplayerId != null)
                            {
                                Account account = await accountRepository.GetAccount(requestCharacter.CosplayerId);
                                htmlContent += $@"<tr>
                            <td>{index}</td>
                            <td>{account.Name}</td>
                            <td>Cosplayer</td>
                            <td>-</td>
                            <td>{character.Price * account.SalaryIndex - character.Price}</td>
                            <td>{character.Price * account.SalaryIndex - character.Price}</td>
                        </tr>";
                                index++;
                            }
                        }

                        double packagePrice = (package?.Price ?? 0);

                        htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Package</td>
                    <td>{packagePrice}</td>
                </tr>";

                        // Xử lý coupon
                        double amount = accountCoupon?.Coupon?.Amount ?? 0.0;
                        string formattedAmount = amount.ToString("0.##");

                        htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Coupon</td>
                    <td>{formattedAmount}</td>
                </tr>";

                        // Tính tổng số tiền
                        double totalAmount = await CalculateTotalAmount(request, formattedAmount, packagePrice);

                        htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Tổng</td>
                    <td>{totalAmount}</td>
                </tr>";

                        htmlContent += "</table>";
                    }

                    // Thông tin hợp đồng
                    htmlContent += "<h3><strong>Điều khoản thuê Character.</strong></h3>";
                    htmlContent += "<p>Bên thuê có quyền sử dụng trang phục, đạo cụ theo danh sách thỏa thuận trong hợp đồng.</p>";
                    htmlContent += "<p>Không được sử dụng trang phục, đạo cụ vào mục đích trái pháp luật hoặc gây ảnh hưởng tiêu cực đến hình ảnh thương hiệu.</p>";
                    htmlContent += "<p>Bên thuê có trách nhiệm giữ gìn trang phục, đạo cụ trong tình trạng tốt.</p>";
                    htmlContent += "<p>Không được cắt, xé, làm bẩn hoặc sửa đổi kết cấu trang phục nếu không có sự đồng ý của bên cho thuê.</p>";
                    htmlContent += "<p>Nếu trang phục, đạo cụ bị hư hỏng, mất mát, bên thuê phải bồi thường theo mức giá quy định trong hợp đồng.</p>";
                    htmlContent += "<p>Trong trường hợp hư hỏng nhỏ, bên thuê phải chịu chi phí sửa chữa.</p>";
                    htmlContent += "<p>Khách hàng phải đặt cọc trước một khoản tiền tương ứng với chi phí thiết kế của trang phục trước khi nhận hàng.</p>";
                    htmlContent += "<p>Tiền thuê trang phục được tính theo số ngày thuê và được trừ vào tiền cọc khi khách hàng hoàn trả trang phục.</p>";
                    htmlContent += "<p>Khi khách hàng hoàn trả trang phục, bên cho thuê sẽ kiểm tra tình trạng sản phẩm. Nếu trang phục không có hư hại, tiền cọc sẽ được hoàn lại sau khi trừ đi tiền thuê. Nếu trang phục bị hư hại, chi phí sửa chữa sẽ được trừ vào tiền cọc.</p>";
                    htmlContent += "<p>Nếu tổng số tiền thuê và chi phí sửa chữa vượt quá số tiền cọc, khách hàng có trách nhiệm thanh toán phần chênh lệch trước khi hoàn tất hợp đồng thuê.</p>";

                    htmlContent += "<h3><strong>Điều khoản thuê Cosplayer</strong></h3>";
                    htmlContent += "<p>Cosplayer sẽ hóa thân vào nhân vật theo yêu cầu của bên thuê.</p>";
                    htmlContent += "<p>Cosplayer sẽ tham gia sự kiện, trình diễn, giao lưu hoặc chụp ảnh theo lịch trình đã thỏa thuận.</p>";
                    htmlContent += "<p>Cosplayer có quyền từ chối thực hiện các yêu cầu vi phạm đạo đức, pháp luật hoặc ảnh hưởng đến hình ảnh cá nhân.</p>";
                    htmlContent += "<p>Cosplayer phải tuân thủ trang phục, phong cách biểu diễn đúng theo yêu cầu đã cam kết.</p>";
                    htmlContent += "<p>Các chi phí phát sinh như đi lại, ăn uống, lưu trú (nếu có) sẽ do bên thuê chi trả.</p>";
                    htmlContent += "<h3><strong>Điều khoản ký hợp đồng</strong></h3>";
                    htmlContent += "<p>Thanh toán theo mức giá đã thỏa thuận trong hợp đồng.</p>";
                    htmlContent += $"<p>Thanh toán trước tổng chi phí khi thỏa thuận. Thanh toán phần còn lại khi sự kiện kết thúc</p>";

                    PdfGenerator.AddPdfPages(document, htmlContent, PageSize.A4);

                    using (var ms = new MemoryStream())
                    {
                        document.Save(ms);
                        return ms.ToArray(); // Trả về PDF dưới dạng byte[]
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IFormFile> ConvertBytesToIFormFile(Request request, int deposit)
        {
            byte[] fileBytes = await GeneratePdf(request, deposit);
            var stream = new MemoryStream(fileBytes);
            return new FormFile(stream, 0, fileBytes.Length, "file", request.RequestId)
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/pdf"
            };
        }



        public async Task<double> CalculateTotalAmount(Request request, string amount, double price)
        {
            double totalAmount = 0;

            foreach (RequestCharacter requestCharacter in request.RequestCharacters)
            {
                Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);

                totalAmount = (double)requestCharacter.Quantity * (double)character.Price;

                if (requestCharacter.CosplayerId != null)
                {
                    Account account = await accountRepository.GetAccount(requestCharacter.CosplayerId);
                    totalAmount += (double)character.Price * (double)account.SalaryIndex - (double)character.Price;
                }
            }
            double parsedAmount;
            if (double.TryParse(amount, out parsedAmount))
            {
                return totalAmount - parsedAmount + price;
            }
            return totalAmount;
        }

        private async void HtmlContractCosplayerAndCharacter(Request request, AccountCoupon accountCoupon, Package package)
        {
            int index = 1;
            string htmlContent = null;
            htmlContent += @"<style>
            table {
                width: 100%;
                border-collapse: collapse;
                font-family: Arial, sans-serif;
            }
            th, td {
                border: 1px solid black;
                padding: 8px;
                text-align: center;
            }
            th {
                background-color: #f2f2f2;
                font-weight: bold;
            }
            td {
                font-size: 14px;
            }
            tr:nth-child(even) {
                background-color: #f9f9f9;
            }
            tr:hover {
                background-color: #e6f7ff;
            }
            .right-align {
                text-align: right;
                font-weight: bold;
            }
        </style>";

            // Bắt đầu bảng
            htmlContent += @"<table>
            <tr>
                <th>STT</th>
                <th>Tên trang phục, cosplayer</th>
                <th>Đơn vị tính</th>
                <th>Số lượng</th>
                <th>Đơn giá</th>
                <th>Thành tiền</th>
            </tr>";
            foreach (RequestCharacter requestCharacter in request.RequestCharacters)
            {
                Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);

                htmlContent += $@"<tr>
                        <td>{index}</td>
                        <td>{character.CharacterName}</td>
                        <td>Bộ</td>
                        <td>{requestCharacter.Quantity}</td>
                        <td>{character.Price}</td>
                        <td>{(double)requestCharacter.Quantity * character.Price}</td>
                    </tr>";
                index++;

                if (requestCharacter.CosplayerId != null)
                {
                    Account account = await accountRepository.GetAccount(requestCharacter.CosplayerId);
                    htmlContent += $@"<tr>
                            <td>{index}</td>
                            <td>{account.Name}</td>
                            <td>Cosplayer</td>
                            <td>-</td>
                            <td>{character.Price * account.SalaryIndex - character.Price}</td>
                            <td>{character.Price * account.SalaryIndex - character.Price}</td>
                        </tr>";
                    index++;
                }
            }

            double packagePrice = (package?.Price ?? 0);

            htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Package</td>
                    <td>{packagePrice}</td>
                </tr>";

            // Xử lý coupon
            double amount = accountCoupon?.Coupon?.Amount ?? 0.0;
            string formattedAmount = amount.ToString("0.##");

            htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Coupon</td>
                    <td>{formattedAmount}</td>
                </tr>";

            // Tính tổng số tiền
            double totalAmount = await CalculateTotalAmount(request, formattedAmount, packagePrice);

            htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Tổng</td>
                    <td>{totalAmount}</td>
                </tr>";

            htmlContent += "</table>";
        }



        private async void HtmlContractCharacter(Request request, AccountCoupon accountCoupon)
        {
            int index = 1;
            string htmlContent = null;
            htmlContent += @"<style>
            table {
                width: 100%;
                border-collapse: collapse;
                font-family: Arial, sans-serif;
            }
            th, td {
                border: 1px solid black;
                padding: 8px;
                text-align: center;
            }
            th {
                background-color: #f2f2f2;
                font-weight: bold;
            }
            td {
                font-size: 14px;
            }
            tr:nth-child(even) {
                background-color: #f9f9f9;
            }
            tr:hover {
                background-color: #e6f7ff;
            }
            .right-align {
                text-align: right;
                font-weight: bold;
            }
        </style>";

            // Bắt đầu bảng
            htmlContent += @"<table>
            <tr>
                <th>STT</th>
                <th>Tên trang phục, cosplayer</th>
                <th>Đơn vị tính</th>
                <th>Số lượng</th>
                <th>Đơn giá</th>
                <th>Thành tiền</th>
            </tr>";
            foreach (RequestCharacter requestCharacter in request.RequestCharacters)
            {
                Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);

                htmlContent += $@"<tr>
                        <td>{index}</td>
                        <td>{character.CharacterName}</td>
                        <td>Bộ</td>
                        <td>{requestCharacter.Quantity}</td>
                        <td>{character.Price}</td>
                        <td>{(double)requestCharacter.Quantity * character.Price * 5}</td>
                    </tr>";
                index++;
            }

            // Xử lý coupon
            double amount = accountCoupon?.Coupon?.Amount ?? 0.0;
            string formattedAmount = amount.ToString("0.##");

            htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Coupon</td>
                    <td>{formattedAmount}</td>
                </tr>";

            // Tính tổng số tiền
            double totalAmount = await CalculateTotalAmount(request, formattedAmount, 0);

            htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Tổng</td>
                    <td>{totalAmount}</td>
                </tr>";

            htmlContent += "</table>";
        }
    }
}
