using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace GameStore.DAL.Entities
{
    public class Game
    {


        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        
        public Requirement Requirement { get; set; }
      
     

    }
}
