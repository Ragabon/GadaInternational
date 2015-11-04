(function () {
    "use strict";

    angular
        .module("app.tweets")
        .controller("TwitterWidget", TwitterWidget);

    function TwitterWidget(genericData) {
        var vm = this;

        vm.tweetsList = '';
        getTweetsList();

        function getTweetsList() {
            genericData.get('tweets').then(function (response) {
                vm.tweetsList = response.data;
            });
        }
    }
})();