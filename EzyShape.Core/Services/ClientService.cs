using EzyShape.Core.Contracts;
using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.WeightLog;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Services
{
    public class ClientService : IClientService
    {

        private readonly IRepository repo;
        private readonly UserManager<User> userManager;

        public ClientService(
            IRepository _repo,
            UserManager<User> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }


        public async Task<ClientViewModel> GetClientById(string clientId)
        {
            return await repo.AllReadonly<User>()
                .Where(u => u.Id == clientId)
                .Select(u => new ClientViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    ColorCode = u.ColorCode,
                })
                .FirstOrDefaultAsync();
        }


        [Description("Creates a new weight log and adds it to the database.")]
        public async Task AddWeightAsync(AddWeightLogViewModel model, string clientId)
        {
            var entity = new WeightLog()
            {
                Weight = model.Weight,
                UserId = model.UserId,
                LogDate = model.LogDate
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }


    }
}
