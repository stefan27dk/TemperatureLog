import * as msg from "/static/js/components/messages.js";
import * as defaultScripts from "/static/js/resources/default_scripts.js";




// ============== || Register, Login, Update - POST || =======================================================================================
export async function IdentityPost(formID, postUrl) {

     
    const currForm = document.getElementById(formID); // Get the Form
    var submitBtn = currForm.elements.namedItem("triggerSubmit"); // Get the submit button of the form
    
     
        submitBtn.disabled = true; // Disable the submit button

        msg.LoadingMsg(); // Show Loading Message

        // Get form data as string---------------------------------------------------------------
        const formData = new FormData(currForm); // "this" = this Form
        const searchParams = new URLSearchParams(formData); // Get the form data params  
        let formQueryString = searchParams.toString(); // Get the form data params as string

      


        // POST ----------------------------------------------------------------------------------
       fetch(identityApiUri + postUrl + formQueryString,  // #1 = API-Address, #2 = API - Controller/Mehod, #3 = form data as sring
            {    
                method: 'POST',
                mode: 'cors',
                credentials: 'include' // Allows to return the Cookies with the responce // The Cors should be also set up at the server
                
            }).then(function (response)
               {  
                    // IF OK                       
                if (response.status == 200 || response.status == 201) // Status 201 = "Created"
                {
                       defaultScripts.UpdateUserHtml(); // Update the User Html - user optiona at the topbar
                       msg.RemoveLoadingMsg();
                       msg.SuccessMsg("Success");
                       currForm.reset();  // Reset the  form
                       submitBtn.disabled = false; // Enable Submit button
                       
                   
                    //window.history.replaceState({}, '', window.prevUrl);
                    //window.navigate(window.prevUrl);  // Use navigate method from index.js
                    //history.back(); // Go back to previouse page        
                 }
                   else // If Bad STATUS
                   {
                     return Promise.reject(response);  // Triggers Catch method
                   }
                
               }).catch(function (err) // If Exception
               {
                   msg.RemoveLoadingMsg(); 
                   // Show Error
                       try // Because of JSON Parse and err.text()
                       {
                          err.text().then(errorMessage => {
                               var error = errorMessage.substring(1, errorMessage.length - 1); // Remove the [..] form the Msg
                               msg.ErrorMsg(error); // Get the error and display
                          });
                       }
                       catch(e)
                       {
                           console.warn("Post Exception -  Probably No connection to hte server");
                           msg.ErrorMsg(err + " No connection to the server"); // Get the error and display
                       }

                   submitBtn.disabled = false; // Enable Submit button
                   console.warn('Post Exception:', err);
               });
                    
       
}






















// ============== || Logout - POST || =======================================================================================
function Logout(logoutbtn, event)
{
    event.preventDefault();
    LoadingMsg(); // Show Loading Message
    logoutbtn.disabled = true; // Disable the Logout Button

    // POST ----------------------------------------------------------------------------------
   fetch(identityApiUri + '/Account/LogOut',   
        {
            method: 'POST',
            mode: 'cors',
            credentials: 'include' // Allows to return the Cookies with the responce // The Cors should be also set up at the server

        }).then(function (response) {
            // IF OK                       
            if (response.status == 200)
            {
                UpdateUserHtml();
                RemoveLoadingMsg();
                SuccessMsg("Logged Out");
                logoutbtn.disabled = false; // Enable the Logout Button
            }
            else // If Bad STATUS
            {
                return Promise.reject(response);  // Triggers Catch method
            }

        }).catch(function (err) // If Exception
        {
            RemoveLoadingMsg();
            // Show Error
            try // Because of JSON Parse and err.text()
            {
                err.text().then(errorMessage => {
                    var error = errorMessage.substring(1, errorMessage.length - 1); // Remove the [..] form the Msg
                    ErrorMsg(error); // Get the error and display
                });
            }
            catch (e) {
                console.warn("Post Exception -  Probably No connection to hte server");
                ErrorMsg(err + " - No connection to the server"); // Get the error and display
            }

            logoutbtn.disabled = false; // Enable Submit button
            console.warn('Post Exception:', err);
        });
     
}












            