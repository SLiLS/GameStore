using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GameStore.DAL.Entities
{
  public   class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public  string Address { get; set; }

        public int GameId { get; set; }
       
        public DateTime Date { get; set; }
    }
}
