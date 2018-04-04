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
var data_storage_service_1 = require("./../../../shared/data-storage.service");
var core_1 = require("@angular/core");
var Survey = require("survey-angular");
var SurveyItemComponent = /** @class */ (function () {
    function SurveyItemComponent(dataStorageService) {
        this.dataStorageService = dataStorageService;
    }
    SurveyItemComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dataStorageService.currentSurvey.subscribe(function (survey) { return _this.surveyForm = survey; });
        var surveyModel = new Survey.Model(this.surveyForm);
        surveyModel.mode = 'display';
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        console.log(this.surveyForm);
    };
    SurveyItemComponent = __decorate([
        core_1.Component({
            selector: 'app-survey-item',
            templateUrl: './survey-item.component.html',
        }),
        __metadata("design:paramtypes", [data_storage_service_1.DataStorageService])
    ], SurveyItemComponent);
    return SurveyItemComponent;
}());
exports.SurveyItemComponent = SurveyItemComponent;
//# sourceMappingURL=survey-item.component.js.map