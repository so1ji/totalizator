function EditEventService() {
    var self = this;

    self.saveEvent = function (TeamFirstCoefficient, TeamSecondCoefficient, WinnerTeamId,
        TeamFirstPoints, TeamSecondPoints, StatusOfEvent) {

        var editorId = getCurrentUserId(); //return a obj

        var tokenKey = "tokenInfo"; //FIX
        var data =
        {
            Id: sessionStorage.EventId,
            TypeId: sessionStorage.EventTypeId,
            Name: sessionStorage.EventName,
            Date: sessionStorage.EventDate,
            Description: sessionStorage.EventDescription,
            TeamFirstId: sessionStorage.TeamFirstId,
            TeamSecondId: sessionStorage.TeamSecondId,

            TeamFirstCoefficient: TeamFirstCoefficient,
            TeamSecondCoefficient: TeamSecondCoefficient,
            TeamFirstPoints: TeamFirstPoints,
            TeamSecondPoints: TeamSecondPoints,
            WinnerId: WinnerTeamId,//addd a null value
            CreatorId: sessionStorage.CreatorId,
            CreateDate: sessionStorage.CreateDate,

            EditorId: editorId,
            Status: StatusOfEvent
        };
        console.log(data);
        $.ajax({
            type: 'POST',
            url: '/api/event/Edit',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        })
    }



}