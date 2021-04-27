using Leanheat.Blazor.Shared.ViewModels.AppUserViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Blazor.Server.Application.Interfaces
{
    public interface IApplicationUserService
    {
        public  Task<IActionResult> Register(AppUserRegisterViewModel user);
        public  Task<IActionResult> LogIn(AppUserLogInViewModel user);
        public  Task<IActionResult> LogOut();
        public  Task<AppUserGetViewModel> GetCurrentUser(AppUserGetViewModel user);
        public  Task<IActionResult> UpdateUser(AppUserUpdateViewModel user);
        public  Task<IActionResult> DeleteLogIn(string email);
    }
}
