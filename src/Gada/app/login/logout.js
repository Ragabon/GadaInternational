(function () {
    "use strict";

    angular
        .module("app.login")
        .controller("Logout", Logout);

    function Logout(loginData) {
        var vm = this;
 
        function logOut() {
            loginData.logout();
        }

        logOut();
    }

})();