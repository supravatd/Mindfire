
function login() {
    var email = document.getElementById('txtEmail').value;
    var password = document.getElementById('txtPassword').value;

    var loginData = {
        email: email,
        password: password
    };

    $.ajax({
        url: "Login.aspx/Login_Click",
        type: "POST",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(loginData),
        success: function (response) {
            if (response.d.success) {
                window.location.href = "RegisterForm.aspx?UserId=" + response.d.user;
            } else {
                alert(response.message);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            
            console.error(xhr.responseText);
        }
    });
    return false;
}
