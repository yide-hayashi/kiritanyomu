var port = null;
chrome.runtime.onMessage.addListener(
    function (request, sender, sendResponse) {
        if (request.type == "launch") {
            connectToNativeHost(request.message);
        }
        return true;
    }
);


function onDisconnencted() {
    port = unll;
    console.log(chrome.runtime.lastError);
}

function onNativeMessage(message) {
    console.log('recieved message from native app: ' + JSON.stringify(message));
}

//connect to native host and get the communicatetion port
function connectToNativeHost(msg) {
    var nativeHostName = "kiritan";
    //Regestry 和 Native Messaging 的app名

    console.log(nativeHostName);
    port = chrome.runtime.connectNative(nativeHostName);
    port.onMessage.addListener(onNativeMessage);
    port.onDisconnect.addListener(onDisconnected);
    port.postMessage({ message: msg });
} 

chrome.contextMenus.create(
    {
        "title": "きりたん読む",
        "type": "normal",
        "id": "kiritan",
        "contexts": ["page", "frame"],
        "onclick": getdata()
    }
);
function getdata() {
    return function (info, tab) {
        alert("クリックされました");
    };
}