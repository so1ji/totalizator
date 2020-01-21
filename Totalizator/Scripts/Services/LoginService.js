function LoginService() {
    var self = this;

    self.signIn = function (LoginUserName, UserPassword) {

        var tokenKey = "tokenInfo"; //FIX
        var data = {
            grant_type : 'password',
            username : LoginUserName,
            password : UserPassword
        };
   
        $.ajax({
            type: 'POST',
            url: '/token',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: 'json',
            data: data
        }).done(function (data) {
            var expire = new Date();
            expire.setHours(expire.getHours() + 4);
            document.cookie = "tokenInfo=" + data.access_token + "; path=/; expires=" + expire.toUTCString() + ";";
        }).done(function () {
            location.href = "/Home/Main";
        })
    }
}