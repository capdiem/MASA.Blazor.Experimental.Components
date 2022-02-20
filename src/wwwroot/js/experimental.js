window.MasaBlazorExperimental = {}

window.MasaBlazorExperimental.copyChild = function (el) {
    if (typeof el === 'string') {
        el = document.querySelector(el);
    }

    if (!el) return;

    el.setAttribute('contenteditable', 'true');
    el.focus();
    document.execCommand('selectAll', false, null);
    document.execCommand('copy');
    document.execCommand('unselect');
    el.removeAttribute('contenteditable');
}

window.MasaBlazorExperimental.copyText = function (text) {
    if (!navigator.clipboard) {
        var textArea = document.createElement("textarea");
        textArea.value = text;

        // Avoid scrolling to bottom
        textArea.style.top = "0";
        textArea.style.left = "0";
        textArea.style.position = "fixed";

        document.body.appendChild(textArea);
        textArea.focus();
        textArea.select();

        try {
            var successful = document.execCommand('copy');
            var msg = successful ? 'successful' : 'unsuccessful';
            console.log('Fallback: Copying text command was ' + msg);
        } catch (err) {
            console.error('Fallback: Oops, unable to copy', err);
        }

        document.body.removeChild(textArea);
        return;
    }

    navigator.clipboard.writeText(text).then(function () {
        console.log('Async: Copying to clipboard was successful!');
    }, function (err) {
        console.error('Async: Could not copy text: ', err);
    });
}

window.MasaBlazorExperimental.isEllipsis = function (el) {
    return (el.offsetWidth < el.scrollWidth);
}

window.MasaBlazorExperimental.getTimezoneOffset = function () {
    return new Date().getTimezoneOffset();
}
