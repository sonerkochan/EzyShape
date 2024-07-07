using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

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



        [Description("Id of the muscle.")]
        public int? MuscleId { get; set; }

        [ForeignKey(nameof(MuscleId))]

        [Description("Primary muscles worked with the exercise")]
        public Muscle? Muscle { get; set; }



        [Description("Id of the category.")]
        public int? CategoryId { get; set; }    

        [ForeignKey(nameof(CategoryId))]

        [Description("Type of the category")]
        public Category? Category { get; set; }



        [Description("Id of the type.")]
        public int? LevelId { get; set; }

        [ForeignKey(nameof(LevelId))]

        [Description("Level of the exercise")]
        public Level? Level { get; set; }



        [Description("Id of the equipment.")]
        public int? EquipmentId { get; set; }

        [ForeignKey(nameof(EquipmentId))]

        [Description("Equipment used for the exercise")]
        public Equipment? Equipment { get; set; }



        [Description("Id of the user that made the exercise.")]
        public string UserId { get; set; } = null!;
    }
}