$(document).ready(function () {
    registerFileInputChangeEvent();
});

function registerFileInputChangeEvent() {
    $('input[type="file"]').change(function (e) {
        var fileNames = [];

        $.each(e.target.files, function (index, file) {
            fileNames.push(file.name);
        });

        $('.custom-file-label').html(fileNames.join(", "));
    });
}