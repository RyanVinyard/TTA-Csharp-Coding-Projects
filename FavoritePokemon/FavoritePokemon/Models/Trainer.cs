using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FavoritePokemon.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Birthday { get; set; }
        public string Pokemon { get; set; }
        public DateTime Date { get; set; }

        
    }
}