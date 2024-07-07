using EzyShape.Core.Contracts;
using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Services
{
    public class UserService : IUserService
    {

        private readonly IRepository repo;
        private readonly UserManager<User> userManager;

        public UserService(
            IRepository _repo,
            UserManager<User> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public int GetUsersCount()
        {
            return repo.AllReadonly<User>().Count();
        }
    }
}
