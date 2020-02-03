function CreateEventService() {
    var self = this;

    self.saveEvent = function (FirstTeamId, SecondTeamId, TypeOfEvent, DateOfEvent,
        NameOfEvent, DescriptionOfEvent, TeamFirstCoefficient, TeamSecondCoefficient, WinnerTeamId, TeamFirstPoints, TeamSecondPoints, StatusOfEvent) {

        var creatorId = getCurrentUserId(); //return a obj
        console.log(creatorId);

        var tokenKey = "tokenInfo"; //FIX
        var data =
        {
            TypeId: TypeOfEvent,
            Date: DateOfEvent,
            Name: NameOfEvent,
            Description: DescriptionOfEvent,
            TeamFirstId: FirstTeamId,
            TeamSecondId: SecondTeamId,
            TeamFirstCoefficient: TeamFirstCoefficient,
            TeamSecondCoefficient: TeamSecondCoefficient,
            WinnerId: WinnerTeamId,//addd a null value
            TeamFirstPoints: TeamFirstPoints,
            TeamSecondPoints: TeamSecondPoints,
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