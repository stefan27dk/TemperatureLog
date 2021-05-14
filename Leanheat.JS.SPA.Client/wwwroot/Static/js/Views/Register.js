// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";
import * as Validate from "/static/js/validations/input_validations.js";


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
       <div name="registerContainer" class="inputContainer">

                <h4 class="title">Register</h4>
                <hr class="hrTitle">

        <diV class="colom">
        <div class="form-group">
            <label for="email">Email:</label>
            <input name="email" type="text" maxlength="25" id="email" class="form-control inputDark"  />
            <label id="emailValidation"></label>
        </div>



        <div class="form-group">
            <label for="password">Password: </label> <input name="showHidePass" value="true" type="checkbox" id="showHidePass"/>    
            <input name="password" type="password" minlenght="6" maxlength="40" id="password" class="form-control inputDark" />  
            <label id="passwordValidation"></label>
        </div>
     


        <div class="form-group">
            <label for="repeatPassword">Repeat Password:</label>
            <input type="password" maxlength="40" id="repeatPassword" class="form-control inputDark" />
            <label id="repeatPasswordValidation"></label>
        </div>

            

        <div class="form-group">
            <label for="firstname">FirstName:</label>
            <input name="firstname" type="text" maxlength="20" id="firstname" class="form-control inputDark" />
            <label id="firstNameValidation"></label>
        </div>



        <div class="form-group">
            <label for="lastname">LastName:</label>
            <input name="lastname" type="text" maxlength="20" id="lastname" class="form-control inputDark" />
            <label id="lastNameValidation"></label>
        </div>



        <div class="form-group">
            <label for="age">Age:</label>
            <input name="age" type="text" maxlength="3" id="age" class="form-control inputDark" />
            <label is="ageValidation"></label>
        </div>


        <div class="form-group">
            <label for="phonenumber">Phonenumber:</label>
            <input name="phonenumber" type="text" maxlength="8" id="phonenumber" class="form-control inputDark" />
            <label id="phonenumberValidation"></label>
        </div>



        <div class="form-group">
            <label for="rememberMe" class="subTitle" >Remember Me:</label>
            <input name="rememberMe" value="true" type="checkbox" id="rememberMe" class="form-control inputDark" />
        </div>
             </div>

        <button name="triggerSubmit" type="submit" id="registerBtn"  class="blue-dark-button">Enter</button>    
           </div>
   </form>
            
          `;
    }


    // View Script ====================================================>
    async executeViewScript()
    {
        // ############################# Events #####################################
             
        // Email -----------------------------------------------------------------------------------------------------------------------
        document.getElementById('email').oninput = function () { return Validate.ValidateEmail(this) }; // Email




        // Password --------------------------------------------------------------------------------------------------------------------
        document.getElementById('showHidePass').onclick = function () { return Validate.ShowPassword(this, 'password', 'repeatPassword') }; // Show Hide Password
        let password = document.getElementById('password');
        password.oninput = function () { Validate.ValidateCurrentPasswordInput(this) }; // Password
        password.onchange = function () { Validate.ValidatePasswordCompare('password', 'repeatPassword') }; // Password Compare


        // Repeat Password
        let repeatPassword = document.getElementById('repeatPassword');
        repeatPassword.onchange = function () { return Validate.ValidatePasswordCompare('password', 'repeatPassword') }; // Repeat Password
        repeatPassword.oninput = function () { return Validate.ValidatePasswordCompare('password', 'repeatPassword') }; // Repeat Password on input




        // Firstname --------------------------------------------------------------------------------------------------------------------
        let firstname = document.getElementById('firstname');
        firstname.oninput = function () { return Validate.ValidateName(this) }; // Firstname
        firstname.onkeypress = function (event) { return Validate.LettersValidate(event); }; // Firstname - Prevent numbers



        // Lastname --------------------------------------------------------------------------------------------------------------------
        let lastname = document.getElementById('lastname');
        lastname.oninput = function () { return Validate.ValidateName(this) }; // Lastname
        lastname.onkeypress = function (event) { return Validate.LettersValidate(event); }; // Lastname - Prevent numbers



        // Age ---------------------------------------------------------------------------------------------------------------------------
        let age = document.getElementById('age');
        age.oninput = function () { return Validate.ValidateAge(this) }; // Age
        age.onkeypress = function (event) { return Validate.NumValidate(event); }; // Age - Prevent letters




        // Phonenumber --------------------------------------------------------------------------------------------------------------------
        let phonenumber = document.getElementById('phonenumber');
        phonenumber.oninput = function () { return Validate.ValidatePhoneNumber(this) }; // Phonenumber
        phonenumber.onkeypress = function (event) { return Validate.NumValidate(event); }; // Phonenumber - Prevent letters




        // Form ----------------------------------------------------------------------------------------------------------------------------
        var currForm = document.getElementById('registerForm'); // Get the Form
        currForm.onsubmit = function () { return Validate.UserFormIsValid(this.id) }; // On Submit



         


        // SUBMIT ==========================================================================================================================
        // Form - Submit -  EventListener --------------------------------------------------------------------------------------------------
        currForm.addEventListener('submit', function handler(e)
        {
            e.preventDefault(); // Prevent page reload on Submit  
            Validate.SubmitUserForm('registerForm', '/Account/Register?');  // Validate Form than Submit the form

            //this.removeEventListener('submit', handler); // Remove Event Listener 
        });
    }

}