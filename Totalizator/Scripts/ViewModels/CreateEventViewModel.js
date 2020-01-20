function CreateEventViewModel(eventService) {

    var self = this;
    self.init = function () {

        self.eventService = eventService;

        self.StatusesList = ko.observable();
        self.TypeList = ko.observable();
        self.TeamList = ko.observable();
        self.StatusesList = ko.observable();

        getStatuses();
        getTeams();
        getTypes();
    }
}