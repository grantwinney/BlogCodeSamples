window.addEventListener('load', function load(event) {
    chrome.storage.local.get('name', function(result) {
        if (result != undefined && result.name != undefined) {
            document.getElementById('name').value = result.name;
        }
    });
    document.getElementById('save').onclick = function() {
        chrome.storage.local.set({'name': document.getElementById('name').value});
    };
});
