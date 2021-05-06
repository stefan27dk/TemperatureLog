

function registerAccount(formID, postUrl) {

     
    const currForm = document.getElementById(formID); // Get the Form
    var submitBtn = currForm.querySelector('button[type="submit"]'); // Get the submit button of the form
    
     // Listen for Form- Submit 
    currForm.addEventListener('submit', function handler(e) {
        e.preventDefault(); // Prevent page reload on Submit  
        submitBtn.disabled = true; // Disable the button

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
                     return;
                   }
                   else // If Bad STATUS
                   {
                       //RemoveLoadingMsg();
                       //ErrorMsg(response.json().);
                       //submitBtn.disabled = false; // Enable Submit button
                       //console.log("Register Error - Could not register");
                     return Promise.reject(response);  // Triggers Catch method
                   }
                
               }).catch(function (err) // CATCH
               {
                   err.text().then(errorMessage => {
                       var jsonErrString = errorMessage.substring(1, errorMessage.length - 1); // Remove the [..] form the Msg
                       var obj = JSON.parse(jsonErrString); // Make the msg JSON
                       ErrorMsg(obj["description"]); // Get the error and display
                   });

                   submitBtn.disabled = false; // Enable Submit button
                   RemoveLoadingMsg();
                   //ErrorMsg(err);
                  console.warn('Post Exception:', err);
               });
                    
        this.removeEventListener('submit', handler); // Remove Event Listener 
    });

}