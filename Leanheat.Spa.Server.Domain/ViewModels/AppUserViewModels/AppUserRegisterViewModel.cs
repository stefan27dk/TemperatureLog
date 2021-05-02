using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanheat.Spa.Server.Domain.ViewModels.AppUserViewModels
{
    public class AppUserRegisterViewModel
    {
        // ==== [Email] ==============================================================================================================================
        [Required(ErrorMessage = "Email is requered")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not valid")]  // Custom Email Validation
        public string Email { get; set; }



        // ==== [Firstname] ==========================================================================================================================
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ]+$", ErrorMessage = "Firstname - only letters are allowed")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Firstname - Min 2 letters and max 20 letters")]
        public string FirstName { get; set; }



        // ==== [Lastname] ===========================================================================================================================
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ]+$", ErrorMessage = "Lastname - only letters are allowed")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Lastname - Min 2 letters and max 20 letters")]
        public string LastName { get; set; }



        // ==== [Password] ===========================================================================================================================
        [Required(ErrorMessage = "Password is requered")]
        [RegularExpression(@"^\S{6,40}$", ErrorMessage="Password should be min 6 characters")]  // Allow all chars exept spaces,tabs etc.  min 6 and max 40 chars
        public string Password { get; set; }



        // ==== [Repeat - Password] ==================================================================================================================
        [Required(ErrorMessage = "Repeat Password is requered")]
        [CompareProperty("Password", ErrorMessage = "Password does not match")]
        public string RepeatPassword { get; set; }



        // ==== [Age] ================================================================================================================================
        [RegularExpression(@"/^\S[0-9]{0,3}$/")]
        public string Age { get; set; }



        // ==== [Phonenumber] ========================================================================================================================
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Phonenumber - Min 8 digits")]
        public string Phonenumber { get; set; }



        // ==== [RememberMe] =========================================================================================================================
        public bool RememberMe { get; set; }
    }
}
