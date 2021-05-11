
var successColor = 'rgb(177, 255, 163)';
var errorColor = 'rgb(255, 156, 156)';
var alertColor = 'rgb(255, 215, 145)';
var blueColor = 'rgb(138, 239, 255)';


// ===================== Allow - Only Numbers ===============================================================
function NumValidate(key) {
    var keycode = (key.which) ? key.which : key.keyCode;

    if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) // 8 = backspace & 46 = DEL  || 48-57 = numbers
    {
        return false;
    }
    else {
        return true;
    }
}





// ===================== Allow - Only Letters ===============================================================

function LettersValidate(key) {
    var keycode = (key.which) ? key.which : key.keyCode;

    if ((keycode > 64 && keycode < 91) || (keycode > 96 && keycode < 123)) {
        return true;
    }
    else {
        return false;
    }

}




// NOT IN USE
// ================================ Check From / To - Compare Values ===========================================================
function ValidateFromTo(a, b) {

    var aElem = document.getElementById(a); // From
    var bElem = document.getElementById(b); // To

    var aValue = parseFloat(document.getElementById(a).value, 10); // From Value
    var bValue = parseFloat(document.getElementById(b).value, 10); // To Value



    if (aValue > bValue) {
        bElem.style.backgroundColor = "rgb(255, 190, 120)";
        aElem.style.backgroundColor = "rgb(255, 190, 120)";
    }
    else if (aValue <= bValue) {
        bElem.style.backgroundColor = '';
        aElem.style.backgroundColor = '';
    }

}





// ================================ Password Show Hide ===========================================================
function ShowPassword(checkBox, passInputID, repeatPassInputID)
{
    if (checkBox.checked  == true) {
        document.getElementById(passInputID).type = 'text';

        if (repeatPassInputID !='')
        {
          document.getElementById(repeatPassInputID).type = 'text';
        }
    }
    else
    {
        document.getElementById(passInputID).type = 'password';

        if (repeatPassInputID != '')
        {
        document.getElementById(repeatPassInputID).type = 'password';
        }
    }
  

}












// ================================ CLIENT SIDE VALIDATIONs - BEFORE SUBMIT ===========================================================

// --------------------- EMAIL Validation -------------------------------------------------------
function ValidateEmail(currentInput)
{
    var regex = /^[a-z0-9]+(\.[a-z0-9]+)?@+[a-z0-9]+\.[a-z]{2,3}$/;
    
    if (regex.test(currentInput.value)) {
        currentInput.style.backgroundColor = successColor;
        return true;
    }
    else
    {
        currentInput.style.backgroundColor = errorColor;
        return false;
    }
}







// --------------------- PASSWORD Validation  -------------------------------------------------------
function ValidateCurrentPasswordInput(currentPasswordInput)
{
    if (currentPasswordInput.value.length >= 6)
    {
        currentPasswordInput.style.backgroundColor = successColor;
        return true;
    }
    else
    {
        currentPasswordInput.style.backgroundColor = errorColor;
        return false;
    }
}







// --------------------- Login PASSWORD Validation  -------------------------------------------------------
function ValidateLoginPasswordInput(currentPasswordInput)
{
    if (currentPasswordInput.value.length >= 6)
    {
        currentPasswordInput.style.backgroundColor = blueColor;
        return true;
    }
    else
    {
        currentPasswordInput.style.backgroundColor = alertColor;
        return false;
    }
}







// --------------------- PASSWORD Validation Compare -------------------------------------------------------
function ValidatePasswordCompare(passInputID, repeatPassInputID)
{
    var pass = document.getElementById(passInputID);
    var repeatPass = document.getElementById(repeatPassInputID);

    if ((pass.value == repeatPass.value) && pass.value.length >= 6)
    {
        pass.style.backgroundColor = successColor;
        repeatPass.style.backgroundColor = successColor;
        return true;
    }
    else
    {
        pass.style.backgroundColor = alertColor;
        repeatPass.style.backgroundColor = alertColor;
        return false;
    }

}






// --------------------- Name Validation -------------------------------------------------------
function ValidateName(currentNameInput)
{
    var regex = /^([a-zA-ZæøåÆØÅ]{2,20})?$/;

    if (regex.test(currentNameInput.value)) {
        currentNameInput.style.backgroundColor = successColor;
        return true;
    }
    else
    {
        currentNameInput.style.backgroundColor = errorColor;
        return false;
    }
}








// --------------------- AGE Validation -------------------------------------------------------
function ValidateAge(currentAgeInput) {

    var age = Number(currentAgeInput.value); 
    if (currentAgeInput.value == "" || (age > 0 && age <= 200))
    {
        currentAgeInput.style.backgroundColor = successColor;
        return true;
    }
    else
    {
        currentAgeInput.style.backgroundColor = errorColor;
        return false;
    }
}




// --------------------- PHONENUMBER Validation --------------------------------------------------
function ValidatePhoneNumber(currentPhonenumberInput)
{
    var value = currentPhonenumberInput.value;
    
    if (value == "" || (value.length == 8 && !isNaN(value)))
    {
        currentPhonenumberInput.style.backgroundColor = successColor;
        return true;
    }
    else
    {
        currentPhonenumberInput.style.backgroundColor = errorColor;
        return false;
    }
}






// ================================ REGISTER / UPDATE - CLIENT SIDE VALIDATION - REGISTER / UPDATE - VALIDATE -  BEFORE SUBMIT ===========================================================
function UserFormIsValid(formID)
{     
    var currentForm = document.getElementById(formID);

    if(ValidateEmail(currentForm["email"]))  // EMAIL
    {
        if (ValidatePasswordCompare(currentForm["password"].id, currentForm["repeatPassword"].id)) // PASSWORD
        {
            if (ValidateName(currentForm["firstname"])) // FISTNAME
            {
                if (ValidateName(currentForm["lastname"])) // LASTNAME
                {
                    if (ValidateAge(currentForm["age"])) // AGE
                    {
                        if (ValidatePhoneNumber(currentForm["phonenumber"])) // PHONENUMBER
                        {
                            return true;
                        }
                    }
                }
            }
        }
    }

    return false;
}










// ================================ Register / Update - Submit if Valid Form ===========================================================

async function SubmitUserForm(formID, url)
{
    if (UserFormIsValid(formID))
    {
        IdentityPost(formID, url);
    }
}
















// ================================ Login - Validate ===========================================================
function ValidateLogin(formID)
{
    var currentLoginForm = document.getElementById(formID);

    if (ValidateEmail(currentLoginForm["email"]))  // EMAIL
    {
        if (ValidateLoginPasswordInput(currentLoginForm["password"])) // PASSWORD
        {
            return true;
        }
    }

    return false;
}






// ================================ Login - Submit if Valid Form ===========================================================
function SubmitLogin(formID, url)
{
    if (ValidateLogin(formID))
    {
        IdentityPost(formID, url);
    }
}













 


 