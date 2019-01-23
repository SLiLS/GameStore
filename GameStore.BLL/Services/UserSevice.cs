using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BLL.Interfaces;
using GameStore.DAL.Interfaces;
using System.Threading;
using System.Security.Claims;
using GameStore.BLL.Infrastructure;
using GameStore.BLL.DTO;
using GameStore.BLL.Services;
using Microsoft.AspNet.Identity;
using GameStore.DAL.Entities;



namespace GameStore.BLL.Services
{
    public class UserSevice : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserSevice(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await Database.UserManager.CreateAsync(user, userDto.Password);
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
              
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");

            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }

            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }


}
