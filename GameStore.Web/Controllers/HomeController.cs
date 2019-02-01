using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using GameStore.BLL.DTO;
using GameStore.BLL.Infrastructure;
using GameStore.BLL.BusinessModels;
using GameStore.BLL.Services;
using GameStore.Web.Models;
using AutoMapper;
using System.Threading.Tasks;
using System.Web;
using GameStore.BLL.Interfaces;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PagedList.Mvc;
using PagedList;

namespace GameStore.Web.Controllers
{
    public class HomeController : Controller
    {

        IOrderService orderService;
        IGameService gameService;
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        public HomeController(IOrderService serv, IGameService game)
        {
            orderService = serv;
            gameService = game;
        }
        public ActionResult Index(int? page,string searchtext)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            
            ViewBag.SearchName = searchtext;

            var games = gameService.Findgames(searchtext).ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GameDTO, GameSearchModel>()).CreateMapper();
            var mapedgames = mapper.Map<IEnumerable<GameDTO>, List<GameSearchModel>>(games);


            if (Request.IsAjaxRequest())
            {          

                return /*Partial*/View(/*"GameList",*/ mapedgames.ToPagedList(pageNumber, pageSize));
            }


            return View(mapedgames.ToPagedList(pageNumber, pageSize));
           
            
        }


        public ActionResult MakeOrder(int? id)
        {
            try
            {
                GameDTO game = gameService.GetGame(id);
                var order = new OrderViewModel { Id= game.Id };

                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
                var orderDto = new OrderDTO { GameId = order.Id, Address = order.Address, PhoneNumber = order.PhoneNumber };
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View("~Views/Home/Index");
        }
        
      
    

    }
}