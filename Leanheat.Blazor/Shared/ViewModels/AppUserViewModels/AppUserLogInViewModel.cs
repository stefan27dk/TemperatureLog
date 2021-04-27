using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Blazor.Shared.ViewModels.AppUserViewModels
{
    public class AppUserLogInViewModel
    {
        // ==== [Email] ==============================================================================================================================
        [Required(ErrorMessage = "Email is requered")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not valid")]  // Custom Email Validation
        public string Email { get; set; }

      

        // ==== [Password] ===========================================================================================================================
        [Required(ErrorMessage = "Password is requered")]
        [RegularExpression(@"^\S{6,40}$", ErrorMessage = "Password should be min 6 characters")]  // Allow all chars exept spaces,tabs etc.  min 6 and max 40 chars
        public string Password { get; set; }



        // ==== [Repeat - Password] ==================================================================================================================
        [Required(ErrorMessage = "Repeat Password is requered")]  
        [CompareProperty("Password", ErrorMessage = "Password does not match")]
        public string RepeadPassword { get; set; }


        

        // ==== [RememberMe] =========================================================================================================================
        public bool RememberMe { get; set; }
    }
}
