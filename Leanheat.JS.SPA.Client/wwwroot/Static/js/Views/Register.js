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
                  <div name="reg" class="inputContainer">


        <div class="form-group">
            <label>Email:</label>
            <input type="text" maxlength="25" id="Email" class="form-control inputDark" />
            <label id="emailValidation"></label>
        </div>



        <div class="form-group">
            <label>Password:</label>
            <input type="text" maxlength="40" id="Password" class="form-control inputDark" />
            <label id="passwordValidation"></label>
        </div>



        <div class="form-group">
            <label>Repeat Password:</label>
            <input type="text" maxlength="40" id="RepeatPassword" class="form-control inputDark" />
            <label id="repeatPasswordValidation"></label>
        </div>



        <div class="form-group">
            <label>FirstName:</label>
            <input type="text" maxlength="20" id="FirstName" class="form-control inputDark" />
            <label id="firstNameValidation"></label>
        </div>



        <div class="form-group">
            <label>LastName:</label>
            <input type="text" maxlength="20" id="LastName" class="form-control inputDark" />
            <label id="lastNameValidation"></label>
        </div>



        <div class="form-group">
            <label>Age:</label>
            <input type="text" maxlength="3" id="Age" class="form-control inputDark" />
            <label is="ageValidation"></label>
        </div>


        <div class="form-group">
            <label>Phonenumber:</label>
            <input type="text" maxlength="8" id="Phonenumber" class="form-control inputDark" />
            <label id="phonenumberValidation"></label>
        </div>



        <div class="form-group">
            <label>Remember Me:</label>
            <input type="checkbox" id="RememberMe" class="form-control inputDark" />
        </div>


        <button type="submit" class="buttonStyle1">Enter</button>    
          `;
    }

}