$(document).ready(function () {
    $('#Email').on('blur', function () {
        var email = $(this).val();
        var emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;

        if (!emailRegex.test(email)) {
            $('#emailMessage').html('Please enter a valid email address.').css('color', 'red');
        } else {
            $('#emailMessage').html('');
        }
    });
});