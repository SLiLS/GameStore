using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BLL.DTO;
using AutoMapper;
using GameStore.DAL.Entities;
using GameStore.BLL.Interfaces;
using GameStore.DAL.Interfaces;
using GameStore.BLL.BusinessModels;
using GameStore.BLL.Infrastructure;


namespace GameStore.BLL.Services
{
   public class OrderService : IOrderService
    {
        IUnitOfWork Database { get;set; }

        public OrderService(IUnitOfWork db)
        {
            Database = db;
        }
        public void MakeOrder(OrderDTO orderDTO)
        {
            Game game = Database.Games.Get(orderDTO.GameId);
            //проверка наличия товара
            if (game == null)
                throw new ValidationException("Игра не найдена","");

            decimal sum = new Discount(0.2m).GetDiscounedPrice(game.Price);
            Order order = new Order
            {
                Sum = sum,
                Date = DateTime.Now,
                Address = orderDTO.Address,
                GameId = orderDTO.GameId,
                PhoneNumber = orderDTO.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
            
                
            
        }
        public IEnumerable<GameDTO> GetGames()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Game>, List<GameDTO>>(Database.Games.GetAll());
        }
        public GameDTO GetGame(int? id)
        {
            if (id == null)
                throw new ValidationException("Игра не найдена", "");
            var game = Database.Games.Get(id.Value);
            if (game == null)
                throw new ValidationException("Игра не найдена", "");
            return new GameDTO { GameCategory = game.GameCategory, GameDescription = game.GameDescription, GameName = game.GameName, Price = game.Price };
        }
         public void Dispose()
        {
            Database.Dispose();
        }

    }
}
