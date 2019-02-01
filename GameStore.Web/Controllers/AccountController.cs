using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using GameStore.Web.Models;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using GameStore.BLL.Infrastructure;
using GameStore.BLL.Interfaces;
using System.Security.Claims;
using GameStore.BLL.DTO;


namespace GameStore.Web.Controllers
{
    public class AccountController : Controller
        {
        
        public IUserService UserService;
        public IOrderService OrderService;

        public AccountController(IUserService userService, IOrderService orderService)
        {
            UserService = userService;
            OrderService = orderService;
           
        }


        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public  ActionResult Login()
        {
            return  View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = viewModel.Email, Password = viewModel.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                    ModelState.AddModelError("", "Неверный логин или пароль");
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                  
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(viewModel);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();

        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel viewModel)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO
                {
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    Role = "user"

                };
                OperationDetails operationDetails = await UserService.Create(user);

                if (operationDetails.Succedeed)
                {
                  
                    return View("SuccessRegister");
                }
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }

            return View(viewModel);
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "raf",
                UserName = "Slils",
                Password = "123456",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }


    }
}