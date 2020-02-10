function UserProfileViewModel(profileService) {
    var self = this;

    self.init = function () {
        self.profileService = profileService;

        var user = getCurrentUser();
        console.log(user);

        self.NewEmail = ko.observable();
        self.NewName = ko.observable();
        self.NewPassword = ko.observable();

        self.UserName = ko.observable(user.UserName);
        self.UserRole = ko.observableArray(user.Roles);
        self.betList = ko.observableArray();
        self.paginationButtons = ko.observableArray();

        self.deleteAccount = function () {
            profileService.deleteAccount();
        }

        self.saveNewEmail = function () {
            profileService.saveNewEmail(self.NewEmail());
        }

        self.saveNewName = function () {
            profileService.saveNewName(self.NewName());
        }

        self.saveNewPassword = function () {
            profileService.saveNewPassword(self.NewPassword());
        }

        self.load = function (numberOfPage) {
            profileService.getEvents(numberOfPage, user.Id);
        }

        self.deleteBet = function (data) {
            profileService.deleteBet(data.Id);
            console.log(data.Id);
        }

        profileService.getCountOfBets(user.Id);
    }
}