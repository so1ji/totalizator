function UserProfileViewModel(UserService) {
    var self = this;

    self.init = function () {
        self.UserService = UserService;


        self.UserName = ko.observable();
        self.UserRole = ko.observable();

        console.log(getCurrentUserId());

    }
}