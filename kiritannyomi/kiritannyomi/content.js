// JavaScript source code
var launch_msg;
//myCustomEvent web上的jsfunction event Name
document.addEventListener('myCustomEvent', function (evt) {
    chrome.runtime.sendMessage({ type: "launch", message: evt.detail }, function (response) {
        console.log(response)
    });
}, false);
run();
function run() {
    if (document.getElementsByClassName("js-stream-item stream-item stream-item").length != 0) {
        alert
        document.getElementsByClassName("js-stream-item stream-item stream-item")[0].outerHTML;
    }
    setTimeout(run,1000);
}