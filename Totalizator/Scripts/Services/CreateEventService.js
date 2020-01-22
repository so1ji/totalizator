function CreateEventService() {
    var self = this;

    self.saveEvent = function (FirstTeamId, SecondTeamId, TypeOfEvent, DateOfEvent,
        NameOfEvent, DescriptionOfEvent, CoefficientOfEvent, WinnerTeamId, TotalPoints, StatusOfEvent) {
        var currentDate = new Date();
        var tokenKey = "tokenInfo"; //FIX
        var data =
        {
            TypeId: TypeOfEvent,
            Date: DateOfEvent, //
            Name: NameOfEvent,
            Description: DescriptionOfEvent,
            Coefficient: CoefficientOfEvent,
            TeamFirstId: FirstTeamId,
            TeamSecondId: SecondTeamId,
            WinnerId: 1,//
            TotalPoints: TotalPoints,
            CreatorId: 1, //
            CreateDate: currentDate,
            Status: StatusOfEvent //
        };
        alert(SecondTeamId);
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