(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('loginData', loginData);

    /* @ngInject */
    function loginData($http, $sessionStorage, $state, commonServices, appSettings) {
        //set all commonly used variables
        var _headers = { 'Content-Type': 'application/json' };
        var rootUrl = appSettings.serverPath + 'user/';
        var usersUrl = appSettings.loginServerPath;
        //define the methods of the service
        var service = {
            login: login,
            getUser: getUser,
            register: register,
            logout: logout,
            isAuthenticated: isAuthenticated
        };

        return service;

        function login(loginDetails) {

            //return apiCall('POST', usersUrl + 'login', _headers, loginDetails).then(function (response) {
            //    if (response.status === 200) {
            //        var gum = { 'email': loginDetails.email }
            //    } else {
            //        commonServices.showToast('danger', 'Incorrect email or password');
            //    }
            //    apiCall('POST', rootUrl + 'GetUserByEmail', _headers, gum)
            //    .then(function (response) {
            //        if (response.status === 200 && response.data !== null) {
            //            $sessionStorage.gadaUser = response.data;
            //            $state.go('home');
            //        } else {
            //            commonServices.showToast('danger', 'Incorrect email or password');
            //        }
            //    });
            //});

            return apiCall('POST', usersUrl + 'login', _headers, loginDetails);
        }

        function getUser(gum) {
            return apiCall('POST', rootUrl + 'GetUserByEmail', _headers, gum);
        }

        function register(registerDetails) {
            return apiCall('POST', usersUrl + 'register', _headers, registerDetails)
            .then(function (response) {
                if (response.data.succeeded === false) {
                    console.log(response);
                    return response;
                    //showToast('An error occured. Please contact support.');
                }
                else {
                    return apiCall('POST', usersUrl + 'findByEmail', _headers, "{ email: '" + registerDetails.email + "'}")
                    .then(function (response) {
                        var gadaUser = {
                            id: response.data.id,
                            forename: registerDetails.firstName,
                            surname: registerDetails.lastName,
                            email: registerDetails.email,
                            city: registerDetails.city,
                            country: registerDetails.country,
                            username: ''
                        }
                        return apiCall('POST', rootUrl + 'create', _headers, gadaUser)
                        .then(function (response) {
                            return response;
                        })
                        .catch(function (err) {
                            console.log(err);
                            return err;
                            //commonServices.showToast('danger', 'An error occured. Please try again or contact support');
                        });
                    })
                    .catch(function (err) {
                        console.log(err);
                        return err;
                        //commonServices.showToast('danger', 'An error occured. Please try again or contact support');
                    });
                }

            })
            .catch(function (err) {
                console.log(err);
                return err;
                //commonServices.showToast('danger', 'An error occured. Please try again or contact support');
            });
        }

        function logout() {
            $sessionStorage.gadaUser = undefined;
            $state.go('home', {}, { reload: true });
        }

        function isAuthenticated() {
            if($sessionStorage.gadaUser) {
                return true;
            }

            return false;
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