import { GetUserEmail} from "/static/js/api/crud/get.js";
import { Logout } from "/static/js/api/crud/post.js";



// ================================ || Route to View || ===========================================================
export async function routeTo(localPath) { window.history.replaceState({}, '', localPath) }; // Route to any local SPA Link - used  with data-link decoration on the element- Used for ex. Function - Add Link to the img




// ================================ || Get User Email || ===========================================================
export async function GetUserEmailAsString()
{
     let resPrommise = await GetUserEmail(); // #1 - Responce from the fetch api
     var userEmail = '';
    // # 2 - Extract the Email from the Response
    userEmail = await resPrommise.json().then(content => // Check the response content
    {
        if (content != null) {
            return content['email']; // Return email from the responce
        }
        return '';
    });
    return userEmail;
}






// ================================ || Update User State - HTMl - Show Hide Login - Register etc. || ===========================================================
export async function UpdateUserHtml()
{
    
    let userEmail = await GetUserEmailAsString(); // Get User if logged in
    var userContainer = document.getElementById('userHtml'); // # Get the User Html - container

    if (userEmail!='') // If Not Logged In
    {
       userContainer.innerHTML = 
           `<a id="profile" href="/Profile" class="barItem " onclick="" data-link> <img id="profileImg" class="icon-img" src="img/TopBar/user-icon.png" data-link/> ${userEmail}</a>
           <a id="logout" class="barItem " href=""> <img class="icon-img" src="img/TopBar/logout-icon.png"/>Log Out</a >`;

        document.getElementById('profileImg').onclick = function () { routeTo('/Profile') }; // Add Link to the img
        document.getElementById('logout').onclick = function () { return Logout(this, event); }; // Log Out Event ONCLICK
    }
    else // If Logged In
    {
        userContainer.innerHTML = '<a href="/Register" class="barItem " data-link> <img id="registerImg" class="icon-img" src="img/TopBar/register-icon.png" data-link/> Register</a> <a href = "/Login" class="barItem "  data-link> <img class="icon-img" id="loginImg" src="img/TopBar/login-icon.png"  data-link />Log In</a>';
        document.getElementById('loginImg').onclick = function () { routeTo('/Login') }; // Add Link to the img
        document.getElementById('registerImg').onclick = function () { routeTo('/Register') }; // Add Link to the img
    }     
}











// ================================ || Format Date Picker || ===========================================================
export function GetFormatedDate(datePickerID)
{
    let rawDate = document.getElementById(datePickerID).value; // Get the Raw Date
    return rawDate.split('-').reverse().join("-"); // Reverse the date
}
           