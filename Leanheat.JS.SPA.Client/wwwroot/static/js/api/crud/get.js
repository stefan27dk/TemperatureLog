



// ============== || Default - Get || =======================================================================================
export async function Get(address, path)
{
    return await fetch(address + path,
        {
            method: 'GET',
            mode: 'cors',
            credentials: 'include' // Allows to return the Cookies with the responce // The Cors should be also set up at the server

        }).then(function (response) {
            if (response.status == 200) // IF OK  
            {
                return response;
            }
            else // If Bad STATUS
            {
                return Promise.reject(response);  // Triggers Catch method
            }

        }).catch(function (err) // If Exception
        {
            // Show Error
            try // Because of err.text()
            {
                err.text().then(errorMessage => {
                    var error = errorMessage.substring(1, errorMessage.length - 1); // Remove the [..] form the Msg
                    console.error(error); // Get the error and display
                });
            }
            catch (e) {
                console.warn("Get User Exception -  Probably No connection to hte server");
                console.error(e); // Get the error and display
            }
            console.warn('Post Exception:', err);
        });
}















// ============== || Get User Email || =======================================================================================
export async function GetUserEmail()
{
    return Get(identityApiUri, '/Account/GetUserEmail');

    //return await fetch(identityApiUri + '/Account/GetUserEmail',
    //    {
    //        method: 'GET',
    //        mode: 'cors',
    //        credentials: 'include' // Allows to return the Cookies with the responce // The Cors should be also set up at the server

    //    }).then(function (response) {
    //        if (response.status == 200) // IF OK  
    //        {
    //            return response;
    //        }
    //        else // If Bad STATUS
    //        {
    //            return Promise.reject(response);  // Triggers Catch method
    //        }

    //    }).catch(function (err) // If Exception
    //    {
    //        // Show Error
    //        try // Because of err.text()
    //        {
    //            err.text().then(errorMessage => {
    //                var error = errorMessage.substring(1, errorMessage.length - 1); // Remove the [..] form the Msg
    //                console.error(error); // Get the error and display
    //            });
    //        }
    //        catch (e) {
    //            console.warn("Get User Exception -  Probably No connection to hte server");
    //            console.error(e); // Get the error and display
    //        }
    //        console.warn('Post Exception:', err);
    //    });
}








 





// ============== || Get User DATA || =======================================================================================
export async function GetUserData()
{

    return Get(identityApiUri, '/Account/GetUserData');


    //return await fetch(identityApiUri + '/Account/GetUserData',
    //    {
    //        method: 'GET',
    //        mode: 'cors',
    //        credentials: 'include' // Allows to return the Cookies with the responce // The Cors should be also set up at the server

    //    }).then(function (response) {
    //        if (response.status == 200) // IF OK  
    //        {
    //            return response;
    //        }
    //        else // If Bad STATUS
    //        {
    //            return Promise.reject(response);  // Triggers Catch method
    //        }

    //    }).catch(function (err) // If Exception
    //    {
    //        // Show Error
    //        try // Because of err.text()
    //        {
    //            err.text().then(errorMessage => {
    //                var error = errorMessage.substring(1, errorMessage.length - 1); // Remove the [..] form the Msg
    //                console.error(error); // Get the error and display
    //            });
    //        }
    //        catch (e) {
    //            console.warn("Get User Exception -  No connection to hte server");
    //            console.error(e); // Get the error and display
    //        }
    //        console.warn('Post Exception:', err);
    //    });
}
















// ============== || Get User DATA - Populate Update - Form|| =======================================================================================
export async function PopulateUpdateForm(formID) {
    var currentForm = document.getElementById(formID);  // Get the form   
    var resPrommise = await GetUserData();  // Get responce

       
    // populate the Form
    await resPrommise.json().then(content => // Check the response content
    {
        if (content != null) {
            currentForm['email'].value = content['email'];
            currentForm['firstname'].value = content['firstname'];
            currentForm['lastname'].value = content['lastname'];
            if (content['age'] != 0) {
                currentForm['age'].value = content['age'];
            }
            currentForm['phonenumber'].value = content['phonenumber'];
        }

        return;
    });
}






