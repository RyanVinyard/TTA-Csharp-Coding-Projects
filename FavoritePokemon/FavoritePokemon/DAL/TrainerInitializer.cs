using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FavoritePokemon.Models;

namespace FavoritePokemon.DAL
{
    public class TrainerInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<TrainerContext>
    {
        protected override void Seed(TrainerContext context)
        {
            var trainers = new List<Trainer>
            {
                new Trainer{FirstName="Ryan" , LastName="Vinyard" , Birthday=Convert.ToInt32("1991") , Pokemon="Swampert" , Date=DateTime.Parse("2019-05-12")  }
                
            };

            trainers.ForEach(s => context.Trainers.Add(s));
            context.SaveChanges();
        }
    }
}