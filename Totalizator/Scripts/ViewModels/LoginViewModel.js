function LoginViewModel(loginService) {

    var self = this;
    self.init = function () {


        self.loginService = loginService;

        self.UserName = ko.observable();
        self.UserPassword = ko.observable();

        self.LoginClick = function () {

            loginService.signIn(self.UserName(), self.UserPassword());
        }

        self.RegisrtationClick = function () {
            location.href = "/Home/Registration";
        }

    }
}
