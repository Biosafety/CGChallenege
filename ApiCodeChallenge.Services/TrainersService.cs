using ApiCodeChallenge.Common.Interfaces;
using ApiCodeChallenge.Common.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiCodeChallenge.Services
{
    public class TrainersService : ITrainersService
    {
        protected readonly ITrainersRepo TrainerRepo;
        public TrainersService(ITrainersRepo trainerRepo)
        {
            TrainerRepo = trainerRepo;
        }


        public async Task CreateTrainer(Trainer trainer)
        {
            await TrainerRepo.CreateTrainer(trainer);
        }

        public async Task<Trainer> GetTrainer(Guid trainerID)
        {
            return await TrainerRepo.GetTrainer(trainerID);
        }

        public async Task<List<Trainer>> GetTrainers()
        {
            return await TrainerRepo.GetTrainers();
        }

        public async Task<Trainer> ModifyTrainer(Guid ID, JsonPatchDocument<Trainer> trainerPatch)
        {
            try
            {
                Trainer trainerToModify = await TrainerRepo.GetTrainer(ID);

                if (trainerToModify != null)
                {
                    trainerPatch.ApplyTo(trainerToModify);

                    //save to DB
                    await TrainerRepo.ModifyTrainer(trainerToModify);

                    return trainerToModify;
                }
                return null;
            }
            //same thing here could be an exception or return null
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
