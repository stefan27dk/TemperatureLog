using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leanheat.Identity.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        // ==== [Firstname] =============================================================================  
        public string FirstName { get; private set; }



        // ==== [Lastname] ================================================================================  
        public string LastName { get; private set; }



        // ==== [Age] ======================================================================================  
        public int Age { get; private set; }








        public IdentityResult SetUserData(string firstName, string lastName, string email, string age, string phonenumber, string password)
        {
            // FirstName
            if (firstName != null) 
            {
                var result = SetFirstName(firstName);
                if (result != IdentityResult.Success)
                {
                    return result; 
                }
            }





            // LastName
            if (lastName != null) 
            {
              var result = SetLastName(lastName);
                if (result != IdentityResult.Success)
                {
                    return result;
                }
            }





            // Email
            if (email != null) 
            {
                var result = SetEmail(email);
                if (result != IdentityResult.Success)
                {
                    return result;
                }
            }





            // PhoneNumber
            if (phonenumber != null) 
            {
                var result = SetPhoneNumber(phonenumber);
                if (result != IdentityResult.Success)
                {
                    return result;
                }
            }





            // Age
            if (age != null) 
            {
                var result = SetAge(age);
                if (result != IdentityResult.Success)
                {
                    return result;
                }
            }





            // Password
            if (password != null)
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                var newHashedPassword = passwordHasher.HashPassword(this, password);
                this.PasswordHash = newHashedPassword;
            }

            return IdentityResult.Success;
        }








        // ==== ::############# [Setter Methods] ############# :: ====================================================================== 

        // ==== [Set Email] =================================================================================
        public IdentityResult SetEmail(string email)
        {
            if(EmailIsValid(email))
            {
                this.Email = email;
                this.UserName = email;
                this.NormalizedEmail = email.ToUpper();
                this.NormalizedUserName = email.ToUpper();
                return IdentityResult.Success;
            }

            return IdentityResult.Failed(new IdentityError[] {new IdentityError { Code = "Err1", Description = "Email is not Valid" }});
        }






        // ==== [Set FirstName] =================================================================================
        public IdentityResult SetFirstName(string firstname)
        {
            if (FirstNameIsValid(firstname))
            {
               this.FirstName = firstname;
               return IdentityResult.Success;
            }

            return IdentityResult.Failed(new IdentityError[] { new IdentityError { Code = "Err2", Description = "Firstname is not Valid - Min 2 Letters and Max 20 letters" } });
        }







        // ==== [Set LastName] =================================================================================
        public IdentityResult SetLastName(string lastname)
        {
            if (LastNameIsValid(lastname))
            {
                this.LastName = lastname;
                return IdentityResult.Success;
            }

            return IdentityResult.Failed(new IdentityError[] { new IdentityError { Code = "Err3", Description = "Lastname is not Valid - Min 2 Letters and Max 20 letters" } });
        }







        // ==== [Set Age] =================================================================================
        public IdentityResult SetAge(string age)
        {
            if (AgeIsValid(age))
            {
                this.Age = int.Parse(age);
                return IdentityResult.Success;
            }

            return IdentityResult.Failed(new IdentityError[] { new IdentityError { Code = "Err5", Description = "Not a valid Age  Min 0 and Max 200" } });
        }







        // ==== [Set PhoneNumber] =================================================================================
        public IdentityResult SetPhoneNumber(string phonenumber)
        {
            if (PhoneNumberIsValid(phonenumber))
            {
                this.PhoneNumber = phonenumber;
                return IdentityResult.Success;
            }

            return IdentityResult.Failed(new IdentityError[] { new IdentityError { Code = "Err4", Description = "Not valid phonenumber - Min / Max 8 digits a" } });
        }

















        // ==== ::############# [Validation Methods] ############# :: ====================================================================

        // ==== [EMAIL Validation] ============================================================================  
        private bool EmailIsValid(string email)
        {
            if (Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                return true;
            }
                return false;
        }






        // ==== [FirstName Validation] ============================================================================  
        private bool FirstNameIsValid(string firstname)
        {
            if (firstname.Length > 1 && firstname.Length <= 20)
            {
                return true;
            }
            return false;
        }






        // ==== [LastName Validation] ============================================================================  
        private bool LastNameIsValid(string lastname)
        {
            if (lastname.Length > 0 && lastname.Length <= 20)
            {
                return true;
            }
            return false;
        }






        // ==== [Age Validation] ============================================================================  
        private bool AgeIsValid(string age)
        {
            int theAge;
            if(int.TryParse(age, out theAge) &&  (theAge >= 0 && theAge < 200))
            {
                return true;
            }
            return false;
        }







        // ==== [PhoneNumber Validation] ============================================================================  
        private bool PhoneNumberIsValid(string phonenumber)
        {
            if (phonenumber.Length == 7 && int.TryParse(phonenumber, out int output))
            {
                return true;
            }
            return false;
        }

    }
}
