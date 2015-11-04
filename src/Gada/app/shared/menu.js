(function () {
    "use strict";

    angular
        .module("app.menu")
        .controller("Menu", Menu);

    function Menu($sessionStorage, loginData) {
        var m = this;
        m.gadaUser = '';

        if ($sessionStorage.gadaUser) {
            m.gadaUser = $sessionStorage.gadaUser;
      }
    }

})();