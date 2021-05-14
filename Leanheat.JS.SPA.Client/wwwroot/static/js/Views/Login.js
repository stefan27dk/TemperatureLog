// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";
import { ValidateEmail, ShowPassword, ValidateLoginPasswordInput, ValidateLogin, SubmitLogin } from "/static/js/validations/input_validations.js";

 
// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor() {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Login");
    }



    // Get Html ====================================================>
    async getHtml() {
        return `
                    <form id="loginForm" class="inputContainer">
                      <div name="loginContainer" >

                           <h4 class="title">Login</h4>
                           <hr class="hrTitle">

                        <diV class="colom">
                        
                                <div class="form-group">
                                    <label for="email">Email:</label>
                                    <input name="email" type="text" maxlength="25" id="emailLogin" class="form-control inputDark"  />
                                    <label id="emailValidation"></label>
                                </div>
                                
                                
                                
                                <div class="form-group">
                                    <label for="password">Password: </label> <input name="showHidePass" value="true" type="checkbox" id="showHidePassLogin"/>    
                                    <input name="password" type="password" minlenght="6" maxlength="40" id="passwordLogin" class="form-control inputDark" />  
                                    <label id="passwordValidation"></label>
                                </div>

                               
                                 <div class="form-group">
                                     <label for="rememberMe" class="subTitle">Remember Me:</label>
                                     <input name="rememberMe" value="true" type="checkbox" id="rememberMe" class="form-control inputDark" />
                                 </div>
                        </div>
                               <button name="triggerSubmit" type="submit" id="loginBtn" class="blue-dark-button">Enter</button>    
                      </div>
                    </form>   
                  `;
    }

    async executeViewScript()
    {
        // ############################# Events #####################################

        // Email -----------------------------------------------------------------------------------------------------------------------
        document.getElementById('emailLogin').oninput = function () { return ValidateEmail(this) }; // Email


        // Password --------------------------------------------------------------------------------------------------------------------
        document.getElementById('showHidePassLogin').onclick = function () { return ShowPassword(this, 'passwordLogin', '') }; // Show Hide Password
        let password = document.getElementById('passwordLogin');
        password.oninput = function () { ValidateLoginPasswordInput(this) }; // Password



        // Form ----------------------------------------------------------------------------------------------------------------------------
        var currForm = document.getElementById('loginForm'); // Get the Form
        currForm.onsubmit = function () { return ValidateLogin(this.id) }; // On Submit



        // SUBMIT ==========================================================================================================================
        currForm.addEventListener('submit', function handler(e) {
            e.preventDefault(); // Prevent page reload on Submit  
            SubmitLogin('loginForm', '/Account/LogIn?');  // Validate Form than Submit the form

            //this.removeEventListener('submit', handler); // Remove Event Listener 
        });
    }
}