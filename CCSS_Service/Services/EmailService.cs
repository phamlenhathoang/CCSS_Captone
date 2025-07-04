﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message, bool isHtml);
    }
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("nhathoang1470@gmail.com", "vjnb wwrv sxlc whci"),
                EnableSsl = true,
            };
        }
        public async Task SendEmailAsync(string email, string subject, string message, bool isHtml = false)
        {
            try
            {
                var mailMessage = new MailMessage("nhathoang1470@gmail.com", email, subject, message);
                mailMessage.IsBodyHtml = isHtml;

                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException smtpEx)
            {
                // Xử lý lỗi liên quan đến SMTP
                throw new Exception($"SMTP error: {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}
