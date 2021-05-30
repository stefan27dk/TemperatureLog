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

    if (userEmail!='') // If Not Logged In
    {
       userContainer.innerHTML = 
           `<a id="profile" href="/Profile" class="topBarItem" onclick="" data-link> <img class="icon-img" src="img/TopBar/user-icon.png"/> ${userEmail}</a>
           <a id="logout" class="topBarItem" href=""> <img class="icon-img" src="img/TopBar/logout-icon.png"/>Log Out</a >`;
        document.getElementById('logout').onclick = function () { return Logout(this, event);}; // Log Out Event ONCLICK
    }
    else // If Logged In
    {
        userContainer.replaceChildren(); // Remove All children

        // Shared
        let aTag = document.createElement('a');
        aTag.className = "topBarItem";
        aTag.setAttribute("data-link", "");


        // Register - Create A Tag 
        let registerATag = aTag.cloneNode(true); //A Tag
        registerATag.href = "/Register";
        registerATag.text = "Register";



        // Login A - Create A Tag
        let loginATag = aTag.cloneNode(true);
        loginATag.href = "/Login";
        loginATag.text = "Log in";

        userContainer.append(registerATag, loginATag);

        // Why not .innerHtml - Because it slower and it breaks the SPA routing sometimes if the links are clicked fast - insertAdjacent is not working too for this job.
        //userContainer.insertAdjacentHTML('afterbegin', '<a href="/Register" class="topBarItem"   data-link><img class="icon-img" src="img/TopBar/register-icon.png" /> Register</a> <a href = "/Login" class="topBarItem"  data-link> <img class="icon-img" src="img/TopBar/login-icon.png"/>Log In</a>');
    }
}



     
           