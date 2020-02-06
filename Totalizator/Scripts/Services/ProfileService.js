function ProfileService() {
    var self = this;

    self.getEvents = function (pageNumber = 1, userId) {
        var tokenKey = "tokenInfo"; //FIX
        $.ajax({
            type: 'GET',
            url: '/api/bet/GetBetList' + '?pageNumber=' + pageNumber + '&userId=' + userId,
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        }).done(function (data) {
            var obj = jQuery.parseJSON(data);
            console.log(obj);
            userProfileViewModel.betList.removeAll();
            userProfileViewModel.betList(obj);
        })
    }


    self.getCountOfBets = function (userId) {
        var tokenKey = "tokenInfo"; //FIX
        $.ajax({
            type: 'GET',
            url: '/api/bet/GetCountOfBets' + '?userId=' + userId,
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        }).done(function (data) {
            var obj = jQuery.parseJSON(data);
            for (var i = 1; i <= Math.ceil(parseInt(obj) / 3); i++) {
                userProfileViewModel.paginationButtons.push(i);
            }
        })

    }

    self.saveNewEmail = function (newEmail) {
        var tokenKey = "tokenInfo"; //FIX
        $.ajax({
            type: 'GET',
            url: '/api/user/ChangeEmail' + '?newEmail=' + newEmail,
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            },
            error: function (XmlHttpRequest) {
                if (XmlHttpRequest.status == 409) {
                    alert('This Email already exists');
                }
            }
        })
    }

    self.saveNewPassword = function (newPassword) {
        if (newPassword != "$2AT!G4#;!Bc") {
            var tokenKey = "tokenInfo"; //FIX
            $.ajax({
                type: 'GET',
                url: '/api/user/ChangePassword' + '?newPassword=' + newPassword,
                contentType: 'application/json; charset=UTF-8',
                beforeSend: function (xhr) {
                    var token = getCookiePartByKey(tokenKey);
                    xhr.setRequestHeader("Authorization", "Bearer " + token);
                },
            })
        }
        else alert("You can't use this password :)");
    }

    self.saveNewName = function (newName) {
        var x = window.confirm("You will be logout after changing name")
        if (x) {
            var tokenKey = "tokenInfo"; //FIX
            $.ajax({
                async: false,
                type: 'GET',
                url: '/api/user/ChangeName' + '?newName=' + newName,
                contentType: 'application/json; charset=UTF-8',
                beforeSend: function (xhr) {
                    var token = getCookiePartByKey(tokenKey);
                    xhr.setRequestHeader("Authorization", "Bearer " + token);
                },
                error: function (XmlHttpRequest) {
                    if (XmlHttpRequest.status == 409) {
                        alert('This Name already exists');
                    }
                }
            }).done(function () {
                document.cookie.split(";").forEach(function (el) {
                    el = el.split("=")[0].trim();
                    if (!el.indexOf("tokenInfo")) {
                        document.cookie = el + "=; path=/; expires=Thu, 01 Jan 1970 00:00:00 UTC";
                        location.href = "/Home/Index";
                    }
                })
            })
        }
    }
}