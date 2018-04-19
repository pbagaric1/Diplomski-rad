"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var Subject_1 = require("rxjs/Subject");
var AuthService = /** @class */ (function () {
    function AuthService(http, router) {
        this.http = http;
        this.router = router;
        this.userChanged = new Subject_1.Subject();
        this.userAdded = false;
        this.url = 'http://localhost:56645/api/';
    }
    AuthService.prototype.registerUser = function (localUser) {
        return this.http.post(this.url + 'user/add', localUser);
    };
    AuthService.prototype.login = function (usercreds) {
        var _this = this;
        this.isLogged = false;
        var headers = new http_1.HttpHeaders().set('Content-Type', 'application/X-www-form=urlencoded');
        var creds = 'grant_type=password&username=' + usercreds.userName + '&password=' + usercreds.password;
        //headers.append('Content-Type', 'application/X-www-form=urlencoded');
        return this.http.post(this.url + 'token', creds, { headers: headers })
            .subscribe(function (response) {
            console.log(response);
            _this.router.navigate(['/']);
            _this.loggedUser = response.username;
            window.localStorage.setItem('auth_token', response.access_token);
            window.localStorage.setItem('username', _this.loggedUser);
            window.localStorage.setItem('userId', response.userId);
            window.localStorage.setItem('userRole', response.userRole);
            _this.isLogged = true;
            _this.getLoggedUser(_this.loggedUser);
            console.log("Succesfully logged in");
        }, function (error) {
            console.log(error);
            window.alert("You entered wrong username or password.");
        });
    };
    AuthService.prototype.logOut = function () {
        window.localStorage.removeItem('auth_token');
        window.localStorage.removeItem('username');
        window.localStorage.removeItem('userId');
        window.localStorage.removeItem('userRole');
        this.router.navigate(['signin']);
    };
    AuthService.prototype.isAuthenticated = function () {
        if (localStorage.getItem('auth_token'))
            return true;
        else
            return false;
    };
    AuthService.prototype.isAdmin = function () {
        if (localStorage.getItem('username') == "admin")
            return true;
        else
            return false;
    };
    AuthService.prototype.isIspitanik = function () {
        if (localStorage.getItem('userRole') == "Ispitanik")
            return true;
        else
            return false;
    };
    AuthService.prototype.isIspitivac = function () {
        if (localStorage.getItem('userRole') == "Ispitivac")
            return true;
        else
            return false;
    };
    AuthService.prototype.getLoggedUser = function (currentUser) {
        this.userChanged.next(this.loggedUser);
    };
    AuthService.prototype.getToken = function () {
        return localStorage.getItem('auth_token');
    };
    AuthService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient, router_1.Router])
    ], AuthService);
    return AuthService;
}());
exports.AuthService = AuthService;
//# sourceMappingURL=auth.service.js.map