(function () {
    "use strict";

    angular
        .module("app.login")
        .controller("Login", Login);

    function Login(loginData, $sessionStorage, $state) {
        var vm = this;
        vm.message = "";
        vm.pwMessage = '8 characters, 1 capital, 1 numerical, 1 special';
        vm.pwHadFocus = 0;

        vm.login = {
            email: '',
            password: ''
        };

        vm.register = { email: '', password: '', firstName: '', lastName: '', city: '', country: '' }

        vm.loginSubmit = function () {
            loginData.login(vm.login).then(function (response) {
                if (response.status === 200 && response.data !== null) {
                    var gum = { 'email': response.data.email };
                    loginData.getUser(gum).then(function (response) {
                        if (response.status === 200 && response.data !== null) {
                            $sessionStorage.gadaUser = response.data;
                            $state.go('home');
                        } else {
                            vm.message = "Incorrect email or password";
                            //commonServices.showToast('danger', 'Incorrect email or password');
                        }
                    });
                } else {
                    vm.message = "Incorrect email or password";
                    //commonServices.showToast('danger', 'Incorrect email or password');
                }
            });
        }

        vm.checkPw = function () {
            vm.pwHadFocus = 1;
            var pwChars = 8;
            //var upper = 0;
            var number = 0;
            //var special = 0;

            if (vm.register.password.length > 7) {
                pwChars = 0;
            }
            else {
                pwChars = (8 - vm.register.password.length);
            }

            vm.pwMessage = ''
            if (pwChars > 0) {
                vm.pwMessage = pwChars + ' characters';
            }

            for (var i = 0; i < vm.register.password.length; i++) {
                var char = vm.register.password.charAt(i);
                //if(char === char.toUpperCase()) {
                //    upper = 1;
                //}

                if (!isNaN(parseFloat(char)) && isFinite(char)) {
                    number = 1;
                }

                //if(/[~`!#$%\^&*+=\-\[\]\\';,/{}|\\":<>\?]/g.test(char)) {
                //    special = 1;
                //}
            }

            //if (upper === 0) {
            //    if (vm.pwMessage.length > 0) {
            //        vm.pwMessage += ', '
            //    }
            //    vm.pwMessage += '1 capital ';
            //}

            if (number === 0) {
                if (vm.pwMessage.length > 0) {
                    vm.pwMessage += ', '
                }
                vm.pwMessage += '1 numerical ';
            }

            //if (special === 0) {
            //    if (vm.pwMessage.length > 0) {
            //        vm.pwMessage += ', '
            //    }
            //    vm.pwMessage += '1 special';
            //}
        }

        vm.registerSubmit = function () {
            loginData.register(vm.register).then(function (response) {
                if (response.status === 200) {
                    vm.message = "Thank you for registering. Please login to continue";
                    vm.register = { email: '', password: '', firstName: '', lastName: '', city: '', country: '' }
                } else {
                    vm.message = "There was a problem during registration. Please try again";
                }
            });
        }
        //var req = {
        //    method: 'POST',
        //    url: registerUrl,
        //    headers: { 'Content-Type': 'application/json' },
        //    data: vm.register
        //}

        //$http(req).success(function (response) {
        //        if (response.succeeded === false)
        //        {
        //            vm.message = "An error occurred. Please contact support."
        //            console.log(response.errors);
        //        }
        //        else
        //        {
        //            var req = {
        //                method: 'GET',
        //                url: appSettings.loginServerPath + 'findByEmail/' + vm.register.email,
        //                headers: { 'Content-Type': 'application/json' },
        //                data: vm.register.email
        //            }

        //            $http(req).success(function (response) {
        //                var gadaUser = {
        //                    id: response.id,
        //                    forename: vm.register.firstName,
        //                    surname: vm.register.lastName,
        //                    email: vm.register.email,
        //                    username: ''
        //                }
        //                var req = {
        //                    method: 'POST',
        //                    url: appSettings.serverPath + 'user/create',
        //                    headers: { 'Content-Type': 'application/json' },
        //                    data: gadaUser
        //                }

        //                $http(req).success(function (response) {
        //                    vm.message = response;
        //                })
        //                .error(function (err) {
        //                    vm.message = err;
        //                });
        //            })
        //            .error(function (err)
        //            {
        //                vm.message = err;
        //            });

        //        }
        //    })
        //    .error(function (err) {
        //        console.log(err);
        //    });
        //}
    }
})();