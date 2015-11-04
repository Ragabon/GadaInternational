(function () {
	'use strict';

	angular
        .module('app.core')
        .factory('homeData', homeData);

	/* @ngInject */
	function homeData($http, $state, commonServices, appSettings, $localStorage) {
		//set all commonly used variables
		var _headers = { 'Content-Type': 'application/json' };
		var rootUrl = appSettings.serverPath + 'home';
		//var usersUrl = appSettings.loginServerPath; "http://gada-users-api.azurewebsites.net/api/user/";
		//define the methods of the service
		var service = {
			get: get,
			getNewsFeed: getNewsFeed

		};

		return service;

		function get() {
			return apiCall('GET', rootUrl, _headers, undefined);
		}

		function getNewsFeed(id) {
			return apiCall('GET', rootUrl + '/newsfeed', _headers, undefined);
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