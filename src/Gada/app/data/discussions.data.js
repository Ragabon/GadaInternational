(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('discussionsData', discussionsData);

    /* @ngInject */
    function discussionsData($http, $state, commonServices, appSettings, $sessionStorage) {
        //set all commonly used variables
        var _headers = { 'Content-Type': 'application/json' };
        var rootUrl = appSettings.serverPath + 'discussions';
        //var usersUrl = appSettings.loginServerPath; "http://gada-users-api.azurewebsites.net/api/user/";
        //define the methods of the service
        var service = {
            get: get,
            getById: getById,
            getByArea: getByArea,
            getRelated: getRelated,
            voteUp: voteUp,
            voteDown: voteDown,
            create: create,
            edit: edit,
            del: del

        };

        return service;

        function get() {
            return apiCall('GET', rootUrl, _headers, undefined);
        }

        function getById(id) {
            return apiCall('GET', rootUrl + '/' + id, _headers, id);
        }

        function getByArea(area) {
            return apiCall('GET', rootUrl + '/area/' + area, _headers, area);
        }

        function getRelated(id) {
            return apiCall('GET', rootUrl + '/related/' + id, _headers, id);
        }

        function voteUp(id) {
            return apiCall('GET', rootUrl + '/' + id + '/voteup', _headers, id);
        }

        function voteDown(id) {
            return apiCall('GET', rootUrl + '/' + id + '/votedown', _headers, id);
        }

        function create(discussion) {
            discussion.userId = $sessionStorage.gadaUser.id;
            return apiCall('POST', rootUrl + '/add', _headers, discussion);
            //.then(function (response) {
                //if(response.data !== undefined) {
                //    $state.go('discussions');
                //}
            //});
        }

        function edit(discussion) {
            return apiCall('PUT', rootUrl, _headers, discussion).then(function (response) {
                if (response.data !== undefined) {
                    $state.go('discussions');
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