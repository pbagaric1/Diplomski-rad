'use strict';
app.controller('SignUpController', ['$scope', '$location', 
'$timeout', '$http', '$window',  function ($scope, $location, $timeout, $http, $window) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
        UserRole: "",
        FirstName: "",
        LastName: "",
        UserName: "",
        Email: "",
        PasswordHash: "",
        Age: "",
        Address: "",
        Place: "",

    };

    $scope.confirmedPassword = "";

    $scope.getRoles = function () {
        $http.get('/api/roles/getall')
        .then(function (response) {
            $scope.roles = response.data;

        }, function (response) {
            $window.alert(response.data.Message);
        })
    }

    $scope.signUp = function () {
        if ($scope.registration.FirstName != '' && $scope.registration.LastName != '' && $scope.registration.UserName != ''
            && $scope.registration.PasswordHash != '' && $scope.registration.Email != '' && $scope.registration.Age != '' && $scope.registration.Address != ''
            && $scope.registration.Place != '' && $scope.confirmedPassword != '')

            if ($scope.registration.PasswordHash != $scope.confirmedPassword) {
                $window.alert("Confirmed password is not same as password.");
            }

            else if ($scope.registration.PasswordHash.length < 6) {
                $window.alert("Password must have at least 6 characters.");
            }
            else {
                var user = {
                    UserRole: $scope.selectedRole.name,
                    FirstName: $scope.registration.FirstName,
                    LastName: $scope.registration.LastName,
                    UserName: $scope.registration.UserName,
                    Email: $scope.registration.Email,
                    Age: $scope.registration.Age,
                    Address: $scope.registration.Address,
                    Place: $scope.registration.Place,
                    PasswordHash: $scope.registration.PasswordHash
                };

                $http.post('api/user/add', user)
                .then(function (response) {
                    $window.alert("Registration successful.");
                    startTimer();
                }, function (response) {
                    $window.alert("Error : " + response.data);
                });
            }
    }
        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/login');
            }, 2000);
        }

}]);