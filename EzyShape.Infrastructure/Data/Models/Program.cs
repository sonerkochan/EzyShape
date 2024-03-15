using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class Program
    {
        [Key]
        [Description("Id of the program")]
        public int Id { get; set; }

        [Required]
        [Description("Name of the program")]
        public string Name { get; set; } = null!;

        [Description("Description of the program")]
        public string? Descriptions { get; set; }

        [Description("List of exercises in the program.")]
        public IEnumerable<ProgramExercise> ExerciseIds { get; set; } = new List<ProgramExercise>();


        [Description("Id of the user that made the program.")]
        public string UserId { get; set; } = null!;


    }
}
