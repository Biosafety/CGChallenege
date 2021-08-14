using ApiCodeChallenge.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiCodeChallenge.Common.Interfaces
{
    public interface ITrainersRepo
    {
        Task<List<Trainer>> GetTrainers();
        Task<Trainer> GetTrainer(Guid trainerID);
        Task CreateTrainer(Trainer trainer);
        Task ModifyTrainer(Trainer trainer);
    }
}
