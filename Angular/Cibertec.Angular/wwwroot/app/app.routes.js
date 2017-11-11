(function () {
    'use strict';
    angular.module('app').config(routeConfig);

    routeConfig.$inject = ['$stateProvider','$urlRouterProvider']

    // comenzadmos a usar elementos propios de angular
    function routeConfig($stateProvider, $urlRouterProvider) {
        // agregamos tabla de stado
        $stateProvider
            .state("home", {
                url: "/home",
                templateUrl:"app/home.html"
            })
            .state("login", {
                url: "/login",
                templateUrl:'app/public/login/index.html'
            })
            .state("product", {
                url: "/product",
                templateUrl: 'app/private/product/index.html'
            })
            .state("otherwise", {
                url: "/",
                templateUrl:"app/home.html"
            })

    }


})();