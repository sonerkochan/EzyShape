using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class ClientSplit
    {

        [Required]
        [Description("Id of the User.")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        [Description("Id of the split.")]
        public int SplitId { get; set; }

        [ForeignKey(nameof(SplitId))]
        public Split Split { get; set; }
    }
}
