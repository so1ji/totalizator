function ProfileService() {
    var self = this;

    self.getEvents = function (pageNumber = 1, userId) {
        var tokenKey = "tokenInfo";
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
        var tokenKey = "tokenInfo";
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
            userProfileViewModel.paginationButtons.removeAll();
            for (var i = 1; i <= Math.ceil(parseInt(obj) / 3); i++) {
                userProfileViewModel.paginationButtons.push(i);
            }
        })

    }

    self.saveNewEmail = function (newEmail) {
        $("#message-in-modal").text("Are you sure about changing Email?");
        $.blockUI({ message: $('#question'), css: { width: '275px' } });
        $(window.yesClicked).change(function () {
            $('#yes').click(function () {
                var tokenKey = "tokenInfo";
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
                }).done(function () {
                    $('#yes').off('click');
                    $.unblockUI();

                })
            });
        })
    }

    self.saveNewPassword = function (newPassword) {
        $("#message-in-modal").text("Are you sure about changing password?");
        $.blockUI({ message: $('#question'), css: { width: '275px' } });
        $('#yes').click(function () {
            var tokenKey = "tokenInfo";
            $.ajax({
                type: 'GET',
                url: '/api/user/ChangePassword' + '?newPassword=' + newPassword,
                contentType: 'application/json; charset=UTF-8',
                beforeSend: function (xhr) {
                    var token = getCookiePartByKey(tokenKey);
                    xhr.setRequestHeader("Authorization", "Bearer " + token);
                },
            }).done(function () {
                $.unblockUI();
                $('#yes').off('click');
            })
        });
    }

    self.saveNewName = function (newName) {
        $("#message-in-modal").text("Are you sure about changing name? You will be login out.");
        $.blockUI({ message: $('#question'), css: { width: '275px' } });
        $('#yes').click(function () {
            var tokenKey = "tokenInfo";
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
                    $('#yes').off('click');
                    $.unblockUI();
                    el = el.split("=")[0].trim();
                    if (!el.indexOf("tokenInfo")) {
                        document.cookie = el + "=; path=/; expires=Thu, 01 Jan 1970 00:00:00 UTC";
                        location.href = "/Home/Index";
                    }
                })
            })
        });
    }

    self.deleteBet = function (betId) {
        var tokenKey = "tokenInfo";
        var id = betId;
        $.ajax({
            type: 'GET',
            url: '/api/bet/DeleteBetById' + '?betId=' + id,
            contentType: 'application/json; charset=utf-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        }).done(function () {
            self.getEvents(1, getCurrentUserId());
            self.getCountOfBets(getCurrentUserId());
        })
    }
}