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
        public async Task<bool> SendEmailNotification(PaymentPurpose? purpose, string toEmail, string ticketCode, string eventOrContractName, string location, DateTime Date, int? quantity, double? price, string? accountname)
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
                <td style='padding: 5px;'>{eventOrContractName}</td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>📍 Địa điểm:</strong></td>
                <td style='padding: 5px;'>{location}</td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>📆 Ngày diễn ra:</strong></td>
                <td style='padding: 5px;'>{Date:HH:mm dd/M/yyyy}</td>
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
        <p><strong>📝 Tên hợp đồng:</strong>{eventOrContractName}</p>
        <p><strong>📌 Khách hàng:</strong>{accountname}</p>
        <p><strong>💰 Số tiền đặt cọc:</strong>{price}VNĐ</p>
        <p><strong>📆 Ngày đặt cọc:</strong>{Date:HH:mm dd/M/yyyy}</p>
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
        <p><strong>📑 Tên hợp đồng:</strong>{eventOrContractName}</p>
        <p><strong>📌 Khách hàng:</strong>{accountname}</p>
        <p><strong>💰 Số tiền còn lại đã thanh toán:</strong>{price}VNĐ</p>
        <p><strong>📆 Ngày tất toán:</strong> {Date:HH:mm dd/M/yyyy}</p>
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
        public async Task<bool> SendContractExpiredEmail(string toEmail, string contractName, string accountName)
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
                message.Subject = "⚠ Hợp đồng đã hết hạn thanh toán";

                string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd;'>
    <h2 style='color: #dc3545; text-align: center;'>⏳ Hợp đồng đã hết hạn thanh toán!</h2>
    <div style='background-color: #fff; padding: 15px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);'>
        <p><strong>📄 Tên hợp đồng:</strong> {contractName}</p>
        <p><strong>📌 Khách hàng:</strong> {accountName}</p>
        <p style='color: #dc3545; font-weight: bold;'>⚠ Vui lòng kiểm tra và thực hiện thanh toán sớm nhất có thể!</p>
    </div>

    <div style='text-align: center; margin-top: 20px;'>
        <p style='color: #6c757d;'>Nếu bạn đã thanh toán, vui lòng bỏ qua email này.</p>
        <p style='margin-top: 15px; font-weight: bold;'>🙏 Cảm ơn Quý khách đã sử dụng dịch vụ của chúng tôi! 🙌</p>
    </div>
</div>";

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
        public async Task<bool> SendAccountVerificationEmail(string toEmail, string verificationCode)
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
                message.Subject = "🔐 Xác nhận đăng ký tài khoản";

                string emailBody = $@"
        <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
            <h2 style='color: #007bff;'>Chào mừng bạn đến với hệ thống của chúng tôi! 🎉</h2>
            <p>Vui lòng sử dụng mã xác nhận bên dưới để hoàn tất đăng ký tài khoản:</p>
            <h3 style='color: #28a745; font-size: 24px; font-weight: bold;'>{verificationCode}</h3>
            <p>Mã này có hiệu lực trong vòng 10 phút.</p>
            <p>👉 Nếu bạn không yêu cầu đăng ký, vui lòng bỏ qua email này.</p>
        </div>";

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendAccountNewTaskEmail(string toEmail)
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
                message.Subject = "📢 Có task mới";

                string emailBody = $@"
        <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
            <h2 style='color: #007bff;'>Bạn có task mới! 🎉</h2>
            <p>Vui lòng kiểm tra trên hệ thống để xem thông tin task mới.</p>
        </div>";

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendAccountCancelTaskEmail(string toEmail)
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
                message.Subject = "📢 Task đã hủy";

                string emailBody = $@"
        <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
            <h2 style='color: #007bff;'>Bạn có task mới! 🎉</h2>
            <p>Vui lòng kiểm tra trên hệ thống để xem thông tin.</p>
        </div>";

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> SendEmailRequestForManager(string email)
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
                message.To.Add(new MailboxAddress("", email));
                message.Subject = "📢 Request was assigned";

                string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #007bff;'>📌 New Request Requires Your Attention</h2>
    <p>A new request has been submitted and is awaiting your review.</p>
    <p>Please check the system to view the request details and update its status accordingly.</p>
    <p style='margin-top: 20px;'>
        <a href='https://fe-ccss-capstone.vercel.app/' style='display: inline-block; padding: 10px 20px; background-color: #007bff; color: #fff; text-decoration: none; border-radius: 5px;'>View Request</a>
    </p>
</div>";

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> SendEmailRequestForCosplayer(string email)
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
                message.To.Add(new MailboxAddress("", email));
                message.Subject = "📢 Request was assigned";

                string emailBody = @"
<div style='font-family: Arial, sans-serif; background-color: #fff0f5; color: #4b0082; padding: 20px; border-radius: 10px; border: 2px dashed #db7093; text-align: center;'>
    <h2 style='color: #ff69b4;'>🌟 New Mission for You, Cosplayer!</h2>
    <p style='font-size: 16px;'>A new request has arrived and it’s calling your name! 🎭✨</p>
    <p style='font-size: 15px;'>Step into character and check the system for all the magical details. Your response will help complete this quest.</p>
    <p style='margin-top: 20px;'>
        <a href='https://fe-ccss-capstone.vercel.app/' style='display: inline-block; padding: 12px 24px; background-color: #ff69b4; color: #fff; text-decoration: none; border-radius: 8px; font-weight: bold;'>🔍 View Your Quest</a>
    </p>
    <p style='margin-top: 15px; font-size: 13px; color: #888;'>Embrace the role. Make it yours. 💫</p>
</div>";


                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendManagerCustomerCharacterEmail(string toEmail)
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
                message.Subject = "📢 Có yêu cầu tạo mới trang phục";

                string emailBody = $@"
        <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
            <h2 style='color: #007bff;'>Bạn có yêu cầu mới về tạo mới trang phục! 🎉</h2>
            <p>Vui lòng kiểm tra trên hệ thống để xem thông tin trang phục.</p>
        </div>";

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendPasswordChangePassword(string toEmail)
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
                message.Subject = "📢 Quên mật khẩu";

                string emailBody = $@"
        <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
            <h2 style='color: #007bff;'>Bạn đã quên mật khẩu! 🎉</h2>
            <p>Hệ thống đã thay đổi mật khẩu của bạn là 123456. Vui lòng vào hệ thống đăng nhập và thay đổi mật khẩu</p>
        </div>";

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> SendCustomerStatusCustomerCharacterEmail(string toEmail, string status)
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
                message.Subject = "📢 Phản hồi về trang phục";

                string emailBody = $@"
        <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
            <h2 style='color: #007bff;'>Yêu cầu về tạo trang phục của bạn đã được {status}! 🎉</h2>
            <p>Vui lòng kiểm tra trên hệ thống để xem thông tin trang phục.</p>
        </div>";

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendCosplayerUpdateTask(string toEmail)
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
                message.Subject = "📢 Phản hồi về task";

                string emailBody = $@"
        <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
            <h2 style='color: #007bff;'>Task của bạn đã được cập nhật! 🎉</h2>
            <p>Vui lòng kiểm tra trên hệ thống để xem thông tin.</p>
        </div>";

                message.Body = new TextPart(TextFormat.Html) { Text = emailBody };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(fromEmail, emailPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return false;
            }
        }

    }
}
