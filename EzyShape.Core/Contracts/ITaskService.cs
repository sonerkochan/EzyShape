using EzyShape.Core.Models.Exercises;
using EzyShape.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface ITaskService
    {
        Task AddTaskAsync (AddTaskViewModel model, string trainerId);
    }
}
