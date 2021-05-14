// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";
import * as Validate from "/static/js/validations/input_validations.js";
import { PopulateUpdateForm } from "/static/js/resources/default_scripts.js";


// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor() {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Profile");
    }



    // Get Html ====================================================>
    async getHtml() {
        return `
                    
        
 <form id="updateUserForm">
       <div name="registerContainer" class="inputContainer">

                <h4 class="title">Update</h4>
                <hr class="hrTitle">

        <diV class="colom">
        <div class="form-group">
            <label for="email">Email:</label>
            <input name="email" type="text" maxlength="25" id="updateEmail" class="form-control inputDark"  />
            <label id="emailValidation"></label>
        </div>



        <div class="form-group">
            <label for="password">Password: </label> <input name="showHidePass" value="true" type="checkbox" id="showHidePassUpdate"/>    
            <input name="password" type="password" minlenght="6" maxlength="40" id="updatePassword" class="form-control inputDark" />  
            <label id="passwordValidation"></label>
        </div>
     


        <div class="form-group">
            <label for="repeatPassword">Repeat Password:</label>
            <input name="repeatPassword" type="password"  maxlength="40" id="repeatPasswordUpdate" class="form-control inputDark" />
            <label id="repeatPasswordValidation"></label>
        </div>

            

        <div class="form-group">
            <label for="firstname">FirstName:</label>
            <input name="firstname" type="text" maxlength="20" id="firstnameUpdate" class="form-control inputDark" />
            <label id="firstNameValidation"></label>
        </div>



        <div class="form-group">
            <label for="lastname">LastName:</label>
            <input name="lastname" type="text" maxlength="20" id="lastnameUpdate" class="form-control inputDark" />
            <label id="lastNameValidation"></label>
        </div>



        <div class="form-group">
            <label for="age">Age:</label>
            <input name="age" type="text" maxlength="3" id="ageUpdate" class="form-control inputDark" />
            <label is="ageValidation"></label>
        </div>


        <div class="form-group">
            <label for="phonenumber">Phonenumber:</label>
            <input name="phonenumber" type="text" maxlength="8" id="phonenumberUpdate" class="form-control inputDark" />
            <label id="phonenumberValidation"></label>
        </div>
                  
             </div>

        <button name="triggerSubmit" type="submit" id="updateBtn" class="blue-dark-button">Enter</button>    
           </div>
   </form>
  
                  `;
                        
    }

    // View Script ====================================================>
    async executeViewScript()
    {

        // ############################# Events #####################################

        // Email -----------------------------------------------------------------------------------------------------------------------
        document.getElementById('updateEmail').oninput = function () { return Validate.ValidateEmail(this) }; // Email




        // Password --------------------------------------------------------------------------------------------------------------------
        document.getElementById('showHidePassUpdate').onclick = function () { return Validate.ShowPassword(this, 'updatePassword', 'repeatPasswordUpdate') }; // Show Hide Password
        let password = document.getElementById('updatePassword');
        password.oninput = function () { Validate.ValidateCurrentPasswordInput(this) }; // Password
        password.onchange = function () { Validate.ValidatePasswordCompare('updatePassword', 'repeatPasswordUpdate') }; // Password Compare


        // Repeat Password
        let repeatPassword = document.getElementById('repeatPasswordUpdate');
        repeatPassword.onchange = function () { return Validate.ValidatePasswordCompare('updatePassword', 'repeatPasswordUpdate') }; // Repeat Password
        repeatPassword.oninput = function () { return Validate.ValidatePasswordCompare('updatePassword', 'repeatPasswordUpdate') }; // Repeat Password on input




        // Firstname --------------------------------------------------------------------------------------------------------------------
        let firstname = document.getElementById('firstnameUpdate');
        firstname.oninput = function () { return Validate.ValidateName(this) }; // Firstname
        firstname.onkeypress = function (event) { return Validate.LettersValidate(event); }; // Firstname - Prevent numbers



        // Lastname --------------------------------------------------------------------------------------------------------------------
        let lastname = document.getElementById('lastnameUpdate');
        lastname.oninput = function () { return Validate.ValidateName(this) }; // Lastname
        lastname.onkeypress = function (event) { return Validate.LettersValidate(event); }; // Lastname - Prevent numbers



        // Age ---------------------------------------------------------------------------------------------------------------------------
        let age = document.getElementById('ageUpdate');
        age.oninput = function () { return Validate.ValidateAge(this) }; // Age
        age.onkeypress = function (event) { return Validate.NumValidate(event); }; // Age - Prevent letters




        // Phonenumber --------------------------------------------------------------------------------------------------------------------
        let phonenumber = document.getElementById('phonenumberUpdate');
        phonenumber.oninput = function () { return Validate.ValidatePhoneNumber(this) }; // Phonenumber
        phonenumber.onkeypress = function (event) { return Validate.NumValidate(event); }; // Phonenumber - Prevent letters




        // Form ----------------------------------------------------------------------------------------------------------------------------
        var currForm = document.getElementById('updateUserForm'); // Get the Form
        currForm.onsubmit = function () { return Validate.UserFormIsValid(this.id) }; // On Submit



        // GET - LOAD Data to the form from the API ==========================================================================================================================
        PopulateUpdateForm('updateUserForm');



        // SUBMIT ==========================================================================================================================
        // Form - Submit -  EventListener --------------------------------------------------------------------------------------------------
        currForm.addEventListener('submit', function handler(e) {
            e.preventDefault(); // Prevent page reload on Submit  
            Validate.SubmitUserForm('updateUserForm', '/Account/UpdateUser?');  // Validate Form than Submit the form

            //this.removeEventListener('submit', handler); // Remove Event Listener 
        });
    }
}