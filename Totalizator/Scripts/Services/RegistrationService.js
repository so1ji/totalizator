function RegistrationService() {
    var self = this;

    self.register = function (UserName, Email, UserPassword) {
        var data = {
            grant_type: 'password',
            username: UserName,
            email: Email,
            password: UserPassword
        };
        $.ajax({
            type: 'POST',
            url: '/api/user/Register',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: 'json',
            data: data,
            error: function (XmlHttpRequest) {
                if (XmlHttpRequest.status == 409) {
                    alert('User with this Email or UserName already exists');
                }
            }
        }).done(function (response) {
            if (response.status == 409)
            {
                alert("hello");
            }
            else {
                location.href = "/Home/Main";
            }
        })
    }
}