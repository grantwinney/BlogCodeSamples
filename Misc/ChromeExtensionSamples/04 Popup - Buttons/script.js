window.addEventListener('load', function load(event) {
    ['khaki','lightblue','palegreen'].forEach(function(color) {
        document.getElementById(color).onclick = function() {
            chrome.tabs.query({"active":true, "lastFocusedWindow":true}, function(tabs) {
                chrome.tabs.insertCSS(tabs[0].id, {'code':`html,body,div,p{background:${color}!important}`})
            });
        };
    });
});
