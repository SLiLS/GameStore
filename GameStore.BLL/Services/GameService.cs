using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameStore.BLL.DTO;
using GameStore.BLL.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using GameStore.DAL.Interfaces;
using System.Data.Entity;
using GameStore.BLL.Infrastructure;
using GameStore.DAL.Entities;


namespace GameStore.BLL.Services
{
   public class GameService : IGameService
    {
        IUnitOfWork database;
        public GameService(IUnitOfWork unitOf)
        {
            database = unitOf;
        }

        public IEnumerable<GameDTO> GetGames()
        {
            var map = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDTO>().ForMember(dto => dto.CPU,
      src => src.MapFrom(b => b.Requirement.CPU)).ForMember(ram => ram.RAM, r => r.MapFrom(n => n.Requirement.RAM)).ForMember(opr => opr.OperationSystem,
      sys => sys.MapFrom(ops => ops.Requirement.OperationSystem)).ForMember(v => v.Category, vd => vd.MapFrom(vid => vid.Category.Name)).ForMember(v => v.VideoCard, vd => vd.MapFrom(vid => vid.Requirement.VideoCard))).CreateMapper();

            return map.Map<IEnumerable<Game>,List<GameDTO>>( database.Games.GetAll());
        }
        public GameDTO GetGame(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Игра не найдена", "");
            }
            Game game = database.Games.Get(id);
            if (game == null)
                throw new ValidationException("Игра не найдена ", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDTO>().ForMember(dto => dto.CPU,
                src => src.MapFrom(b => b.Requirement.CPU)).ForMember(ram => ram.RAM, r => r.MapFrom(n => n.Requirement.RAM)).ForMember(opr => opr.OperationSystem,
                sys => sys.MapFrom(ops => ops.Requirement.OperationSystem)).ForMember(v => v.Category, vd => vd.MapFrom(vid => vid.Category.Name)).ForMember(v => v.CategoryId, vd => vd.MapFrom(vid => vid.Category.Id)).ForMember(v => v.VideoCard, vd => vd.MapFrom(vid => vid.Requirement.VideoCard))).CreateMapper();

            return mapper.Map<Game, GameDTO>(game);
        }
        public void DeleteGame(int id)
        {
           var game= database.Games.Get(id);
            if(game!=null)
            {
                database.Games.Delete(id);
            }
            var requirement = database.Requirements.Get(id);
            if (requirement != null)
            {

                database.Requirements.Delete(id);
            }

            
            database.Save();
        }
        public void CreateGame(GameDTO game)
        {
            database.Games.Create(new Game { CategoryId = game.CategoryId, GameDescription = game.GameDescription, GameName = game.GameName, Price = game.Price });

            database.Requirements.Create(new Requirement {CPU=game.CPU,RAM=game.RAM,OperationSystem=game.OperationSystem,VideoCard=game.VideoCard,Id=game.Id});
            database.Save();
        }
        public void UpdateGame(GameDTO game)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GameDTO, Game>()).CreateMapper();
            var updg = mapper.Map<GameDTO, Game>(game);
            var mapper2 = new MapperConfiguration(cfg => cfg.CreateMap<GameDTO, Requirement>()).CreateMapper();
            var upreq = mapper2.Map<GameDTO, Requirement>(game);
            database.Requirements.Update(upreq);
            database.Games.Update(updg);
            database.Save();
        }
        public void Dispose()
        {
            database.Dispose();
        }
        public IEnumerable<GameDTO> Findgames(string searchtext)
        {
            if(searchtext==null)
            {

                var games = database.Games.GetAll();

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDTO>().ForMember(dto => dto.CPU,
                   src => src.MapFrom(b => b.Requirement.CPU)).ForMember(ram => ram.RAM, r => r.MapFrom(n => n.Requirement.RAM)).ForMember(opr => opr.OperationSystem,
                   sys => sys.MapFrom(ops => ops.Requirement.OperationSystem)).ForMember(v => v.Category, vd => vd.MapFrom(vid => vid.Category.Name)).ForMember(v => v.VideoCard, vd => vd.MapFrom(vid => vid.Requirement.VideoCard))).CreateMapper();

                return mapper.Map<IEnumerable<Game>, List<GameDTO>>(games);
            }
            else
            {


                var games = database.Games.FindGames(searchtext);

                var map = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDTO>().ForMember(dto => dto.CPU,
                 src => src.MapFrom(b => b.Requirement.CPU)).ForMember(ram => ram.RAM, r => r.MapFrom(n => n.Requirement.RAM)).ForMember(opr => opr.OperationSystem,
                 sys => sys.MapFrom(ops => ops.Requirement.OperationSystem)).ForMember(v => v.Category, vd => vd.MapFrom(vid => vid.Category.Name)).ForMember(v => v.VideoCard, vd => vd.MapFrom(vid => vid.Requirement.VideoCard))).CreateMapper();

                return map.Map<IEnumerable<Game>, List<GameDTO>>(games);
            }
        }
    }
}
