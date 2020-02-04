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
}