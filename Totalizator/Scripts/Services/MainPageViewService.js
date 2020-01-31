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

    self.MakeBet = function (eventData) {
        sessionStorage.clear();
        sessionStorage.setItem('EventId', eventData.Id);
        sessionStorage.setItem('EventName', eventData.Name);
        sessionStorage.setItem('EventDate', eventData.Date);
        sessionStorage.setItem('TeamFirst', eventData.TeamFirstName);
        sessionStorage.setItem('TeamFirstId', eventData.TeamFirstId);
        sessionStorage.setItem('TeamSecond', eventData.TeamSecondName);
        sessionStorage.setItem('TeamSecondId', eventData.TeamSecondId);
        sessionStorage.setItem('TeamFirstCoefficient', eventData.TeamFirstCoefficient);
        sessionStorage.setItem('TeamSecondCoefficient', eventData.TeamSecondCoefficient);
        location.href = "/Home/NewBet";
    }

    self.EditEvent = function (eventData) {
        sessionStorage.clear();
        sessionStorage.setItem('EventId', eventData.Id);
        sessionStorage.setItem('EventTypeId', eventData.TypeId);
        sessionStorage.setItem('EventName', eventData.Name);
        sessionStorage.setItem('EventDate', eventData.Date);
        sessionStorage.setItem('EventDescription', eventData.Description);
        sessionStorage.setItem('TeamFirst', eventData.TeamFirstName);
        sessionStorage.setItem('TeamFirstId', eventData.TeamFirstId);
        sessionStorage.setItem('TeamFirstPoints', eventData.TeamFirstPoints);
        sessionStorage.setItem('TeamSecond', eventData.TeamSecondName);
        sessionStorage.setItem('TeamSecondId', eventData.TeamSecondId);
        sessionStorage.setItem('TeamSecondPoints', eventData.TeamSecondPoints);
        sessionStorage.setItem('TeamFirstCoefficient', eventData.TeamFirstCoefficient);
        sessionStorage.setItem('TeamSecondCoefficient', eventData.TeamSecondCoefficient);
        sessionStorage.setItem('CreateDate', eventData.CreateDate);
        sessionStorage.setItem('CreatorId', eventData.CreatorId);
        sessionStorage.setItem('StatusOfEvent', eventData.Status);
        location.href = "/Home/EditEvent";

    }
}