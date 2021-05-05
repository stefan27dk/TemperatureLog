

function registerAccount() {

    const registerForm = document.getElementById('registerForm'); // Get the Form


    registerForm.addEventListener('submit', function handler(e) {
        e.preventDefault(); // Prevent page reload on Submit  

        LoadingMsg(); // Show Loading Message

        const formData = new FormData(this); // "this" = this Form
        const searchParams = new URLSearchParams(formData); // Get the form data params  
        let formQueryString = searchParams.toString(); // Get the form data params as string

        // https://simonplend.com/how-to-use-fetch-to-post-form-data-as-json-to-your-api/

        // POST
        fetch(identityApiUri + '/Account/Register?' + formQueryString,
            {    
                method: 'POST' 
                
            }).then(function (response)
               {
                 // IF OK                       
                   if (response.status == 201) // Status 201 = "Created"
                   {
                     RemoveLoadingMsg();
                     SuccessMsg("Success");
                       this.registerForm.reset(); // Reset the Form    
                       return;
                   }
                   else // If Bad STATUS
                   {
                       console.log("Register Error - Could not register");
                       return Promise.reject(response);  // Triggers Catch method
                   }
               
               }).catch(function (err) // CATCH
                  {
                  RemoveLoadingMsg();
                  // Handle error here
                  console.warn('Post Exception:', err);
               });

        this.removeEventListener('submit', handler); // Remove Event Listener 
    });

}