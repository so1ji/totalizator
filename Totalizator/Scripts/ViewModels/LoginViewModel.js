function LoginViewModel(loginService) {

    var self = this;
    self.init = function () {


        self.loginService = loginService;

        self.UserName = ko.observable();
        self.UserPassword = ko.observable();
        self.TeamsList = ko.observableArray();



        self.LoginClick = function () {

            loginService.signIn(self.UserName(), self.UserPassword());
        }

    }
}
