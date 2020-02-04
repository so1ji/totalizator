function NewBetService() {
    var self = this;

    self.MakeBet = function (EventId, BetAmount, TeamId) {

        var creatorId = getCurrentUserId(); //return a obj
        console.log(creatorId);

        var tokenKey = "tokenInfo"; //FIX
        var data =
        {
            UserId: creatorId,
            EventId: EventId,
            Amount: BetAmount,
            TeamId: TeamId
        };
        console.log(data);
        sessionStorage.clear();
        $.ajax({
            type: 'POST',
            url: '/api/bet/CreateBet',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=UTF-8',
            beforeSend: function (xhr) {
                var token = getCookiePartByKey(tokenKey);
                xhr.setRequestHeader("Authorization", "Bearer " + token);
            }
        }).done(function () {
            location.href = "/Home/Main";
        })
    }
}