(function () {
    "use strict";

    angular
        .module("app.discussions")
        .controller("DiscussionList", DiscussionList);

    function DiscussionList(discussionsData, genericData) {
        var vm = this;

        vm.selectedIndex = -1;

        vm.discussionList = '';
        vm.areaList = '';

        getAreaList();
        getDiscussionList();

        function getDiscussionList() {
            discussionsData.get('discussions').then(function (response) {
                vm.discussionList = response.data;
            });
        }

        vm.getAllDiscussions = function (index) {
            vm.selectedIndex = index;
            getDiscussionList();
        }

        vm.getDiscussionsByArea = function (index, area) {
            vm.selectedIndex = index;
            discussionsData.getByArea(area).then(function (response) {
                vm.discussionList = response.data;
            });
        }

        function getAreaList() {
            genericData.getAll('areas').then(function (response) {
                vm.areaList = response.data;
            });
        }
    }
})();