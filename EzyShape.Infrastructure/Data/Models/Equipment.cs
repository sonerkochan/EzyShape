using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class Equipment
    {
        [Key]
        [Description("Id of the equipment.")]
        public int Id { get; set; }

        [StringLength(100)]
        [Description("Name of the equipment.")]
        public string Name { get; set; } = null!;

        [Description("List of the exercises using this equipment.")]
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
