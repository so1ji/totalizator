﻿function getUserNameFromToken() {
    var tokenKey = "tokenInfo"; 

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

function getCurrentUser() {
    var tokenKey = "tokenInfo"; 
    var user;
    $.ajax({
        async: false,
        type: 'GET',
        url: '/api/user/GetCurrentUser',
        contentType: 'application/json; charset=UTF-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    }).done(function (data) {
        user = JSON.parse(data);
    });
    return user;
}

function getCurrentUserId() {
    var tokenKey = "tokenInfo"; 
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
        id: id,
    };
    $.ajax({
        type: 'DELETE',
        url: '/api/user/DeleteUser',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data),
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    })
}

function getUserNameById(id) {
    var tokenKey = "tokenInfo"; 
    var id = id;
    $.ajax({
        type: 'GET',
        url: '/api/user/GetUserNameById' + '?id=' + a,
        contentType: 'application/json; charset=utf-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    });
}

function getAllUsers() {

    var tokenKey = "tokenInfo"; 

    $.ajax({
        type: 'GET',
        url: '/api/user/GetUserNameFromToken',
        contentType: 'application/json; charset=UTF-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    });
}
