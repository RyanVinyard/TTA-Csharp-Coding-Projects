using FavoritePokemon.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FavoritePokemon.DAL
{
    public class TrainerContext: DbContext
    {
        public TrainerContext() : base("TrainerContext")
        {

        }

        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }

    }
}