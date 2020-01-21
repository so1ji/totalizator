function CreateEventService() {
    var self = this;

    self.saveEvent = function (FirstTeamId, SecondTeamId, TypeOfEvent, DateOfEvent,
        NameOfEvent, DescriptionOfEvent, CoefficientOfEvent, WinnerTeamId, TotalPoints, StatusOfEvent) {
        alert("Clicked");
        var currentDate = new Date();
        var tokenKey = "tokenInfo"; //FIX
        var data =
        {
            TypeId: TypeOfEvent,
            Date: DateOfEvent,
            Name: NameOfEvent,
            Description: DescriptionOfEvent,
            Coefficient: CoefficientOfEvent,
            TeamFirstId: 1,
            TeamSecondId: 1,
            WinnerId: 1,
            TotalPoints: TotalPoints,
            CreatorId: 1,
            CreateDate: currentDate,
            Status: StatusOfEvent
        };
        console.log(data);
        $.ajax({
            type: 'POST',
            url: '/api/event/Register',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        })
    }
}