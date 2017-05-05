'use strict';
app.factory('authService', ['$http', '$q',
'localStorageService', '$localStorage', '$window', function ($http, $q, localStorageService, $localStorage, $window) {

    var serviceBase = 'http://localhost:52797/';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _login = function (loginData) {

        var data = "grant_type=password&username=" +
        loginData.userName + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post(serviceBase + 'token', data, {
            headers:
            { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(function (response) {
            var dateTime = new Date();
            var miliseconds = dateTime.getTime();
            var expirationTime = miliseconds + response.data.expires_in * 1000;

            $localStorage.authData = {
                token: response.data.access_token,
                userName: loginData.userName,
                tokenExpiration: expirationTime

            };
            //localStorageService.set('authorizationData',
            //{ token: response.access_token, userName: loginData.userName, tokenExpiration: expirationTime });
            
            _authentication.isAuth = true;
            _authentication.userName = loginData.userName;

            deferred.resolve(response);

        }), (function (err, status) {
            $window.alert("Incorrect username or password.");
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;
    };

    var _logOut = function () {

        delete $localStorage.authData;
        //localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";
    };

    var _fillAuthData = function () {

        var authData = $localStorage.authData;
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }
    }

    var _checkExpiration = function () {
        var dateTime = new Date();
        var miliseconds = dateTime.getTime();

        if ($localStorage.authData != undefined) {
            var asd = $localStorage.authData.tokenExpiration;
            if (asd < miliseconds) {
                $window.alert("Token expired, log in again.")
                _logOut();
            }
        }
    }

   // authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.checkExpiration = _checkExpiration;

    return authServiceFactory;
}]);