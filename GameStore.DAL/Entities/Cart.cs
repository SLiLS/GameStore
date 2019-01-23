using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace GameStore.DAL.Entities
{
  public class Cart
    {

        public int CartId { get; set; }

        public decimal  Sum { get; set; }
        public ICollection<Game> Games { get; set; }
        public Cart ()
        {
            Games = new List<Game>();
        }
       
    }
}
