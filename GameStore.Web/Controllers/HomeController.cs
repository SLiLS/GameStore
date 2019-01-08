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
using System.Web;
using GameStore.BLL.Interfaces;
using System.Web.Mvc;

namespace GameStore.Web.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<GameDTO> gamedto = orderService.GetGames();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GameDTO, GameViewModel>()).CreateMapper();
            var games = mapper.Map<IEnumerable<GameDTO>, List<GameViewModel>>(gamedto);
            return View(games);
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                GameDTO game = orderService.GetGame(id);
                var order = new OrderViewModel { GameId= game.GameId };

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
                var orderDto = new OrderDTO { GameId = order.GameId, Address = order.Address, PhoneNumber = order.PhoneNumber };
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}