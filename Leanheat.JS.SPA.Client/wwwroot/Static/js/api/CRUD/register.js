

    function registerAccount() {
    
         const registerForm = document.getElementById('registerForm'); // Get the Form

       
        registerForm.addEventListener('submit', function (e)
        {
            e.preventDefault(); // Prevent page reload on Submit  

            LoadingMsg(); // Show Loading Message
        
            const formData = new FormData(this); // "this" = this Form
            const searchParams = new URLSearchParams(formData); // Get the form data params  
            let formQueryString = searchParams.toString(); // Get the form data params as string


            // POST
            fetch(identityApiUri+'/Account/Register?'+formQueryString, {
                method: 'post'
            }).then(function (response) {    

                // IF OK                       
                if (response.status == 201) { // Status 201 = "Created"
                    RemoveLoadingMsg();
                    SuccessMsg("Success");
                    this.registerForm.reset(); // Reset the Form
                    //return response.json();
                }
                else // If Bad STATUS
                {
                    RemoveLoadingMsg(); // Remove Loading Message
                    alert("BAD!!!");
                    console.log("Register Error - Could not register");
                    Promise.reject(response);
                }
        
            }).then(function (responceData) // Responce DATA
            {
                console.log("ResponceData!!!!!" + responceData);
        
                // Responce data--->
        
            }).catch(function (err) // CATCH
            {
                // Handle error here
                alert("Exception!!!!!!!!!!"+err);
                console.warn('Post Exception:', err);
            });
        
        });
    
    }