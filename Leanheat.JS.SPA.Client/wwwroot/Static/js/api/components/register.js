


const registerForm = document.getElementById('registerForm'); // Get the Form

registerForm.addEventListener('submit', function (e)
{
    e.preventDefault(); // Prevent page reload on Submit




    const formData = new FormData(this); // "this" = this Form


    fetch('https://localhost:44347/Account/Register', {
        method: 'post',
        body: formData
    }).then(function (responce) {

        // IF OK
        if (response.ok) {
            console.log("OK!!!!!");
            return response.json();
        }
        else // If Bad STATUS
        {
            console.log("BAD!!!!!");
            return Promise.reject(response);
        }

    }).then(function (responceData) // Responce DATA
    {
        console.log("ResponceData!!!!!" + responceData);

        // Responce data--->

    }).catch(function (err) // CATCH
    {
        // Handle error here
        console.warn('Post Exception:', err);
    });

});