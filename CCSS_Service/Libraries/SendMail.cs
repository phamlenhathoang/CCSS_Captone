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
                    PaymentPurpose.BuyTicket => "Ticket booking confirmation",
                    PaymentPurpose.ContractDeposit => "Contract deposit confirmation",
                    PaymentPurpose.contractSettlement => "Contract settlement confirmation",
                    PaymentPurpose.Order => "Order confirmation",
                    _ => "Payment notification"
                };


                string emailBody = purpose switch
                {
                    PaymentPurpose.BuyTicket => $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #5a189a; text-align: center;'>🎉 Congratulations, your ticket has been booked successfully! 🎉</h2>
    <div style='background-color: #fff; padding: 15px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1); display: inline-block;'>
        <table style='margin: 0 auto; text-align: left;'>
            <tr>
                <td style='padding: 5px;'><strong>🌟 Event:</strong></td>
                <td style='padding: 5px;'>{eventOrContractName}</td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>📍 Location:</strong></td>
                <td style='padding: 5px;'>{location}</td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>📆 Date:</strong></td>
                <td style='padding: 5px;'>{Date:HH:mm dd/M/yyyy}</td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>🎟 Ticket code:</strong></td>
                <td style='padding: 5px;'><span style='color: #d63384; font-size: 18px;'>{ticketCode}</span></td>
            </tr>
            <tr>
                <td style='padding: 5px;'><strong>👥 Quantity:</strong></td>
                <td style='padding: 5px;'>{quantity}</td>
            </tr>
        </table>
    </div>

    <div style='text-align: center; margin-top: 20px;'>
        <p style='font-size: 16px; font-weight: bold'>📢 Please bring your ticket code for check-in at the event.</p>
        <p style='margin-top: 15px;'>🥰 Thank you for using our service, see you at the event!! 😘</p>
    </div>
</div>",

                    PaymentPurpose.ContractDeposit => $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd;'>
    <h2 style='color: #007bff; text-align: center;'>📄 Contract deposit confirmed successfully!</h2>
    <div style='background-color: #fff; padding: 15px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);'>
        <p><strong>📝 Contract name:</strong> {eventOrContractName}</p>
        <p><strong>📌 Customer:</strong> {accountname}</p>
        <p><strong>💰 Deposit amount:</strong> {price} VND</p>
        <p><strong>📆 Deposit date:</strong> {Date:HH:mm dd/M/yyyy}</p>
    </div>

    <div style='text-align: center; margin-top: 20px;'>
        <p style='font-size: 16px;'>✅ This deposit will be recorded into your contract.</p>
        <p style='color: #6c757d;'>Please keep this information for reference if needed.</p>
        <p style='margin-top: 15px; font-weight: bold;'>🙏 Thank you for using our service! 🙌</p>
    </div>
</div>",

                    PaymentPurpose.contractSettlement => $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd;'>
    <h2 style='color: #28a745; text-align: center;'>🎉 Your contract has been successfully settled!</h2>
    <div style='background-color: #fff; padding: 15px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);'>
        <p><strong>📑 Contract name:</strong> {eventOrContractName}</p>
        <p><strong>📌 Customer:</strong> {accountname}</p>
        <p><strong>💰 Remaining payment:</strong> {price} VND</p>
        <p><strong>📆 Settlement date:</strong> {Date:HH:mm dd/M/yyyy}</p>
    </div>

    <div style='text-align: center; margin-top: 20px;'>
        <p style='font-size: 16px;'>✅ The contract is now fully settled. All payment obligations have been fulfilled.</p>
        <p style='color: #6c757d;'>Please contact us if you need further assistance.</p>
        <p style='margin-top: 15px; font-weight: bold;'>🙏 Thank you for using our service! 🙌</p>
    </div>
</div>",

                    PaymentPurpose.Order => $@"
<h2>Your order has been confirmed!</h2>
<p>We will deliver your items soon.</p>",

                    _ => "<p>Thank you for your payment.</p>"
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
                message.Subject = "⚠ Contract Payment Expired";

                string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd;'>
    <h2 style='color: #dc3545; text-align: center;'>⏳ Contract Payment Expired!</h2>
    <div style='background-color: #fff; padding: 15px; border-radius: 8px; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);'>
        <p><strong>📄 Contract Name:</strong> {contractName}</p>
        <p><strong>📌 Customer:</strong> {accountName}</p>
        <p style='color: #dc3545; font-weight: bold;'>⚠ Please check and make the payment as soon as possible!</p>
    </div>

    <div style='text-align: center; margin-top: 20px;'>
        <p style='color: #6c757d;'>If you have already made the payment, please disregard this email.</p>
        <p style='margin-top: 15px; font-weight: bold;'>🙏 Thank you for using our service! 🙌</p>
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
                message.Subject = "🔐 Account Registration Confirmation";

                string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #007bff;'>Welcome to our system! 🎉</h2>
    <p>Please use the verification code below to complete your account registration:</p>
    <h3 style='color: #28a745; font-size: 24px; font-weight: bold;'>{verificationCode}</h3>
    <p>This code is valid for 10 minutes.</p>
    <p>👉 If you did not request this registration, please ignore this email.</p>
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
                message.Subject = "📢 New Task Assigned";

                string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #007bff;'>You have a new task! 🎉</h2>
    <p>Please check the system for the task details.</p>
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
                message.Subject = "📢 Task Cancelled";

                string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #007bff;'>A task has been cancelled! ⚠️</h2>
    <p>Please check the system for more information.</p>
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
                message.Subject = "📢 New Costume Creation Request";

                string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #007bff;'>You have a new costume creation request! 🎉</h2>
    <p>Please check the system for costume details.</p>
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
               message.Subject = "📢 Password Reset";

string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #007bff;'>You have requested a password reset! 🔒</h2>
    <p>Your password has been reset to <strong>123456</strong>. Please log in to the system and change your password immediately.</p>
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
                message.Subject = "📢 Feedback on Costume Creation";

                string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #007bff;'>Your costume creation request has been {status}! 🎉</h2>
    <p>Please check the system for costume details.</p>
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
                message.Subject = "📢 Task Update";

string emailBody = $@"
<div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
    <h2 style='color: #007bff;'>Your task has been updated! 🎉</h2>
    <p>Please check the system for details.</p>
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

        public async Task<bool> SendCustomerRefundOverdueContract(string toEmail, string day)
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
                message.Subject = "📢 Feedback on contract";

                string emailBody = $@"
        <div style='font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; padding: 20px; border-radius: 8px; border: 1px solid #ddd; text-align: center;'>
            <h2 style='color: #007bff;'>Your contract has expired! 🎉</h2>
            $<p>According to the terms of the contract, you have violated the contract. After {day}, if you still have not returned the item to the system, the system will record that you have lost the entire contract deposit.</p>
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
