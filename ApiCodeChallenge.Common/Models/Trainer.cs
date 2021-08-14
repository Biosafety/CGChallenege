using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCodeChallenge.Common.Models
{
    public class Trainer : Person
    {
        public Guid TrainerID { get; set; } = Guid.NewGuid();

        public Trainer(Guid TrainerID, Person person) : base(person.FirstName, person.LastName, person.Address)
        {
            TrainerID = TrainerID;
        }
        public Trainer()
        {

        }
    }

    public class TrainerDbContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }

        public TrainerDbContext()
        {
        }

        public TrainerDbContext(DbContextOptions<TrainerDbContext> options) : base(options)
        {
        }
    }
}
