function AdminPanelViewModel(adminService) {
    var self = this;

    self.init = function () {
        self.adminService = adminService;


        self.userList = ko.observableArray();
        self.paginationButtons = ko.observableArray();
        self.load = function (numberOfPage) {
            adminService.getUsers(numberOfPage);
        }
        self.MakeAdmin = function (data) {
            console.log(data);
            adminService.MakeAdmin(data);
        };

        self.MakeModerator = function (data) {
            adminService.MakeAdmin(data); //TODO CHANGE TO Moderator
        };

        self.DeleteUser = function (data) {
            adminService.DeleteUser(data);
        };

        adminService.getCountOfUsers();
    }
}