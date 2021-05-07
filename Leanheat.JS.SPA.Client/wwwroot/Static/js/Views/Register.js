// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";


// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor() {   
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Register");
    }



    // Get Html ====================================================>
    async getHtml() {
        return `

      <form id="registerForm">
       <div name="register" class="inputContainer">

                <h4 class="title">Register</h4>
                <hr class="hrTitle">

        <diV class="colom">
        <div class="form-group">
            <label for="email">Email:</label>
            <input name="email" type="text" onchange="ValidateEmail(this)" maxlength="25" id="email" class="form-control inputDark"  />
            <label id="emailValidation"></label>
        </div>



        <div class="form-group">
            <label for="password">Password: </label> <input name="showHidePass" value="true" type="checkbox" onclick="ShowPassword(this, 'password', 'repeatPassword')" id="showHidePass"/>    
            <input name="password" type="password" minlenght="6" maxlength="40" id="password" class="form-control inputDark" />  
            <label id="passwordValidation"></label>
        </div>
     


        <div class="form-group">
            <label for="repeatPassword">Repeat Password:</label>
            <input type="password" onchange="ValidatePassword('password', 'repeatPassword')" maxlength="40" id="repeatPassword" class="form-control inputDark" />
            <label id="repeatPasswordValidation"></label>
        </div>

            

        <div class="form-group">
            <label for="firstname">FirstName:</label>
            <input name="firstname" type="text" onchange="ValidateName(this)" onkeypress="return LettersValidate(event)" maxlength="20" id="firstname" class="form-control inputDark" />
            <label id="firstNameValidation"></label>
        </div>



        <div class="form-group">
            <label for="lastname">LastName:</label>
            <input name="lastname" type="text" onchange="ValidateName(this)"  onkeypress="return LettersValidate(event)" maxlength="20" id="lastname" class="form-control inputDark" />
            <label id="lastNameValidation"></label>
        </div>



        <div class="form-group">
            <label for="age">Age:</label>
            <input name="age" type="text" onchange="ValidateAge(this)" onkeypress="return NumValidate(event)" maxlength="3" id="age" class="form-control inputDark" />
            <label is="ageValidation"></label>
        </div>


        <div class="form-group">
            <label for="phonenumber">Phonenumber:</label>
            <input name="phonenumber" type="text" onchange="ValidatePhoneNumber(this)" onkeypress="return NumValidate(event)" maxlength="8" id="phonenumber" class="form-control inputDark" />
            <label id="phonenumberValidation"></label>
        </div>



        <div class="form-group">
            <label for="rememberMe" class="subTitle" >Remember Me:</label>
            <input name="rememberMe" value="true" type="checkbox" id="rememberMe" class="form-control inputDark" />
        </div>
             </div>

        <button type="submit" id="registerBtn" onkeypress="javascript:registerAccount('registerForm','/Account/Register?');" onmousedown="javascript:registerAccount('registerForm','/Account/Register?'); " class="blue-dark-button">Enter</button>    
           </div>
   </form>
            
          `;
    }

}