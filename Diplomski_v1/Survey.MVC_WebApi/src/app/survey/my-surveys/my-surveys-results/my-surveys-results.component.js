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
var data_storage_service_1 = require("../../../shared/data-storage.service");
var router_1 = require("@angular/router");
var MySurveysResultsComponent = /** @class */ (function () {
    function MySurveysResultsComponent(dataStorageService, activatedRoute) {
        this.dataStorageService = dataStorageService;
        this.activatedRoute = activatedRoute;
    }
    MySurveysResultsComponent.prototype.onDetails = function (question) {
        this.dataStorageService.onChangeQuestion(question);
    };
    MySurveysResultsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dataStorageService.currentSurvey.subscribe(function (survey) { return _this.surveyForm = survey; });
        this.questions = this.surveyForm.pages[0].questions;
        console.log(this.questions);
        // this.activatedRoute.params.subscribe((params: Params) => {
        //     this.surveyId = params['id'];
        //     console.log(this.surveyId);
        //   });
        // this.dataStorageService.getQuestionsBySurvey(this.surveyId)
        //     .subscribe(data => {
        //         this.questions = data;
        //         console.log(data);
        //     });
    };
    MySurveysResultsComponent = __decorate([
        core_1.Component({
            selector: 'app-my-surveys-results',
            templateUrl: './my-surveys-results.component.html',
        }),
        __metadata("design:paramtypes", [data_storage_service_1.DataStorageService, router_1.ActivatedRoute])
    ], MySurveysResultsComponent);
    return MySurveysResultsComponent;
}());
exports.MySurveysResultsComponent = MySurveysResultsComponent;
//# sourceMappingURL=my-surveys-results.component.js.map