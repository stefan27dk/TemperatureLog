﻿

function registerAccount(formID, postUrl) {

     
    const currForm = document.getElementById(formID); // Get the Form
    var submitBtn = currForm.elements.namedItem("triggerSubmit"); // Get the submit button of the form
    
     // Listen for Form- Submit 
    currForm.addEventListener('submit', function handler(e) {
        e.preventDefault(); // Prevent page reload on Submit  
        submitBtn.disabled = true; // Disable the submit button

        LoadingMsg(); // Show Loading Message

        // Get form data as string---------------------------------------------------------------
        const formData = new FormData(this); // "this" = this Form
        const searchParams = new URLSearchParams(formData); // Get the form data params  
        let formQueryString = searchParams.toString(); // Get the form data params as string

      


        // POST ----------------------------------------------------------------------------------
        fetch(identityApiUri + postUrl + formQueryString,  // #1 = API-Address, #2 = API - Controller/Mehod, #3 = form data as sring
            {    
                method: 'POST' 
                
            }).then(function (response)
               {
                    // IF OK                       
                   if (response.status == 201) // Status 201 = "Created"
                   {
                       RemoveLoadingMsg();
                       SuccessMsg("Success");
                       currForm.reset();  // Reset the  form
                       submitBtn.disabled = false; // Enable Submit button
                       
                       if (document.referrer.split('/')[2] === window.location.host) // Return to previous page if local 
                       {
                           history.back(); // Go back to previouse page
                       }
                       else
                       {
                           window.location.href = "/"; // RETURN TO home
                       }
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
                       catch(e)
                       {
                           console.warn("Post Exception -  Probably No connection to hte server");
                           ErrorMsg(err + " - Server is probably offline"); // Get the error and display
                       }

                   submitBtn.disabled = false; // Enable Submit button
                   console.warn('Post Exception:', err);
               });
                    
        this.removeEventListener('submit', handler); // Remove Event Listener 
    });

}