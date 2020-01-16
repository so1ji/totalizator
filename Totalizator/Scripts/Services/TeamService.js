function getTeams() {
    var tokenKey = "tokenInfo"; //FIX
    $.ajax({
        type: 'GET',
        url: '/api/team/GetListOfTeams',
        contentType: 'application/json; charset=UTF-8',
        beforeSend: function (xhr) {
            var token = getCookiePartByKey(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        }
    }).done(function (data) {
        var obj = jQuery.parseJSON(data);
        let names = new Array();
        for (let i = 0; i < obj.length; i++) {
            names.push(obj[i].Name);
        }
        loginViewModel.TeamsList(names);
    })
}
