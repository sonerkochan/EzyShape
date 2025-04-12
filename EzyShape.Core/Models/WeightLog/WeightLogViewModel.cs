using System.ComponentModel.DataAnnotations;

namespace EzyShape.Core.Models.WeightLog
{
    public class WeightLogViewModel
    {
        public decimal Weight { get; set; }

        public DateTime LogDate { get; set; }
    }
}
