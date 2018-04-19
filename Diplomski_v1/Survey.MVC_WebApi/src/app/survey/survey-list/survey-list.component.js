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
var auth_service_1 = require("./../../auth/auth.service");
var data_storage_service_1 = require("./../../shared/data-storage.service");
var core_1 = require("@angular/core");
var SurveyListComponent = /** @class */ (function () {
    function SurveyListComponent(dataStorageService, authService) {
        this.dataStorageService = dataStorageService;
        this.authService = authService;
        this.currentPage = 1;
        this.itemsPerPage = 5;
        this.showSpinner = true;
    }
    SurveyListComponent.prototype.ngOnInit = function () {
        this.pageChange(1);
    };
    SurveyListComponent.prototype.onDetails = function (survey) {
        this.dataStorageService.onChangeSurvey(survey);
    };
    SurveyListComponent.prototype.pageChange = function (page) {
        var _this = this;
        this.dataStorageService.getSurveys(page, this.itemsPerPage)
            .subscribe(function (data) {
            _this.showSpinner = false;
            _this.surveys = data.Data;
            _this.totalItems = data.Total;
            _this.currentPage = page;
            console.log(data);
        });
    };
    ;
    SurveyListComponent = __decorate([
        core_1.Component({
            selector: 'app-survey-list',
            templateUrl: './survey-list.component.html',
        }),
        __metadata("design:paramtypes", [data_storage_service_1.DataStorageService, auth_service_1.AuthService])
    ], SurveyListComponent);
    return SurveyListComponent;
}());
exports.SurveyListComponent = SurveyListComponent;
//# sourceMappingURL=survey-list.component.js.map