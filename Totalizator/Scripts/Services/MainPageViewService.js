function MainPageViewService() {
    var self = this;

    self.getEvents = function (pageNumber = 1) {
        var tokenKey = "tokenInfo"; //FIX
        $.ajax({
            type: 'GET',
            url: '/api/event/GetEventsList' + '?pageNumber=' + pageNumber,
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        }).done(function (data) {
            var obj = jQuery.parseJSON(data);
            console.log(obj);
            mainPageViewModel.eventsList.removeAll();
            mainPageViewModel.eventsList(obj);
        })
    }

    self.getCountOfEvents = function () {
        var tokenKey = "tokenInfo"; //FIX
        $.ajax({
            type: 'GET',
            url: '/api/event/GetCountOfEvents',
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        }).done(function (data) {
            var obj = jQuery.parseJSON(data);
            for (var i = 1; i <= Math.ceil(parseInt(obj) / 7); i++) {
                mainPageViewModel.paginationButtons.push(i);    
            }
        })

    }
}