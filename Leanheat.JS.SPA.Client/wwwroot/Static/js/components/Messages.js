

 // =============== || Succsess Message || =================================================================
function SuccessMsg(data) {

    var leftBar = document.getElementById('left-bar');
    var leftBarWidth = leftBar.offsetWidth +25;
    
   
    // Show div with Msg - Msg in body
    var body = document.getElementsByTagName('body')[0];
    body.innerHTML += `<div id="successMSG" class="base-Message sucsess-Message" style="right:calc(50% - ${leftBarWidth}px);"> <p>${data}</p> </div>`;


    // Remove div after 3 sec
    setTimeout(function () { document.getElementById("successMSG").remove(); }, 3000);
}







 // =============== || Loading Message || ==================================================================
function LoadingMsg() {

    var leftBar = document.getElementById('left-bar'); // Get the leftbar
    var leftBarWidth = leftBar.offsetWidth + 25; // Add 25px to the leftbar width


    // Show div with Loading - Msg in body
    var body = document.getElementsByTagName('body')[0];
    body.innerHTML += `<div id="loadingMsg" class="base-Message" style="right:calc(50% - ${leftBarWidth}px);><img src="img/Messages/loading-100.gif" /></div>`;

    // Msg is remove if StatusCode = ok or else
}



 // ----------------- || Remove Loading MSG || ---------------------------------------------------------------
function RemoveLoadingMsg() {
    document.getElementById('loadingMsg').remove();
}







 // =============== || Error Message || ====================================================================
