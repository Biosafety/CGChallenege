using ApiCodeChallenge.Common.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiCodeChallenge.Common.Interfaces
{
    public interface ITrainersService
    {
        Task<List<Trainer>> GetTrainers();
        Task<Trainer> GetTrainer(Guid trainerID);
        Task CreateTrainer(Trainer trainer);
        Task<Trainer> ModifyTrainer(Guid ID, JsonPatchDocument<Trainer> trainerPatch);
    }
}
