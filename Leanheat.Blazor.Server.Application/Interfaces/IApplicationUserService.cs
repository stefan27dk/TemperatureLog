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
        public  Task<IActionResult> Register(string firstname, string lastname, string email, string age, string phonenumber, string password, bool rememberMe);
        public  Task<IActionResult> LogIn(string email, string password, bool rememberMe);
        public  Task<IActionResult> LogOut();
        public  Task<IActionResult> GetCurrentUser();
        public  Task<IActionResult> UpdateUser(string firstName, string lastName, string email, string age, string phonenumber, string password);
        public  Task<IActionResult> DeleteLogIn(string email);
    }
}
