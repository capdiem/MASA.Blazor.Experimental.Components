window.MasaBlazorExperimental = {}

window.MasaBlazorExperimental.isEllipsis = function (el) {
    return (el.offsetWidth < el.scrollWidth);
}

window.MasaBlazorExperimental.getTimezoneOffset = function () {
    return new Date().getTimezoneOffset();
}
