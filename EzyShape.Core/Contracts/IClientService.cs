using EzyShape.Core.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface IClientService
    {
        Task<ClientViewModel> GetClientById(string clientId);
    }
}
