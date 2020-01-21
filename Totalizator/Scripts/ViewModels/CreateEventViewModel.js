function CreateEventViewModel(eventService) {

    var self = this;
    self.init = function () {

        var currentDate = new Date();

        self.eventService = eventService;

        self.StatusesList = ko.observable();
        self.TypeList = ko.observable();
        self.TeamList = ko.observable();

        self.FirstTeamId = ko.observable();
        self.SecondTeamId = ko.observable();
        self.TypeOfEvent = ko.observable();
        self.DateOfEvent = ko.observable();
        self.NameOfEvent = ko.observable();
        self.DescriptionOfEvent = ko.observable();
        self.CoefficientOfEvent = ko.observable("1");
        self.WinnerTeamId = ko.observable();
        self.TotalPoints = ko.observable("0");
        self.StatusOfEvent = ko.observable();


        self.SaveEvent = function () {
            createEventService.saveEvent(self.FirstTeamId());
        }

        getStatuses();
        getTeams();
        getTypes();
    }
}