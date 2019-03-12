// JavaScript source code
var launch_msg;
//myCustomEvent web上的jsfunction event Name
document.addEventListener('myCustomEvent', function (evt) {
    chrome.runtime.sendMessage({ type: "launch", message: evt.detail }, function (response) {
        console.log(response)
    });
}, false);
