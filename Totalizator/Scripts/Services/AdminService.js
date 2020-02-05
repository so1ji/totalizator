function AdminService() {
    var self = this;

    self.getUsers = function (pageNumber = 1) {
        var tokenKey = "tokenInfo"; //FIX
        $.ajax({
            type: 'GET',
            url: '/api/user/GetUserList' + '?pageNumber=' + pageNumber,
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        }).done(function (data) {
            var obj = jQuery.parseJSON(data);
            console.log(obj);
            adminPanelViewModel.userList.removeAll();
            adminPanelViewModel.userList(obj);
        })
    }

    self.getCountOfUsers = function () {
        var tokenKey = "tokenInfo"; //FIX
        $.ajax({
            type: 'GET',
            url: '/api/user/GetCountOfUsers',
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        }).done(function (data) {
            var obj = jQuery.parseJSON(data);
            for (var i = 1; i <= Math.ceil(parseInt(obj) / 7); i++) {
                adminPanelViewModel.paginationButtons.push(i);
            }
        })

    }

    self.MakeAdmin = function (data) {
        var tokenKey = "tokenInfo"; //FIX
        var userData = data;
        $.ajax({
            data: JSON.stringify(userData),
            type: 'POST',
            url: '/api/user/MakeUserAdmin',
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        })
    }

    self.DeleteUser = function (data) {
        var tokenKey = "tokenInfo"; //FIX
        var userData = data;
        $.ajax({
            data: JSON.stringify(userData),
            type: 'DELETE',
            url: '/api/user/DeleteUser',
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        })

    }
}