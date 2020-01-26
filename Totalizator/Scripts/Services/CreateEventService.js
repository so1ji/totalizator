function CreateEventService() {
    var self = this;

    self.saveEvent = function (FirstTeamId, SecondTeamId, TypeOfEvent, DateOfEvent,
        NameOfEvent, DescriptionOfEvent, CoefficientOfEvent, WinnerTeamId, TotalPoints, StatusOfEvent) {

        var creatorId = getCurrentUser(); //return a obj
        console.log(creatorId);

        var tokenKey = "tokenInfo"; //FIX
        var data =
        {
            TypeId: TypeOfEvent,
            Date: DateOfEvent,
            Name: NameOfEvent,
            Description: DescriptionOfEvent,
            Coefficient: CoefficientOfEvent,
            TeamFirstId: FirstTeamId,
            TeamSecondId: SecondTeamId,
            WinnerId: WinnerTeamId,//addd a null value
            TotalPoints: TotalPoints,
            CreatorId: creatorId,
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