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
var data_storage_service_1 = require("../../../shared/data-storage.service");
var core_1 = require("@angular/core");
var Survey = require("survey-angular");
var SurveyTakeComponent = /** @class */ (function () {
    function SurveyTakeComponent(dataStorageService) {
        this.dataStorageService = dataStorageService;
    }
    SurveyTakeComponent.prototype.ngOnInit = function () {
        var _this = this;
        var self = this;
        this.dataStorageService.currentSurvey.subscribe(function (survey) {
            _this.surveyForm = survey;
            _this.surveyId = survey;
        });
        var surveyModel = new Survey.Model(this.surveyForm);
        //surveyModel.mode = 'display';
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        //console.log(this.surveyId.Id);
        surveyModel
            .onComplete
            .add(function (result) {
            document
                .querySelector('#surveyResult')
                .innerHTML = "result: " + JSON.stringify(result.data);
            console.log(result.data);
            var userId = localStorage.getItem("userId");
            console.log(userId);
            console.log(self.surveyId.Id);
            var resultsData = {
                results: result.data,
                userId: userId,
                surveyId: self.surveyId.Id
            };
            self.dataStorageService.addSurveyResults(resultsData);
        });
    };
    SurveyTakeComponent = __decorate([
        core_1.Component({
            selector: 'app-survey-take',
            templateUrl: './survey-take.component.html',
        }),
        __metadata("design:paramtypes", [data_storage_service_1.DataStorageService])
    ], SurveyTakeComponent);
    return SurveyTakeComponent;
}());
exports.SurveyTakeComponent = SurveyTakeComponent;
//# sourceMappingURL=survey-take.component.js.map