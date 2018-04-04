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
var data_storage_service_1 = require("../../shared/data-storage.service");
var MySurveysComponent = /** @class */ (function () {
    function MySurveysComponent(dataStorageService) {
        this.dataStorageService = dataStorageService;
    }
    MySurveysComponent.prototype.ngOnInit = function () {
        var _this = this;
        var userId = localStorage.getItem('userId');
        this.dataStorageService.getSurveysByUsername(userId)
            .subscribe(function (data) {
            _this.surveys = data;
            console.log(data);
        });
    };
    MySurveysComponent.prototype.onDetails = function (survey) {
        this.dataStorageService.onChangeSurvey(survey);
    };
    MySurveysComponent = __decorate([
        core_1.Component({
            selector: 'app-my-surveys',
            templateUrl: './my-surveys.component.html',
        }),
        __metadata("design:paramtypes", [data_storage_service_1.DataStorageService])
    ], MySurveysComponent);
    return MySurveysComponent;
}());
exports.MySurveysComponent = MySurveysComponent;
//# sourceMappingURL=my-surveys.component.js.map