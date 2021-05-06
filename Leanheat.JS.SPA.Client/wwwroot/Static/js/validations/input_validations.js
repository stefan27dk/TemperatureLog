

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
