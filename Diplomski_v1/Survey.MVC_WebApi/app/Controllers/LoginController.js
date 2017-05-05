'use strict';
app.controller('LoginController', ['$scope', '$location',
'authService', '$window', function ($scope, $location, authService, $window) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";
    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {
            $location.path('/home');

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };

}]);