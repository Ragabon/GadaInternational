(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('newsData', NewsData);

    /* @ngInject */
    function NewsData($http) {
        //set all commonly used variables
        var _headers = { 'Content-Type': 'application/json' };
        var rootUrl = 'https://localhost:44328/api/user/'
        var usersUrl = "http://gada-users-api.azurewebsites.net/api/user/";
        //define the methods of the service
        var service = {
            login: login,
            register: register
        };

        return service;

        function login(loginDetails) {
            return apiCall('POST', usersUrl + 'login', _headers, loginDetails).then(function (response) {
                apiCall('POST', rootUrl + 'GetUserByEmail', _headers, loginDetails.email)
                .success(function (response) {
                    $localStorage.gadaUser = response;
                });
            });
        }

        function register(registerDetails) {
            return apiCall('POST', usersUrl + 'register', _headers, registerDetails);
        }

        function apiCall(method, url, headers, data) {
            var req = {
                method: method,
                url: url,
                headers: headers,
                data: data
            }

            return $http(req)
                .success(function (resp) {
                    return resp;
                })
                .catch(function (err) {
                    console.log(err);
                    return err;
                });
        }
    }
})();