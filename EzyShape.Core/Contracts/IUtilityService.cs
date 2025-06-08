using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface IUtilityService
    {
        Task<string> GenerateRandomLightHexColorAsync();
        Task ChangePreferredLanguageAsync(string userId, string languageCode);
    }
}
