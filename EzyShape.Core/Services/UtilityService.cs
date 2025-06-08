using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzyShape.Core.Contracts;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EzyShape.Core.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly IRepository repo;
        private readonly UserManager<User> userManager;

        public UtilityService(
            IRepository _repo,
            UserManager<User> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
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
        }
    }
}
