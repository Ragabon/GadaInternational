(function () {
    "use strict";

    angular
        .module('common.services', ['ngToast'])
        .factory('commonServices', commonServices)
    .constant("appSettings",
    {
        user: '',
        serverPath: "https://localhost:44314/api/",
        loginServerPath: "https://localhost:44302/api/user/"
        //loginServerPath: "https://gada-users-api.azurewebsites.net/api/user/",
        //serverPath: "http://www.gada.local/api/api/"
        //serverPath: "https://gadaStagingApi.azurewebsites.net/api/"
        //serverPath: "https://gada-international-api.azurewebsites.net/api/"
    });

    function commonServices(ngToast, $modal) {

        var service = {
            showToast: showToast,
            showModal: showModal
        };

        return service;

        function showToast(className, message) {
            ngToast.create({
                className: className,
                content: message
            });
        }

        function showModal(template, controller, data) {
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: template,
                controller: controller,
                controllerAs: 'vm',
                resolve: {
                    obj: function () {
                        return data;
                    }
                }
            });

            return modalInstance.result.then(function (resp) {
                return resp;
            });
        }
    }
}());
