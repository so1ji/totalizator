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
            alert(data);
        }

        profileService.getCountOfBets(user.Id);
    }
}