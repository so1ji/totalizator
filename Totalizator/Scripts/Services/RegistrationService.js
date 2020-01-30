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
            data: data
        }).done(function () {
            location.href = "/Home/Main";
        })
    }
}