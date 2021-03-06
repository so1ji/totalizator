﻿function LoginService() {
    var self = this;

    self.signIn = function (UserName, UserPassword) {

        var tokenKey = "tokenInfo"; 
        var data = {
            grant_type : 'password',
            username : UserName,
            password : UserPassword
        };
   
        $.ajax({
            async: false,
            type: 'POST',
            url: '/token',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: 'json',
            data: data
        }).done(function (data) {
            var expire = new Date();
            expire.setHours(expire.getHours() + 4);
            document.cookie = "tokenInfo=" + data.access_token + "; path=/; expires=" + expire.toUTCString() + ";";
        })
    }
}