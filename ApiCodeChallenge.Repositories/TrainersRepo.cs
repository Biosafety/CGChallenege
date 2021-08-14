using ApiCodeChallenge.Common.Interfaces;
using ApiCodeChallenge.Common.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCodeChallenge.Repositories
{
    public class TrainersRepo : ITrainersRepo
    {
        protected readonly TrainerDbContext context;

        public TrainersRepo()
        {
            //for code challenge purposes simple inmemory db
            context = (new TrainerDbContext(new DbContextOptionsBuilder<TrainerDbContext>()
                                .UseInMemoryDatabase(databaseName: "CGDB")
                                .Options));
        }

        public async Task CreateTrainer(Trainer trainer)
        {

            using (context)
            {
                context.Trainers.Add(trainer);
                await context.SaveChangesAsync();
            }
        }

        public async Task ModifyTrainer(Trainer trainer)
        {
            using (context)
            {
                context.Trainers.Update(trainer);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Trainer> GetTrainer(Guid trainerID)
        {
            Trainer dbTrainer;
            using (context)
            {
                dbTrainer = await context.Trainers.FirstOrDefaultAsync(x => x.TrainerID == trainerID);
            }

            if (dbTrainer == null)
            {
                //ideally this would be a custom exception type
                throw new Exception();
            }

            return dbTrainer;
        }

        public async Task<List<Trainer>> GetTrainers()
        {
            List<Trainer> dbTrainers;
            using (context)
            {
                dbTrainers = context.Trainers.ToList();
            }

            if (dbTrainers == null)
            {
                //ideally this would be a custom exception type
                throw new Exception();
            }
            return dbTrainers;

        }
    }
}
