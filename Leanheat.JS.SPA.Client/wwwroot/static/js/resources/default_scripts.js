

// ================================ || Update User State - HTMl - Show Hide Login - Register etc. || ===========================================================
async function UpdateUserHtml()
{
    var resPrommise = await GetUser(); // #1 - Responce from the fetch api
    var user = '';

    // # 2 - Extract the Email from the Response
    user = await resPrommise.json().then(content => // Check the response content
    {
        if (content != null)
        {
            return content['email']; // Return email from the responce
        }
        return '';
    });


    var userContainer = document.getElementById('userHtml');  
    if (user!='')
    {
       userContainer.innerHTML = 
           `<a href="/Profile" onclick="" data-link>${user}</a>
           <span onclick = "Logout(this);"> Log Out</span >`;
    }
    else
    {
        userContainer.innerHTML =
            `<a href="/Register" onclick="" data-link>Register</a>
                    <a href="/Login" onclick="" data-link>Log In</a>`;
    }
}



