(function () {
    "use strict";

    angular
        .module("app.home")
        .controller("NewsFeedWidget", NewsFeedWidget);

    function NewsFeedWidget(homeData) {
        var vm = this;

        vm.newsFeeds = [];
        getNewsFeed();

        function getNewsFeed() {
            homeData.getNewsFeed().then(function (response) {
                vm.newsFeeds = response.data;
            });
        }
    }
})();