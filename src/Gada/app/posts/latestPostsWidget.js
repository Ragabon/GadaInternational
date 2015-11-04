(function () {
    "use strict";

    angular
        .module("app.posts")
        .controller("LatestPostsWidget", LatestPostsWidget);

    function LatestPostsWidget(genericData) {
        //var rootUrl = appSettings.serverPath + "posts";

        var vm = this;

        vm.latestPosts = [];
        getLatestPosts();

        function getLatestPosts() {
            //var req = {
            //    method: 'GET',
            //    url: rootUrl + '/latest'
            //}

            //$http(req).success(function (response) {
            //    console.log("success");
            //    vm.latestPosts = response;
            //    console.log(vm.latestPosts);
            //})
            //.error(function (err) {
            //    console.log(err);
            //});
            genericData.latest('posts').then(function(response) {
                vm.latestPosts = response.data;
            });
        }
    }
})();