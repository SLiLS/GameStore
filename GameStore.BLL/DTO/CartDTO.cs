using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.DTO
{
  public  class CartDTO
    {
        public int CartId { get; set; }
        public decimal Sum { get; set; }
        public ICollection<GameDTO> Games { get; set; }
        public CartDTO()
        {
            Games = new List<GameDTO>();
        }
    }
}
