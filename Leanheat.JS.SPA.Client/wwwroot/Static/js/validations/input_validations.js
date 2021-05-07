

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
        document.getElementById(repeatPassInputID).type = 'text';
    }
    else
    {
        document.getElementById(passInputID).type = 'password';
        document.getElementById(repeatPassInputID).type = 'password';
    }
  

}












// ================================ CLIENT SIDE VALIDATIONs - BEFORE SUBMIT ===========================================================

// --------------------- EMAIL Validation -------------------------------------------------------
function ValidateEmail(currentInput)
{
    var regex = /^[a-z0-9]+(\.[a-z0-9]+)?@+[a-z0-9]+\.[a-z]{2,3}$/;
    
    if (regex.test(currentInput.value)) {
        currentInput.style.backgroundColor = "rgb(186, 255, 97)";
    }
    else
    {
        currentInput.style.backgroundColor = "rgb(255, 138, 130)";
    }
}




// --------------------- PASSWORD Validation -------------------------------------------------------
function ValidatePassword(passInputID, repeatPassInputID)
{
    var pass = document.getElementById(passInputID);
    var repeatPass = document.getElementById(repeatPassInputID);

    if (pass.value == repeatPass.value) {
        pass.style.backgroundColor = "rgb(186, 255, 97)";
        repeatPass.style.backgroundColor = "rgb(186, 255, 97)";
    }
    else
    {
        pass.style.backgroundColor = "rgb(255, 138, 130)";
        repeatPass.style.backgroundColor = "rgb(255, 138, 130)";
    }

}






// --------------------- Name Validation -------------------------------------------------------
function Name(currentNameInput)
{
    var regex = /^([a-zA-ZæøåÆØÅ]{2,20})?$/;

    if (regex.test(currentNameInput.value)) {
        currentNameInput.style.backgroundColor = "rgb(186, 255, 97)";
    }
    else
    {
        currentNameInput.style.backgroundColor = "rgb(255, 138, 130)";
    }
}
// ================================ CLIENT SIDE VALIDATION - REGISTER - BEFORE SUBMIT ===========================================================
