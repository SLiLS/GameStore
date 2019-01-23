using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BLL.DTO;

namespace GameStore.BLL.Interfaces
{
   public interface IOrderService
    {
        void MakeOrder(OrderDTO order);
        //GameDTO GetGame(int? id);
        //Task<IEnumerable<GameDTO>> GetGames();

        void Dispose();
    }
}
