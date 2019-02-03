using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.BLL.Infrastructure;
using GameStore.BLL.Services;
using GameStore.BLL.Interfaces;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.Web.Models;
using PagedList;
using System.Data.Entity;


namespace GameStore.Web.Controllers.AdminControllers
{
    [Authorize(Roles ="admin")]
    public class GameController : Controller
    {
        IGameService gameService;
        ICategoryService categoryService;
        public GameController( IGameService game, ICategoryService category)
        {
            gameService = game;
            categoryService = category;
        }
        public ActionResult Index(int? page, string searchtext)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            ViewBag.SearchName = searchtext;

            var games = gameService.Findgames(searchtext).ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GameDTO, GameSearchModel>().ForMember(dto => dto.GameCategory, c => c.MapFrom(gc => gc.Category))).CreateMapper();
            var mapedgames = mapper.Map<IEnumerable<GameDTO>, List<GameSearchModel>>(games);


            if (Request.IsAjaxRequest())
            {

                return PartialView("GameList", mapedgames.ToPagedList(pageNumber, pageSize));
            }


            return View(mapedgames.ToPagedList(pageNumber, pageSize));
        }
       [HttpGet]
        public ActionResult Add()
        {
            //CreateGameModel gameModel = new CreateGameModel { Categories = new SelectList(categoryService.GetCategories(), "Id", "Name") };
            ViewBag.CreateCategory = new SelectList(categoryService.GetCategories(), "Id", "Name");
            return PartialView();

        }
        [HttpPost]
        public ActionResult Add(GameViewModel gameview)
        {
            
            if(ModelState.IsValid)
            {

                GameDTO gamedto = new GameDTO
                {
                    CPU = gameview.CPU,

                    GameDescription = gameview.GameDescription,
                    CategoryId = gameview.CategoryId,
                    GameName = gameview.GameName,
                    VideoCard = gameview.VideoCard,
                    RAM = gameview.RAM,
                    OperationSystem = gameview.OperationSystem,
                    Price = gameview.Price

                };
                gameService.CreateGame(gamedto);
                
                
            }
            else
            {
                ModelState.AddModelError("", "incorrect data");
            }
            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           GameDTO gamedto= gameService.GetGame(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GameDTO, GameViewModel>()).CreateMapper();
            GameViewModel gameview = mapper.Map<GameDTO, GameViewModel>(gamedto);
            ViewBag.EditCategory = new SelectList(categoryService.GetCategories(), "Id", "Name");
            return PartialView(gameview);
        }
        [HttpPost]
        public ActionResult Edit(GameViewModel game)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GameViewModel, GameDTO>()).CreateMapper();
            GameDTO gameDTO = mapper.Map<GameViewModel, GameDTO>(game);
            gameService.UpdateGame(gameDTO);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            gameService.DeleteGame(id);
            return RedirectToAction("Index");
        }



    }
}