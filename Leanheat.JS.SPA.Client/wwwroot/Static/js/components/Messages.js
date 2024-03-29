﻿

 // =============== || Succsess Message || =================================================================
export function SuccessMsg(msg) {

    var leftBar = document.getElementById('left-bar');
    var leftBarWidth = leftBar.offsetWidth + 50;
    
   
    // Show div with Msg - Msg in body
    var body = document.getElementsByTagName('body')[0];
    body.insertAdjacentHTML('afterbegin', `<div id="successMSG" class="base-Message sucsess-Message" style="right:calc(50% - ${leftBarWidth}px);"> <img style="width: 50px; height: auto; filter: drop-shadow(0px 0px 10px lime);"  src="img/Messages/ok-2.png" /> <p> ${msg}</p> </div>`);

   
    // Remove div after 3 sec
    setTimeout(function () { document.getElementById("successMSG").remove(); }, 3000);
}







 // =============== || Loading Message || ==================================================================
export function LoadingMsg() {

    var leftBar = document.getElementById('left-bar'); // Get the leftbar
    var leftBarWidth = leftBar.offsetWidth + 50; // Add 25px to the leftbar width


    // Show div with Loading - Msg in body
    var body = document.getElementsByTagName('body')[0];
    body.insertAdjacentHTML('afterbegin', `<div id="loadingMsg" class="base-Message" style="right:calc(50% - ${leftBarWidth}px);"><img class="loading-Message" style="width: 100px; height: auto;" src="img/Messages/loading-100.gif" /></div>`);

    // Msg is removed if StatusCode = ok or else
}



 // ----------------- || Remove Loading MSG || ---------------------------------------------------------------
export function RemoveLoadingMsg() {
    document.getElementById('loadingMsg').remove();
}







 // =============== || Error Message || ====================================================================
export function ErrorMsg(msg) {

    var leftBar = document.getElementById('left-bar');
    var leftBarWidth = leftBar.offsetWidth + 50;


    // Show div with Err Msg - Msg in body
    var body = document.getElementsByTagName('body')[0];
    body.insertAdjacentHTML('afterbegin', `<div id="errorMSG" class="base-Message error-Message" style="right:calc(50% - ${leftBarWidth}px);"> <img style="width: 50px; height: auto; filter: drop-shadow(0px 0px 10px rgb(255, 110, 119));" src="img/Messages/error.png" /> <p> ${msg}</p > </div>`);


    // Remove div after 3 sec
    setTimeout(function () { document.getElementById("errorMSG").remove(); }, 3000);
}