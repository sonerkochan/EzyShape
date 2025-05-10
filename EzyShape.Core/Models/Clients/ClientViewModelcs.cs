using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzyShape.Infrastructure.Data.Models;

namespace EzyShape.Core.Models.Clients
{
    public class ClientViewModel
    {
        public string Id { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string ColorCode { get; set; } = null!;

        public IEnumerable<Split> Splits { get; set; } = new List<Split>();

        public DateTime? LastOnline { get; set; }

        public string? PreferredLanguage { get; set; }
    }
}
