(function() {
    'use strict';

    angular.module('app.core', [
        /*
         * Angular modules
         */
        'ngAnimate', 'ngSanitize',
        /*
         * Our reusable cross app code modules
         */
        //'blocks.exception', 'blocks.logger', 'blocks.router',
        'common.services',
        /*
         * 3rd Party modules
         */
        'ui.router', 'ui.bootstrap', 'ngToast', 'textAngular', 'angularjs-gravatardirective', 'ngTagsInput', 'autocomplete', 'ngStorage' //'$state',
    ]);
})();
