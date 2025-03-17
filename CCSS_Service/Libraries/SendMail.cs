using CCSS_Repository.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Libraries
{
    public class SendMail
    {
        public async Task<bool> SendEmailNotification(PaymentPurpose? purpose, string toEmail, string ticketCode, string eventName, string location, DateTime startDate, int quantity)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .Build();

                string fromEmail = configuration["FromEmail:Email"];
                string emailPassword = configuration["FromEmail:Password"];

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("CCSS", fromEmail));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = purpose switch
                {
                    PaymentPurpose.BuyTicket => "Xác nhận đặt vé thành công",
                    PaymentPurpose.ContractDeposit => "Xác nhận đặt cọc hợp đồng",
                    PaymentPurpose.contractSettlement => "Xác nhận tất toán hợp đồng",
                    PaymentPurpose.Order => "Xác nhận đơn hàng",
                    _ => "Thông báo thanh toán"
                };

                string emailBody = purpose switch
                {
                    PaymentPurpose.BuyTicket => $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #5a189a; text-align: center;'>🎉 Chúc mừng, bạn đã đặt vé thành công! 🎉</h2>
    <div style='background-color: #fff; padding: 15px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1); display: inline-block;'>
        <table style='margin: 0 auto; text-align: left;'>
            <tr>
                <td style='padding: 5px;'><strong>🌟 Sự kiện:</strong></td>
                <td style='padding: 5px;'>{eventName}</td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>📍 Địa điểm:</strong></td>
                <td style='padding: 5px;'>{location}</td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>📆 Ngày diễn ra:</strong></td>
                <td style='padding: 5px;'>{startDate:HH:mm dd/M/yyyy}</td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>🎟 Mã vé:</strong></td>
                <td style='padding: 5px;'><span style='color: #d63384; font-size: 18px;'>{ticketCode}</span></td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>👥 Số lượng vé:</strong></td>
                <td style='padding: 5px;'>{quantity}</td>
            </tr>
        </table>
    </div>

    <div style='text-align: center; margin-top: 20px;'>
        <p style='font-size: 16px; font-weight: bold'>📢 Vui lòng mang theo mã vé khi tham dự để check-in.</p>
        <p style='margin-top: 15px;'>🥰 Cảm ơn Quý khách đã sử dụng dịch vụ của chúng tôi, hẹn gặp bạn tại sự kiện sắp tới!! 😘</p>
    </div>
</div>",

                    PaymentPurpose.ContractDeposit => $@"
                <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd;'>
    <h2 style='color: #007bff; text-align: center;'>📄 Xác nhận đặt cọc hợp đồng thành công!</h2>
    <div style='background-color: #fff; padding: 15px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);'>
        <p><strong>📝 Số hợp đồng:</strong>..............</p>
        <p><strong>📌 Khách hàng:</strong>................</p>
        <p><strong>💰 Số tiền đặt cọc:</strong> .............. VNĐ</p>
        <p><strong>📆 Ngày đặt cọc:</strong> .....................</p>
    </div>

    <div style='text-align: center; margin-top: 20px;'>
        <p style='font-size: 16px;'>✅ Khoản đặt cọc này sẽ được ghi nhận vào hợp đồng của bạn.</p>
        <p style='color: #6c757d;'>Vui lòng giữ thông tin này để đối chiếu khi cần thiết.</p>
        <p style='margin-top: 15px; font-weight: bold;'>🙏 Cảm ơn Quý khách đã sử dụng dịch vụ của chúng tôi! 🙌</p>
    </div>
</div>",

                    PaymentPurpose.contractSettlement => $@"
                <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd;'>
    <h2 style='color: #28a745; text-align: center;'>🎉 Hợp đồng của bạn đã được tất toán thành công!</h2>
    <div style='background-color: #fff; padding: 15px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);'>
        <p><strong>📑 Số hợp đồng:</strong> ....................</p>
        <p><strong>📌 Khách hàng:</strong> .................</p>
        <p><strong>💰 Tổng số tiền đã thanh toán:</strong> ................... VNĐ</p>
        <p><strong>📆 Ngày tất toán:</strong> .................</p>
    </div>

    <div style='text-align: center; margin-top: 20px;'>
        <p style='font-size: 16px;'>✅ Hợp đồng đã hoàn tất. Mọi nghĩa vụ thanh toán đều đã được thực hiện.</p>
        <p style='color: #6c757d;'>Vui lòng liên hệ nếu cần hỗ trợ thêm.</p>
        <p style='margin-top: 15px; font-weight: bold;'>🙏 Cảm ơn Quý khách đã sử dụng dịch vụ của chúng tôi! 🙌</p>
    </div>
</div>",

                    PaymentPurpose.Order => $@"
                <h2>Đơn hàng của bạn đã được xác nhận!</h2>
                <p>Chúng tôi sẽ sớm giao hàng cho bạn.</p>",

                    _ => "<p>Cảm ơn bạn đã thực hiện thanh toán.</p>"
                };

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true; // ✅ Gửi email thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false; // ❌ Gửi email thất bại
            }
        }
    }
}
