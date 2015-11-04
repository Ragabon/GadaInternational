(function () {
    "use strict";

    angular
        .module("app.discussions")
        .controller("RelatedDiscussionsWidget", RelatedDiscussionsWidget);

    function RelatedDiscussionsWidget(discussionsData, $stateParams) {
        var vm = this;

        vm.relatedDiscussions = [];
        getRelatedDiscussions($stateParams.id);

        function getRelatedDiscussions(id) {
            discussionsData.getRelated(id).then(function (response) {
                vm.relatedDiscussions = response.data;
            });
        }
    }
})();