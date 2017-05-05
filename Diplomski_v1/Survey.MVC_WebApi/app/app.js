var serviceBase = 'http://localhost:52797/';

var app = angular.module('SurveyModule', ['ui.router', 'LocalStorageModule', 'ngStorage']);

app.config(function ($stateProvider, $urlRouterProvider) {


    $stateProvider
        .state('home', {
            url: '/home',
            controller: 'HomeController',
            views: {
                "root": {
                    templateUrl: 'App/Views/Home.html'
                }
            }
        })
        .state('login', {
            url: '/login',
            controller: 'LoginController',
            views: {
                "root": {
                    templateUrl: 'App/Views/Login.html'
                }
            }
        })
    .state('signup', {
        url: '/signup',
        controller: 'SignUpController',
        views: {
            "root": {
                templateUrl: 'App/Views/SignUp.html'
            }
        }
    });
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.run(['authService', function (authService) {
    authService.checkExpiration();
}]);

//app.config(function ($httpProvider) {
//    $httpProvider.interceptors.push('authInterceptorService');
//});