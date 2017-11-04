(function () {
    // -- 1ra parte
    //'use strict';
    // para registrar el controlador necesitamos de angulas
    //angular.module('app').controller('applicationController', applicationController);

    //    function applicationController() {
    //        var vm = this;
    //        vm.message="hola Angular"

    //    }
    // -- fin 1ra parte


    // -- 2da parte
    'use strict';
    angular.module('app').controller('applicationController', applicationController);

    applicationController.$inject = ['$scope', 'configService', 'authenticationService', 'localStorageService'];

    function applicationController($scope, configService, authenticationService, localStorageService) {
        var vm = this; vm.validate = validate; vm.logout = logout;

        $scope.init = function (url) {
            configService.setApiUrl(url);
        }

        function validate() {
            return configService.getLogin(); 
        }

        function logout() {
            authenticationService.logout();
        }

    }

})();