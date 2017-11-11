(function (args) {
    'use strict';
    angular.module('app')
        .directive('customercard', customercard)
        function CustomerCard() {
            return {
                restrict: 'E',
                transclude: true,
                scope: {
                    Id: '@',
                    FirstName: '@',
                    LastName: '@',
                    City: '@',
                    Country: '@',
                    Phone: '@'
                },
                templateUrl: 'app/private/customer/directives/customer-card/customer-card.html'
            }
        };
})();