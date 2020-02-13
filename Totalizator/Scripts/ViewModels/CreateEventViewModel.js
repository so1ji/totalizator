function CreateEventViewModel(eventService) {

    var self = this;
    self.init = function () {
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
        self.TeamFirstCoefficient = ko.observable("1");
        self.TeamSecondCoefficient = ko.observable("1");
        self.WinnerTeamId = ko.observable();
        self.TeamFirstPoints = ko.observable("0");
        self.TeamSecondPoints = ko.observable("0");
        self.StatusOfEvent = ko.observable();
        self.isDisabled = ko.observable(false);

        self.OnChangeStatus = function () {
            if (self.StatusOfEvent() == "Active") {
                self.isDisabled(true);
            }
            else {
                self.isDisabled(false);
            }
        }

        self.SaveEvent = function () {
            createEventService.saveEvent(self.FirstTeamId(), self.SecondTeamId(),
                self.TypeOfEvent(), self.DateOfEvent(), self.NameOfEvent(), self.DescriptionOfEvent(),
                self.TeamFirstCoefficient(), self.TeamSecondCoefficient(), self.WinnerTeamId(), self.TeamFirstPoints(), self.TeamSecondPoints(), self.StatusOfEvent());
        }

        getStatuses();
        getTeams();
        getTypes();
    }
}