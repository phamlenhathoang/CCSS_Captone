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
        private readonly IRequestDatesRepository requestDatesRepository;

        public Pdf(IPackageRepository packageRepository, ICharacterRepository characterRepository, IAccountRepository accountRepository, IRequestRepository requestRepository, IAccountCouponRepository accountCouponRepository, IRequestDatesRepository requestDatesRepository)
        {
            this.characterRepository = characterRepository;
            this.accountRepository = accountRepository;
            this.requestRepository = requestRepository;
            this.accountCouponRepository = accountCouponRepository;
            this.packageRepository = packageRepository;
            this.requestDatesRepository = requestDatesRepository;
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

                //if (request.AccountCouponId != null)
                //{
                //    accountCoupon = await accountCouponRepository.GetAccountCoupon(request.AccountCouponId);
                //    if (accountCoupon == null)
                //    {
                //        throw new Exception("AccountCoupon does not exist");
                //    }
                //}

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
                    htmlContent += "<h2>SOCIALIST REPUBLIC OF VIETNAM</h2>";
                    htmlContent += "<h3><u>Independence - Freedom - Happiness</u></h3>";
                    DateTime now = DateTime.Now;
                    string formattedDate = now.ToString("dd/MM/yyyy");
                    htmlContent += $"<p style='text-align: right; margin-right: 10px;'>Ho Chi Minh City, {formattedDate}</p>";
                    htmlContent += $"<h1>{request.Service.ServiceName.ToUpper()}</h1>";
                    htmlContent += "<p><b>PARTY A:</b> THE LESSOR</p>";
                    htmlContent += "<p>Organization name: Cosplayer Rental and Event Organization System</p>";
                    htmlContent += "<p>Address: Ho Chi Minh City</p>";
                    htmlContent += "<p>Representative: Truong Tuan Anh</p>";
                    htmlContent += "<p>Position: Director</p>";
                    htmlContent += "<p><b>PARTY B:</b> THE LESSEE</p>";
                    htmlContent += $"<p>Full name: {request.Account.Name.ToUpper()}</p>";
                    htmlContent += $"<p>Address: {request.Location}</p>";
                    htmlContent += $"<p>Phone number: {request.Account.Phone}</p>";

                    htmlContent += $"<p><i>Considering the request from Party B, both parties agree to sign the contract for {request.Service.ServiceName.ToLower()}. The rental agreement will include the following important contents:</i></p>";


                    // Thêm CSS để làm đẹp bảng
                    double totalDay = (request.EndDate - request.StartDate).TotalDays + 1;
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
                    <th>No.</th>
                    <th>Costume/Cosplayer Name</th>
                    <th>Unit</th>
                    <th>Quantity</th>
                    <th>Unit Price</th>
                    <th>Total Price</th>
                </tr>";
                        foreach (RequestCharacter requestCharacter in request.RequestCharacters)
                        {
                            Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);

                            htmlContent += $@"<tr>
                        <td>{index}</td>
                        <td>{character.CharacterName}</td>
                        <td>Set</td>
                        <td>{requestCharacter.Quantity}</td>
                        <td>{character.Price}</td>
                        <td>{(double)requestCharacter.Quantity * (character.Price * 5 + character.Price * totalDay)}</td>
                    </tr>";
                            index++;
                        }

                        // Xử lý coupon
                        double amount = accountCoupon?.Coupon?.Amount ?? 0.0;
                        string formattedAmount = amount.ToString("0.##");

                        // Tính tổng số tiền
                        double totalAmount = await CalculateTotalAmount(request, formattedAmount, 0);

                        htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Total deposit</td>
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
                    <th>No.</th>
                    <th>Costume/Cosplayer Name</th>
                    <th>Unit</th>
                    <th>Quantity</th>
                    <th>Unit Price</th>
                    <th>Total Price</th>
                </tr>";
                        double totalHours = 0;
                        int day = 0;
                        int count = 0;


                        foreach (RequestCharacter requestCharacter in request.RequestCharacters)
                        {
                            Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);

                            if (count == 0)
                            {
                                List<RequestDate> requestDates = await requestDatesRepository.GetListRequestDateByRequestCharacterId(requestCharacter.RequestCharacterId);

                                foreach (RequestDate requestDate in requestDates)
                                {
                                    totalHours += (requestDate.EndDate - requestDate.StartDate).TotalHours;
                                    day++;
                                }

                                count++;
                            }


                            htmlContent += $@"<tr>
                        <td>{index}</td>
                        <td>{character.CharacterName}</td>
                        <td>Set</td>
                        <td>{requestCharacter.Quantity}</td>
                        <td>{character.Price}</td>
                        <td>{day * character.Price}</td>
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
                            <td>{account.SalaryIndex}</td>
                            <td>{account.SalaryIndex * totalHours}</td>
                        </tr>";
                                index++;
                            }
                        }

                        double packagePrice = (package?.Price ?? 0);

                        if (request.Service.ServiceId.Equals("S003"))
                        {
                            htmlContent += $@"<tr>
                            <td colspan='5' class='right-align'>Package</td>
                            <td>{packagePrice}</td>
                            </tr>";
                        }

                        // Xử lý coupon
                        double amount = accountCoupon?.Coupon?.Amount ?? 0.0;
                        string formattedAmount = amount.ToString("0.##");

                        // Tính tổng số tiền
                        double totalAmount = await CalculateTotalAmount(request, formattedAmount, packagePrice);

                        htmlContent += $@"<tr>
                    <td colspan='5' class='right-align'>Total price</td>
                    <td>{totalAmount}</td>
                </tr>";

                        htmlContent += "</table>";
                    }

                    if (request.ServiceId != "S001")
                    {
                        htmlContent += $"<p>Deposited: {request.Deposit}%</p>";
                        htmlContent += $"<p>Prepaid customer: {(request.Price * deposit) / 100} VND</p>";
                        htmlContent += $"<p>The remaining amount to be paid at the end of the contract: {request.Price - ((request.Price * deposit) / 100)} VND</p>";

                        htmlContent += "<p>The rental contract is based on specific time slots.</p>";

                        int c = 0;
                        foreach (RequestCharacter requestCharacter in request.RequestCharacters)
                        {
                            if (c == 0)
                            {
                                List<RequestDate> requestDates = await requestDatesRepository.GetListRequestDateByRequestCharacterId(requestCharacter.RequestCharacterId);
                                foreach (RequestDate requestDate in requestDates)
                                {
                                    string formattedStartDate = requestDate.StartDate.ToString("HH:mm dd/MM/yyyy");
                                    string formattedEndDate = requestDate.EndDate.ToString("HH:mm dd/MM/yyyy");

                                    htmlContent += $"<p>{formattedStartDate} - {formattedEndDate}<p>";
                                }
                                c++;
                            }

                        }
                    }
                    else
                    {
                        htmlContent += $"<p>Deposited: {request.Deposit} VND</p>";
                        htmlContent += $"<p>Prepaid customer: {request.Deposit} VND</p>";
                        htmlContent += $"<p>Rental fee: {request.Price} VND</p>";
                        htmlContent += $"<p>The remaining amount will depend on the extent of damage to the item.</p>"; 

                        htmlContent += $"<p>Start date: {request.StartDate.ToString("dd/MM/yyyy")}<p>";
                        htmlContent += $"<p>End date: {request.EndDate.ToString("dd/MM/yyyy")}<p>";

                    }

                    // Contract Information
                    htmlContent += "<h3><strong>Character Rental Terms</strong></h3>";
                    htmlContent += "<p>The lessee has the right to use costumes and props as listed in the rental agreement.</p>";
                    htmlContent += "<p>Costumes and props must not be used for illegal purposes or in any way that may negatively affect the brand image.</p>";
                    htmlContent += "<p>The lessee is responsible for keeping the costumes and props in good condition.</p>";
                    htmlContent += "<p>Costumes must not be cut, torn, stained, or altered without the consent of the lessor.</p>";
                    htmlContent += "<p>If costumes or props are damaged or lost, the lessee must compensate according to the rates specified in the contract.</p>";
                    htmlContent += "<p>For minor damages, the lessee is responsible for repair costs.</p>";
                    htmlContent += "<p>The customer must place a deposit equivalent to the costume design cost before receiving the items.</p>";
                    htmlContent += "<p>The rental fee is calculated based on the number of rental days and will be deducted from the deposit upon return.</p>";
                    htmlContent += "<p>When the customer returns the costume, the lessor will inspect the condition. If there is no damage, the deposit will be refunded after deducting the rental fee. If there is damage, repair costs will be deducted from the deposit.</p>";
                    htmlContent += "<p>If the total rental and repair costs exceed the deposit, the customer is responsible for paying the difference before the contract is concluded.</p>";

                    if (request.ServiceId != "S001")
                    {
                        string formattedEndDate = request.EndDate.ToString("dd/MM/yyyy");

                        htmlContent += "<p>In any case, if Party B unilaterally terminates the contract, whether intentionally or unintentionally, Party B will lose the entire deposit paid to Party A.</p>";
                        htmlContent += $"<p>After {formattedEndDate} if Party B does not update the return process to Party A, Party B will lose the entire deposit.</p>";
                    }

                    htmlContent += "<h3><strong>Cosplayer Rental Terms</strong></h3>";
                    htmlContent += "<p>The cosplayer will portray the character as requested by the lessee.</p>";
                    htmlContent += "<p>The cosplayer will participate in events, performances, meet-and-greet sessions, or photoshoots as per the agreed schedule.</p>";
                    htmlContent += "<p>The cosplayer has the right to refuse any requests that violate ethics, laws, or personal image.</p>";
                    htmlContent += "<p>The cosplayer must follow the costume and performance style as committed.</p>";
                    htmlContent += "<p>Additional expenses such as transportation, meals, and accommodation (if any) shall be covered by the lessee.</p>";

                    htmlContent += "<h3><strong>Contract Agreement Terms</strong></h3>";
                    htmlContent += "<p>Payment shall be made according to the agreed rates in the contract.</p>";
                    htmlContent += "<p>Full payment must be made before the event begins. The remaining balance shall be paid after the event concludes.</p>";

                    htmlContent += "<p>In any case, if Party B unilaterally terminates the contract, whether intentionally or unintentionally, Party B will lose the entire deposit paid to Party A.</p>";


                    htmlContent += "<br/><br/>";
                    htmlContent += "<div style='display: flex; justify-content: space-between; margin-top: 30px;'>";

                    htmlContent += "<div style='width:45%; text-align:center;'>";
                    htmlContent += "<strong>Party A</strong><br/>Signature & Full Name";
                    htmlContent += "</div>";

                    htmlContent += "<div style='width:45%; text-align:center;'>";
                    htmlContent += "<strong>Party B</strong><br/>Signature & Full Name";
                    htmlContent += "</div>";

                    htmlContent += "</div>";




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
            double totalHours = 0;
            int day = 0;
            int count = 0;
            double totalDay = (request.EndDate - request.StartDate).TotalDays + 1;

            foreach (RequestCharacter requestCharacter in request.RequestCharacters)
            {
                if (count == 0)
                {
                    List<RequestDate> requestDates = await requestDatesRepository.GetListRequestDateByRequestCharacterId(requestCharacter.RequestCharacterId);

                    foreach (RequestDate requestDate in requestDates)
                    {
                        totalHours += (requestDate.EndDate - requestDate.StartDate).TotalHours;
                        day++;
                    }

                    count++;
                }
            }

            double totalAmount = 0;

            foreach (RequestCharacter requestCharacter in request.RequestCharacters)
            {
                Character character = await characterRepository.GetCharacter(requestCharacter.CharacterId);

                if (requestCharacter.CosplayerId != null)
                {
                    double totalPrice = 0;
                    Account account = await accountRepository.GetAccount(requestCharacter.CosplayerId);
                    totalPrice = (double)character.Price * day + (double)account.SalaryIndex * totalHours;
                    totalAmount += totalPrice;
                }
                else
                {
                    totalAmount += (double)requestCharacter.Quantity * ((double)character.Price * totalDay + (double)character.Price * 5);
                }
            }
            double parsedAmount;
            if (double.TryParse(amount, out parsedAmount))
            {
                return totalAmount - parsedAmount + price;
            }
            if (request.ServiceId != "S001")
            {
                return day * totalAmount;
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
