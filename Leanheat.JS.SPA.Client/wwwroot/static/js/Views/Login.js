// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";


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
                    <form id="loginForm" onsubmit="return ValidateLogin(this.id)" class="inputContainer">
                      <div name="loginContainer" >

                           <h4 class="title">Login</h4>
                           <hr class="hrTitle">

                        <diV class="colom">
                        
                                <div class="form-group">
                                    <label for="email">Email:</label>
                                    <input name="email" type="text" oninput="ValidateEmail(this)" maxlength="25" id="emailLogin" class="form-control inputDark"  />
                                    <label id="emailValidation"></label>
                                </div>
                                
                                
                                
                                <div class="form-group">
                                    <label for="password">Password: </label> <input name="showHidePass" value="true" type="checkbox" onclick="ShowPassword(this, 'passwordLogin', '')" id="showHidePass"/>    
                                    <input name="password" type="password" oninput="ValidateLoginPasswordInput(this)" minlenght="6" maxlength="40" id="passwordLogin" class="form-control inputDark" />  
                                    <label id="passwordValidation"></label>
                                </div>
                        </div>
                               <button name="triggerSubmit" type="submit" id="loginBtn" onmousedown="javascript:SubmitLogin('loginForm')"  class="blue-dark-button">Enter</button>    
                      </div>
                    </form>   
                  `;
    }

}