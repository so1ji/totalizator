function EditEventViewModel(editEventService) {
    var self = this;

    self.init = function () {
        self.editEventService = editEventService;

        self.TypeList = ko.observable();
        self.WinnerTeamId = ko.observable();

        self.TeamFirstNameLabel = ko.observable(sessionStorage.TeamFirst + " Coefficient");
        self.TeamSecondNameLabel = ko.observable(sessionStorage.TeamSecond +  " Coefficient");
        self.TeamFirstPointsLabel = ko.observable(sessionStorage.TeamFirst + "Points");
        self.TeamSecondPointsLabel = ko.observable(sessionStorage.TeamSecond + "Points");

        self.TeamFirstCoefficient = ko.observable(sessionStorage.TeamFirstCoefficient);
        self.TeamSecondCoefficient = ko.observable(sessionStorage.TeamSecondCoefficient);
        self.TeamFirstPoints = ko.observable(sessionStorage.TeamFirstPoints);
        self.TeamSecondPoints = ko.observable(sessionStorage.TeamSecondPoints);
        self.StatusOfEvent = ko.observable(sessionStorage.StatusOfEvent);

        self.StatusesList = ko.observable(["Active", "Gone"]);
        self.isDisabled = ko.observable(false);

        self.TeamList = ko.observableArray([{
            Name: sessionStorage.TeamFirst,
            Id: sessionStorage.TeamFirstId
        },
        {
            Name: sessionStorage.TeamSecond,
            Id: sessionStorage.TeamSecondId
        }]);



        self.SaveEvent = function () {
            editEventService.saveEvent(
                self.TeamFirstCoefficient(), self.TeamSecondCoefficient(), self.WinnerTeamId(),
                self.TeamFirstPoints(), self.TeamSecondPoints(), self.StatusOfEvent());
        }

        self.OnChangeStatus = function () {
            if (self.StatusOfEvent() == "Active") {
                self.WinnerTeamId(null);
                self.isDisabled(true);
            }
            else {
                self.isDisabled(false);
            }
        }


    }
} 