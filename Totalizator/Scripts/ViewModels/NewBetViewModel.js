function NewBetViewModel(newBetService) {
    var self = this;
    self.init = function () {
        self.newBetService = newBetService;

        self.SelectedTeamId = ko.observable();
        self.EventId = ko.observable(sessionStorage.EventId);
        self.NameOfEvent = ko.observable(sessionStorage.EventName);
        self.DateOfEvent = ko.observable(sessionStorage.EventDate);
        self.TeamFirstName = ko.observable(sessionStorage.TeamFirst);
        self.TeamSecondName = ko.observable(sessionStorage.TeamSecond);
        self.TeamFirstCoefficient = ko.observable(sessionStorage.TeamFirstCoefficient);
        self.TeamSecondCoefficient = ko.observable(sessionStorage.TeamSecondCoefficient);
        self.BetAmount = ko.observable(1);
        self.TeamList = ko.observableArray([{
            Name: sessionStorage.TeamFirst,
            Id: sessionStorage.TeamFirstId
        },
        {
            Name: sessionStorage.TeamSecond,
            Id: sessionStorage.TeamSecondId
        }]);

        self.MakeBet = function () {
            newBetService.MakeBet(self.EventId(), self.BetAmount(), self.SelectedTeamId());
        }
    }
}