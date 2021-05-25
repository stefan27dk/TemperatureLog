import { GetUserEmail} from "/static/js/api/crud/get.js";
import { Logout } from "/static/js/api/crud/post.js";
 

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
    if (userEmail!='')
    {
       userContainer.innerHTML = 
           `<a id="profile" href="/Profile" onclick="" data-link>${userEmail}</a>
           <a id="logout" href=""> Log Out</a >`;
        document.getElementById('logout').onclick = function () { return Logout(this, event);}; // Log Out Event ONCLICK
    }
    else
    {
        userContainer.innerHTML =
            `<a href="/Register" onclick="" data-link>Register</a>
                    <a href="/Login" onclick="" data-link>Log In</a>`;
    }
}







