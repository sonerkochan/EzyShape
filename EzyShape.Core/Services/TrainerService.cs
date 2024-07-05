using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Client;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly IRepository repo;
        private readonly UserManager<User> userManager;

        public TrainerService(
            IRepository _repo,
            UserManager<User> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public async Task<IEnumerable<ClientSmallViewModel>> GetTrainersAllClients(string TrainerId)
        {
            return await repo.AllReadonly<User>()
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .Where(u => u.TrainerId == TrainerId)
                .Select(u => new ClientSmallViewModel()
                {
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                })
                .ToListAsync();



            /*
            var trainer = this.userManager.FindByIdAsync(TrainerId).GetAwaiter().GetResult();

            var clients = trainer.Clients.Select(c => new ClientSmallViewModel()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Username = c.UserName,
            })
                .ToList();

            return clients;
            */

        }



    }
}
