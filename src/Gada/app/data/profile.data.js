(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('profileData', profileData);

    /* @ngInject */
    function profileData($http, $state, commonServices, appSettings, $localStorage) {
        //set all commonly used variables
        var _headers = { 'Content-Type': 'application/json' };
        var rootUrl = appSettings.serverPath + 'user/';
        //var usersUrl = appSettings.loginServerPath; "http://gada-users-api.azurewebsites.net/api/user/";
        //define the methods of the service
        var service = {
            
            get: get,
            getInterests: getInterests,
            getSkills: getSkills,
            edit: edit
        };

        return service;

        function get(id) {
            return apiCall('GET', rootUrl + id, _headers, undefined);
        }

        function getInterests() {
            return apiCall('GET', rootUrl + id + '/interest', _headers, undefined);
        }

        function getSkills() {
            return apiCall('GET', rootUrl + id + '/skill', _headers, undefined);
        }

        function edit(profile) {
            return apiCall('PUT', rootUrl, _headers, profile).then(function (response) {
                if (response.data !== undefined) {
                    return response.data;
                }
            });
        }

        function del(id) {
            return apiCall('DELETE', rootUrl + '/' + id, _headers, id);
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
                    //commonServices.showToast('danger', 'An error occured. Please try again or contact support');
                });
        }
    }
})();