function LoginViewModel(loginService) { //вынести?

    var self = this;
    self.init = function () {


        self.loginService = loginService;

        self.UserName = ko.observable();//useless
        self.LoginUserName = ko.observable();
        self.UserPassword = ko.observable();
        self.TeamsList = ko.observableArray();

        getTeams(); //куда?


        self.LoginClick = function () {

            loginService.signIn(self.LoginUserName(), self.UserPassword());
        }

    }
}
