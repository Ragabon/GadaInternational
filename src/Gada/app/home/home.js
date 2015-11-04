(function () {
    "use strict";

    angular
        .module("app.home")
        .controller("Home", Home);

    function Home($sessionStorage) { //genericData
        var vm = this;
        vm.gadaUser;
        if($sessionStorage.gadaUser !== undefined)
        {
            vm.gadaUser = $sessionStorage.gadaUser;
            console.log(vm.gadaUser);
        }
    };

})();