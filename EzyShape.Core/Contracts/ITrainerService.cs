﻿using EzyShape.Core.Models.Client;
using EzyShape.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Contracts
{
    public interface ITrainerService
    {

        Task<IEnumerable<ClientSmallViewModel>> GetTrainersAllClients(string TrainerId);
    }
}