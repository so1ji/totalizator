function UserProfileViewModel(profileService) {
    var self = this;

    self.init = function () {
        self.profileService = profileService;

        var user = getCurrentUser();
        console.log(user);

        self.UserName = ko.observable(user.UserName);
        self.UserRole = ko.observableArray(user.Roles);
        self.betList = ko.observableArray();
        self.paginationButtons = ko.observableArray();



        self.load = function (numberOfPage) {
            profileService.getEvents(numberOfPage, user.Id);
        }

        profileService.getCountOfBets(user.Id);
    }
}