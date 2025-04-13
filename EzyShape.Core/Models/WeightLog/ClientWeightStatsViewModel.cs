using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.WeightLog
{
    public class ClientWeightStatsViewModel
    {
        public double StartWeight { get; set; }
        public double CurrentWeight { get; set; }
        public double WeightChange => CurrentWeight - StartWeight;
        public double AverageMonthlyChange { get; set; }
        public int MonthsTracked { get; set; }
        public string TrendDescription { get; set; }
    }
}
