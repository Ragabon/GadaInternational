(function () {
    "use strict";

    angular.module('app', [
        'app.core',
        'app.menu',
        'app.home',
        'app.about',
        'app.login',
        'app.discussions',
        'app.interests',
        'app.posts',
        'app.news',
        'app.tweets',
        'app.profile'
    ]);

    //gada.directive('copyright', function () {
    //    return {
    //        restrict: 'E',
    //        link: function (scope, el, attrs) {
    //            var year = new Date().getFullYear();
    //            el.text('\u00A9Copyright ' + year);
    //        }
    //    };
    //});

})();