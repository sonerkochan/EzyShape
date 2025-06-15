using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EzyShape.Core.Contracts;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using EzyShape.Core.Models.SMTP;
using Microsoft.Extensions.Options;

namespace EzyShape.Core.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly IRepository repo;
        private readonly UserManager<User> userManager;
        private readonly SmtpSettings _smtpSettings;

        public UtilityService(
            IRepository _repo,
            UserManager<User> _userManager,
            IOptions<SmtpSettings> smtpOptions)
        {
            repo = _repo;
            userManager = _userManager;
            _smtpSettings = smtpOptions.Value;
        }
        public async Task<string> GenerateRandomLightHexColorAsync()
        {
            return await Task.Run(() =>
            {
                Random random = new Random();
                int red = random.Next(127, 256);
                int green = random.Next(127, 256);
                int blue = random.Next(127, 256);

                return $"#{red:X2}{green:X2}{blue:X2}";
            });
        }

        public async Task ChangePreferredLanguageAsync(string userId, string languageCode)
        {
            // Fetch the user
            var client = await repo.All<User>()
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (client == null)
            {
                throw new Exception("User not found");
            }

            client.PreferredLanguage = languageCode.ToLower();

            await repo.SaveChangesAsync();
            await repo.SaveChangesAsync();
        }

        public async Task SendClientWelcomeEmailAsync(string toEmail, string fullName, string username, string password)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                Subject = "Welcome to EzyShape!",
                IsBodyHtml = true,
                Body = $@"
                    <h2>Welcome, {fullName}!</h2>
                    <p>Your account has been created.</p>
                    <p><strong>Your username:</strong> {username}</p>
                    <p><strong>Your password:</strong> {password}</p>
                    <p>Please change your password after your first login.</p>
                    <p>You can access your account here: <a href='https://ezyshape.azurewebsites.net/'>https://ezyshape.azurewebsites.net/</a></p>
                    <hr />
                    <p style='font-size:0.8em;'>This is an automated message. Please do not reply.</p>"
            };

            mail.To.Add(toEmail);

            using var smtp = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_smtpSettings.User, _smtpSettings.Pass)
            };

            await smtp.SendMailAsync(mail);
        }
    }
}
