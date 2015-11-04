(function () {
    'use strict';

    var core = angular.module('app.core');

    core.config(ngToastConfig);

    /* @ngInject */
    function ngToastConfig(ngToastProvider) {
        ngToastProvider.configure({
            horizontalPosition: 'right',
            verticalPosition: 'bottom',
            dismissOnTimeout: true,
            timeout: 4000,
            dismissButton: false
        });
    }

    var config = {
        //appErrorPrefix: '[NG-Modular Error] ', //Configure the exceptionHandler decorator
        appTitle: 'Gada Beta',
        version: '1.0.0'
    };

    core.value('config', config);

    core.config(configure);

    /* @ngInject */
    function configure($stateProvider, $urlRouterProvider) {
        
        $urlRouterProvider.otherwise('/home');

        //need to put these into their own route.config files
        $stateProvider
           .state('home', {
               url: '/home',
               views: {
                   "menu": { templateUrl: 'app/shared/menu.html', controller: 'Menu', controllerAs: 'm' },
                   "content": { templateUrl: 'app/home/home.html', controller: 'Home', controllerAs: 'vm' }
               }
           })
            .state('about', {
                url: '/about',
                views: {
                    "menu": { templateUrl: 'app/shared/menu.html', controller: 'Menu', controllerAs: 'm' },
                    "content": { templateUrl: 'app/about/about.html', controller: 'About', controllerAs: 'vm' }
                }
            })
           .state('login', {
               url: '/login',
               views: {
                   "menu": { templateUrl: 'app/shared/menu.html', controller: 'Menu', controllerAs: 'm' },
                   "content": { templateUrl: 'app/login/login.html', controller: 'Login', controllerAs: 'vm' }
               }
           })
            .state('logout', {
                url: '/logout',
                views: {
                    "menu": { templateUrl: 'app/shared/menu.html', controller: 'Menu', controllerAs: 'm' },
                    "content": { templateUrl: 'app/login/logout.html', controller: 'Logout', controllerAs: 'vm' }
                }
            })
           .state('discussions', {
               url: '/discussions',
               views: {
                   "menu": { templateUrl: 'app/shared/menu.html', controller: 'Menu', controllerAs: 'm' },
                   "content": { templateUrl:  'app/discussions/discussionList.html', controller: 'DiscussionList', controllerAs: 'vm' }
               }
           })
           .state('discussion', {
               url: '/discussions/:id',
               views: {
                   "menu": { templateUrl: 'app/shared/menu.html', controller: 'Menu', controllerAs: 'm' },
                   "content": { templateUrl: 'app/discussions/discussionDetail.html', controller: 'DiscussionDetail', controllerAs: 'vm' }
               }
           })
           .state('create-discussion', {
               url: '/create-discussion',
               views: {
                   "menu": { templateUrl: 'app/shared/menu.html', controller: 'Menu', controllerAs: 'm' },
                   "content": { templateUrl: 'app/discussions/createDiscussion.html', controller: 'CreateDiscussion', controllerAs: 'vm' }
               }
           })
            .state('profile', {
                url: '/profile/:id',
                views: {
                    "menu": { templateUrl: 'app/shared/menu.html', controller: 'Menu', controllerAs: 'm' },
                    "content": { templateUrl: 'app/profile/profile.html', controller: 'Profile', controllerAs: 'vm' }
                }
            });
    }
})();
