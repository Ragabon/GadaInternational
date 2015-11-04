(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('postsData', postsData);

    /* @ngInject */
    function postsData($http, $state, commonServices, appSettings, $sessionStorage) {
        //set all commonly used variables
        var _headers = { 'Content-Type': 'application/json' };
        var rootUrl = appSettings.serverPath + 'posts';
        //var usersUrl = appSettings.loginServerPath; "http://gada-users-api.azurewebsites.net/api/user/";
        //define the methods of the service
        var service = {
            latest: latest,
            voteUp: voteUp,
            voteDown: voteDown,
            create: create,
            edit: edit,
            del: del

        };

        return service;

        function latest() {
            return apiCall('GET', rootUrl + '/latest', _headers, undefined);
        }

        function getById(id) {
            return apiCall('GET', rootUrl + '/' + id, _headers, id);
        }

        function voteUp(vote) {
            return apiCall('POST', rootUrl + '/voteup', _headers, vote);
            //return apiCall('GET', rootUrl + '/' + id + '/voteup', _headers, id);
        }

        function voteDown(vote) {
            return apiCall('POST', rootUrl + '/votedown', _headers, vote);
            //return apiCall('GET', rootUrl + '/' + id + '/votedown', _headers, id);
        }

        function create(post) {
            post.userId = $sessionStorage.gadaUser.id;
            return apiCall('POST', rootUrl + '/add', _headers, post);
                //.then(function (response) {
                //if (response.data !== undefined) {
                //    return response.data;
                //}
            //});
        }

        function edit(post) {
            return apiCall('PUT', rootUrl, _headers, post);
            //.then(function (response) {
            //    if (response.data !== undefined) {
            //        return response.data;
            //    }
            //});
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