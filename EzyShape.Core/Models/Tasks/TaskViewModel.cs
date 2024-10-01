using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.Tasks
{
    public class TaskViewModel
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
