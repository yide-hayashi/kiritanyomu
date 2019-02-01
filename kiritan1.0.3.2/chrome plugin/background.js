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
    port = null;
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
    if (port == null) {
        port = chrome.runtime.connectNative(nativeHostName);
        port.onMessage.addListener(onNativeMessage);
        port.onDisconnect.addListener(onDisconnencted);
    }
    else
        console.log("輸出中");
    port.postMessage({ message: msg });
} 

chrome.contextMenus.create(
    {
        "title": "きりたん読む",
        "type": "normal",
        "id": "kiritan",
        "contexts": ["selection"],
        "onclick": getdata()
    }
);
function getdata() {
    //info 頁面資訊 tab tab上的資料
    return function (info, tab) {
        connectToNativeHost(info.selectionText );
    };
}