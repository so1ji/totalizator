﻿function MainPageViewModel(mainPageViewService) {
    var self = this;

    self.init = function () {
        self.mainPageViewService = mainPageViewService;


        self.eventsList = ko.observableArray();
        self.paginationButtons = ko.observableArray();
        self.load = function (numberOfPage) {
            mainPageViewService.getEvents(numberOfPage);
        }
        mainPageViewService.getCountOfEvents();
    }
}