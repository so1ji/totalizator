function AdminPanelViewModel(adminService) {
    var self = this;

    self.init = function () {
        self.adminService = adminService;

        self.hasModeratorRole = ko.observable(false);
        self.hasAdminRole = ko.observable(false);

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
            adminService.MakeModerator(data); 
        };

        self.DeleteUser = function (data) {
            adminService.DeleteUser(data);
        };

        adminService.getCountOfUsers();
    }

}