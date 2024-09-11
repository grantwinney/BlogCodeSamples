window.addEventListener('load', function load(event) {
    document.getElementById('send').onclick = function() {
        var email = document.getElementById('emailAddress').value;
        var subject = document.getElementById('emailSubject').value;
        var body = encodeURIComponent(document.getElementById('emailBody').value);
        window.open(`mailto:${email}?subject=${subject}&body=${body}`);
    };
});
