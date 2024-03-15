using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class Exercise
    {

        [Key]
        [Description("Id of the exercise")]
        public int Id { get; set; }

        [Required]
        [Description("Name of the exercise")]
        public string Name { get; set; } = null!;


        [Description("Link to an image or video. YouTube will play as video.")]
        public string? Link { get; set; }

        [Description("Notes to the exercise (optional)")]
        public string? Notes { get; set; }
    }
}
