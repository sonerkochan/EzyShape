using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzyShape.Core.Contracts;

namespace EzyShape.Core.Services
{
    public class UtilityService : IUtilityService
    {
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
    }
}
