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
//import {  Response, Headers, RequestOptions } from '@angular/http';
var router_1 = require("@angular/router");
require("rxjs/Rx");
var BehaviorSubject_1 = require("rxjs/BehaviorSubject");
var http_1 = require("@angular/common/http");
var DataStorageService = /** @class */ (function () {
    function DataStorageService(http, route) {
        this.http = http;
        this.route = route;
        this.surveySource = new BehaviorSubject_1.BehaviorSubject(this.surveyValue);
        this.currentSurvey = this.surveySource.asObservable();
        this.questionSource = new BehaviorSubject_1.BehaviorSubject(this.questionValue);
        this.currentQuestion = this.questionSource.asObservable();
        this.url = 'http://localhost:56645/api/';
    }
    DataStorageService.prototype.ngOnInit = function () {
    };
    DataStorageService.prototype.onChangeSurvey = function (survey) {
        this.surveySource.next(survey);
    };
    DataStorageService.prototype.onChangeQuestion = function (question) {
        this.questionSource.next(question);
    };
    DataStorageService.prototype.addSurvey = function (survey) {
        var headers = new http_1.HttpHeaders({ 'Content-Type': 'application/json' });
        var token = localStorage.getItem('auth_token');
        headers.append('Authorization', 'Bearer ' + token);
        return this.http.post(this.url + 'poll/add', survey, { headers: headers })
            .subscribe(function (res) {
            console.log(res);
            window.alert("Survey added!");
        }, function (error) {
            console.log(error);
            window.alert(error.statusText);
        });
    };
    DataStorageService.prototype.addSurveyJson = function (survey) {
        var headers = new http_1.HttpHeaders({ 'Content-Type': 'application/json' });
        var token = localStorage.getItem('auth_token');
        headers.append('Authorization', 'Bearer ' + token);
        return this.http.post(this.url + 'poll/add', survey, { headers: headers })
            .subscribe(function (res) {
            console.log(res);
        }, function (error) {
            console.log(error);
            window.alert(error.statusText);
        });
    };
    DataStorageService.prototype.addSurveyResults = function (resultsData) {
        var headers = new http_1.HttpHeaders({ 'Content-Type': 'application/json' });
        var token = localStorage.getItem('auth_token');
        headers.append('Authorization', 'Bearer ' + token);
        return this.http.post(this.url + 'answer/add', resultsData, { headers: headers })
            .subscribe(function (res) {
            console.log(res);
        }, function (error) {
            console.log(error);
            window.alert(error.statusText);
        });
    };
    DataStorageService.prototype.getSurvey = function () {
        return this.http.get(this.url + 'poll/getview?id=3d92a0c4-ed4d-4d46-a6cb-e5ef836003ce');
        // .map(res => res.json());
    };
    DataStorageService.prototype.getInputTypes = function () {
        return this.http.get(this.url + 'inputtype/getall');
        // .map(res => res.json());
    };
    DataStorageService.prototype.getSurveys = function (pageIndex, pageSize) {
        return this.http.get(this.url + 'poll/getnumberofpolls?pageIndex=' + pageIndex + '&pageSize=' + pageSize);
        //  .map(res => res.json());
    };
    DataStorageService.prototype.getSurveysByUsername = function (userId) {
        return this.http.get(this.url + 'poll/getbyusername?userId=' + userId);
        //  .map(res => res.json());
    };
    DataStorageService.prototype.getQuestionsBySurvey = function (surveyId) {
        return this.http.get(this.url + 'question/getbysurvey?pollId=' + surveyId);
        //  .map(res => res.json());
    };
    DataStorageService.prototype.getQuestionResults = function (questionId) {
        return this.http.get(this.url + 'answer/getquestionresults?questionId=' + questionId);
        //  .map(res => res.json());
    };
    DataStorageService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient,
            router_1.ActivatedRoute])
    ], DataStorageService);
    return DataStorageService;
}());
exports.DataStorageService = DataStorageService;
//# sourceMappingURL=data-storage.service.js.map