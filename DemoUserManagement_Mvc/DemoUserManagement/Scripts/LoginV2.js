$(document).ready(function () {
    $('#loginForm').submit(function (e) {
        var formData = $(this).serialize();
        $.ajax({
            type: "POST",
            url: '/LoginV2/LoginV2',
            data: formData,
            success: function (result) {
            },
            error: function (xhr, status, error) {
            }
        });
    });
});