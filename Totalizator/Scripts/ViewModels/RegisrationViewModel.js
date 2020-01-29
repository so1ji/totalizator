function RegisrationViewModel(registrationService) {

    var self = this;
    self.init = function () {


        self.registrationService = registrationService;

        self.UserName = ko.observable();
        self.Email = ko.observable();
        self.UserPassword = ko.observable();

        self.RegisterClick = function () {

            registrationService.register(self.UserName(), self.Email(), self.UserPassword());
        }

    }
}
