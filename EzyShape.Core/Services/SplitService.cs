using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Exercises;
using EzyShape.Core.Models.Splits;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Services
{
    public class SplitService : ISplitService
    {
        private readonly IRepository repo;

        public SplitService(IRepository _repo)
        {
            repo = _repo;
        }


        [Description("Creates a new split and adds it to the database.")]
        public async Task AddSplitAsync(AddSplitViewModel model, string trainerId)
        {
            var entity = new Split()
            {
                Name = model.Name,
                Description= model.Description,
                UserId = trainerId
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }
    }
}
