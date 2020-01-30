function EditEventService() {
    var self = this;

    self.saveEvent = function (TeamFirstCoefficient, TeamSecondCoefficient, WinnerTeamId,
        TeamFirstPoints, TeamSecondPoints, StatusOfEvent) {

        var editorId = getCurrentUser(); //return a obj

        var tokenKey = "tokenInfo"; //FIX
        var data =
        {
            TeamFirstCoefficient: TeamFirstCoefficient,
            TeamSecondCoefficient: TeamSecondCoefficient,
            WinnerId: WinnerTeamId,//addd a null value
            TeamFirstPoints: TeamFirstPoints,
            TeamSecondPoints: TeamSecondPoints,
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