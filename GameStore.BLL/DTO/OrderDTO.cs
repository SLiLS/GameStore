using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.DTO
{
   public class OrderDTO
    {
        public int OrderId { get; set; }
        public string Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int GameId { get; set; }
      
        public DateTime? Date { get; set; }
    }
}
