using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class Level
    {
        [Key]
        [Description("Id of the level.")]
        public int Id { get; set; }

        [StringLength(100)]
        [Description("Name of the level.")]
        public string Name { get; set; } = null!;

        [Description("List of the exercises at this level.")]
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
