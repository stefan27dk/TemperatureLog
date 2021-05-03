

 // Succsess Message
function SuccessMsg(data) {
    // Show div with Svg - Msg in body
    var body = document.getElementsByTagName('body')[0];
    body.innerHTML += `<div id="successMSG" style="display: block; left: 0; right: 0; margin: auto; top: 100px; padding: 10px; border-radius: 4px; text-align: center; justify-content: center; color: blue; position: fixed; background-color: rgb(190, 240, 137); width: auto; height: auto; max-width: 200px; max-height: 70px; opacity: 0.97; z-index: 100; filter: drop-shadow(0px 0px 10px rgb(129, 255, 112));"> <p>${data}</p> </div >`;


    // Remove div after 3 sec
    setTimeout(function () { document.getElementById("successMSG").remove(); }, 3000);
}