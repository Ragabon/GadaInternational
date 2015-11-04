(function () {
    "use strict";

    angular
        .module("app.profile")
        .controller("Profile", Profile);

    function Profile(profileData, genericData, $stateParams,$sessionStorage) {
        var vm = this;

        vm.profile = {};
        vm.interests = {};
        vm.areas = {};

        loadSkills();
        loadInterests();
        loadProfile();

        vm.areas = '';
        loadAreas();

        function loadSkills() {
            genericData.getAll('skills').then(function (response) {
                vm.areas = response.data;
            });
        };

        function loadAllInterests() {
            genericData.getAll('interests').then(function (response) {
                vm.interests = response.data;
            });
        };

        function loadProfile() {
            profileData.get($stateParams.id).then(function (response) {
                vm.profile = response;
            });
        }

        if ($sessionStorage.gadaUser.id === $stateParams.id) {

        }
        else {

        }


        //function loadInterests(query) {
        //    genericData.find('interests', query).then(function (response) {
        //        vm.tags = [];

        //        for (var i = 0; i < response.data.length; i++) {
        //            var obj = { text: response.data[i].interest };
        //            vm.tags.push(obj);
        //        }
        //    });
        //};
    }

})();