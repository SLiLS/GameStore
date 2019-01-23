using System;
using System.Collections.Generic;
using GameStore.BLL.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Interfaces
{
   public interface IGameService
    {
        void CreateGame(GameDTO game);
        void UpdateGame(GameDTO game);
        void DeleteGame(int id);
        GameDTO GetGame(int? id);
        IEnumerable<GameDTO> GetGames();
        IEnumerable<GameDTO> Findgames(string searchtext);
        void Dispose();
    }
}
