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
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var router_1 = require("@angular/router");
require("rxjs/Rx");
var BehaviorSubject_1 = require("rxjs/BehaviorSubject");
var DataStorageService = (function () {
    function DataStorageService(http, route) {
        this.http = http;
        this.route = route;
        this.surveySource = new BehaviorSubject_1.BehaviorSubject(this.value);
        this.currentSurvey = this.surveySource.asObservable();
    }
    DataStorageService.prototype.ngOnInit = function () {
    };
    DataStorageService.prototype.addSurvey = function (survey) {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var token = localStorage.getItem('auth_token');
        headers.append('Authorization', 'Bearer ' + token);
        return this.http.post('http://localhost:52797/api/poll/add', survey, { headers: headers })
            .subscribe(function (res) {
            console.log(res);
            window.alert("Survey added!");
        }, function (error) {
            console.log(error);
            window.alert(error.statusText);
        });
    };
    DataStorageService.prototype.addSurveyJson = function (survey) {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var token = localStorage.getItem('auth_token');
        headers.append('Authorization', 'Bearer ' + token);
        return this.http.post('http://localhost:52797/api/poll/add', survey, { headers: headers })
            .subscribe(function (res) {
            console.log(res);
        }, function (error) {
            console.log(error);
            window.alert(error.statusText);
        });
    };
    DataStorageService.prototype.getInputTypes = function () {
        return this.http.get('http://localhost:52797/api/inputtype/getall')
            .map(function (res) { return res.json(); });
    };
    DataStorageService.prototype.onChangeSurvey = function (survey) {
        this.surveySource.next(survey);
    };
    return DataStorageService;
}());
DataStorageService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        router_1.ActivatedRoute])
], DataStorageService);
exports.DataStorageService = DataStorageService;
//# sourceMappingURL=data-storage.service.js.map