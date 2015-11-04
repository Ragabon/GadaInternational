(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('genericData', genericData);

    /* @ngInject */
    function genericData($http, appSettings, commonServices) {
        //set all commonly used variables
        var _headers = { 'Content-Type': 'application/json' };
        var rootUrl = appSettings.serverPath;
        //define the methods of the service
        var service = {
            get: get,
            getById: getById,
            getAll: getAll,
            getList: getList,
            getEnabled: getEnabled,
            getDisabled: getDisabled,
            add: add,
            edit: edit,
            disable: disable,
            enable: enable,
            search: search,
            advancedSearch: advancedSearch,
            find: find,
            latest: latest,
            del: del
        };

        return service;

        //the logic behind the methods

        function get(controller) {
            return apiCall('GET', rootUrl + controller, _headers, undefined);
        }

        function getById(controller, id) {
            return apiCall('GET', rootUrl + controller + '/' + id, _headers, id);
        }

        function getAll(controller) {
            return apiCall('GET', rootUrl + controller + '/all', _headers, undefined);
        }

        function getList(controller, pageNum, pageSize) {
            return apiCall('GET', rootUrl + controller + '/list/' + pageNum + '/' + pageSize, _headers, undefined);
        }

        function getEnabled(controller) {
            return apiCall('GET', rootUrl + controller + '/list/enabled', _headers, undefined);
        }

        function getDisabled(controller) {
            return apiCall('GET', rootUrl + controller + '/list/disabled', _headers, undefined);
        }

        function add(controller, obj) {
            return apiCall('POST', rootUrl + controller + '/add', _headers, obj);
        }

        function edit(controller, obj) {
            return apiCall('PUT', rootUrl + controller + '/edit', _headers, obj);
        }

        function enable(controller, obj) {
            return apiCall('PUT', rootUrl + controller + '/enable', _headers, obj);
        }

        function disable(controller, obj) {
            return apiCall('PUT', rootUrl + controller + '/disable', _headers, obj);
        }

        function search(controller, searchText) {
            return apiCall('GET', rootUrl + controller + '/' + searchText, _headers, searchText);
        }

        function advancedSearch(controller, searchString) {
            return apiCall('GET', rootUrl + controller + '/advSearch/' + searchString, _headers, undefined);
        }

        function find(controller, query) {
            return apiCall('GET', rootUrl + controller + '/find/' + query, _headers, query);
        }

        function latest(controller) {
            return apiCall('GET', rootUrl + controller + '/latest', _headers, undefined);
        }

        function del(controller, id) {
            return apiCall('DELETE', rootUrl + controller + '/' + id, _headers, id);
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
                    //return err;
                    commonServices.showToast('danger', err.data);
                });
        }
    }
})();