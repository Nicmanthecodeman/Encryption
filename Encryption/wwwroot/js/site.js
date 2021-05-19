$(document).ready(function () {
    SetFocus($('.setFocus'));
    SetTooltips();
});

function SetTooltips() {
    $('[data-toggle="tooltip"]').tooltip();
}

function SetFocus(element) {
    $(element).focus().select();
}
