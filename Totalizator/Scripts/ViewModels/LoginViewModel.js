function LoginViewModel(loginService) {

    var self = this;
    self.init = function () {


        self.loginService = loginService;

        self.UserName = ko.observable();
        self.UserPassword = ko.observable();
        self.TeamsList = ko.observableArray();



        self.RegisterClick = function () {
            loginService.register(self.UserName(), self.UserPassword());
        }
        self.LoginClick = function () {

            loginService.signIn(self.UserName(), self.UserPassword());
        }

    }
}
