using EzyShape.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EzyShape.Core.Models.Exercises
{
    /// <summary>
    /// View model for adding a new exercise
    /// </summary>
    public class AddExerciseViewModel
    {
        [Required]
        [StringLength(100)]
        [Description("Name of the exercise.")]
        public string Name { get; set; } = null!;

        [Description("Link to an image or video. YouTube will play as video.")]
        public string? Link { get; set; }

        [Description("Notes to the exercise (optional).")]
        public string? Notes { get; set; }

        [Required]
        [Description("Primary muscles worked with the exercise.")]
        public int MuscleId { get; set; }

        [Required]
        [Description("Category of the exercise.")]
        public int CategoryId { get; set; }

        [Required]
        [Description("Level of the exercise.")]
        public int LevelId { get; set; }

        [Required]
        [Description("Equipment used for the exercise.")]
        public int EquipmentId { get; set; }

        [Description("List of all available primary muscles.")]
        public IEnumerable<Muscle> Muscles { get; set; } = new List<Muscle>();

        [Description("List of all available exercise categories.")]
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        [Description("List of all available exercise levels.")]
        public IEnumerable<Level> Levels { get; set; } = new List<Level>();

        [Description("List of all available equipment.")]
        public IEnumerable<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}