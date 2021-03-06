﻿function getStatuses(viewModel) {
    var tokenKey = "tokenInfo"; 
    $.ajax({
        type: 'GET',
        url: '/api/event/GetStatusList',
        contentType: 'application/json; charset=UTF-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    }).done(function (data) {
        var obj = jQuery.parseJSON(data);
        console.log(obj);
        let statuses = new Array();
        for (let i = 0; i < obj.length; i++) {
            statuses.push(obj[i]);
        }
        createEventViewModel.StatusesList(statuses);
    })

}

function getTypes() {
    var tokenKey = "tokenInfo"; 
    $.ajax({
        type: 'GET',
        url: '/api/event/GetTypesList',
        contentType: 'application/json; charset=UTF-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    }).done(function (data) {
        var obj = jQuery.parseJSON(data);
        console.log(obj);
        let types = new Array();
        for (let i = 0; i < obj.length; i++) {
            types.push(obj[i]);
        }
        createEventViewModel.TypeList(types);
    })
}

