function LoginViewModel(loginService) {

    var self = this;
    self.init = function () {


        self.loginService = loginService;

        self.UserName = ko.observable();
        self.UserPassword = ko.observable();

        self.LoginClick = function () {
            loginService.signIn(self.UserName(), self.UserPassword());
            var user = getCurrentUser();
            $("#currentUserNameLayout").html(user.UserName);
            $("#profileElement").css("visibility", "visible");
           location.href = "/Home/Main";
        }

        self.RegisrtationClick = function () {
            location.href = "/Home/Registration";
        }

    }
}