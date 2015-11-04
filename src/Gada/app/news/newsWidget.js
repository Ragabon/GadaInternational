(function () {
    "use strict";

    angular
        .module("app.news")
        .controller("NewsWidget", NewsWidget);

    function NewsWidget(genericData) {
        //var rootUrl = appSettings.serverPath + "news";

        var vm = this;

        vm.newsList = '';
        getNewsList();

        function getNewsList() {
            //var req = {
            //    method: 'GET',
            //    url: rootUrl
            //}

            //$http(req).success(function (response) {
            //    console.log("success");
            //    vm.newsList = response;
            //    console.log(vm.newsList);
            //})
            //.error(function (err) {
            //    console.log(err);
            //});

            genericData.latest('news').then(function (response) {
                vm.newsList = response.data;
            });
        }
    }
})();