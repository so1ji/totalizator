function getUserNameFromToken() {
    var tokenKey = "tokenInfo"; //FIX

    $.ajax({
        type: 'GET',
        url: '/api/user/GetUserNameFromToken',
        contentType: 'application/json; charset=UTF-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    }).done(function (data) {
        loginViewModel.UserName(data);
    })
}

function getCurrentUserId() {
    var tokenKey = "tokenInfo"; //FIX
    var user;
    $.ajax({
        async: false,
        type: 'GET',
        url: '/api/user/getCurrentUserId',
        contentType: 'application/json; charset=UTF-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    }).done(function (data) {
        user = data;
    });
    return user;
}   


function deleteUserById(id) {
    var data = {
        id: id, // data or one value?
    };
    $.ajax({
        type: 'DELETE',
        url: '/api/user/DeleteUser',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data)
    })
}

function getUserNameById(id) {
    var tokenKey = "tokenInfo"; //FIX
    var id = id;
    $.ajax({
        type: 'GET',
        url: '/api/user/GetUserNameById' + '?id=' + a,
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    }).done(function (data) {
        var obj = jQuery.parseJSON(data);
        //$("#findusername").val(obj.UserName)
        //$("#finduseremail").val(obj.Email)
    });
}

function getAllUsers() {

    var tokenKey = "tokenInfo"; //FIX

    $.ajax({
        type: 'GET',
        url: '/api/user/GetUserNameFromToken',
        contentType: 'application/json; charset=UTF-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    }).done(function (data) {
        var obj = jQuery.parseJSON(data);
        //$("#findusername").val(obj.UserName)
        //$("#finduseremail").val(obj.Email)
    });
}
