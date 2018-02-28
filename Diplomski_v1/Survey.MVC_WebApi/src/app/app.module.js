"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var app_component_1 = require("./app.component");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var app_routing_module_1 = require("./app-routing.module");
var header_component_1 = require("./header/header.component");
var auth_service_1 = require("./auth/auth.service");
var signup_component_1 = require("./auth/signup/signup.component");
var signin_component_1 = require("./auth/signin/signin.component");
var survey_component_1 = require("./survey/survey.component");
var test_component_1 = require("./test/test.component");
var answer_component_1 = require("./survey/answer.component");
var question_component_1 = require("./survey/question.component");
var data_storage_service_1 = require("./shared/data-storage.service");
var dashboard_component_1 = require("./dashboard/dashboard.component");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            forms_1.ReactiveFormsModule,
            http_1.HttpModule,
            app_routing_module_1.AppRoutingModule],
        declarations: [app_component_1.AppComponent, header_component_1.HeaderComponent, signup_component_1.SignupComponent, signin_component_1.SigninComponent, survey_component_1.SurveyComponent, test_component_1.TestComponent,
            answer_component_1.AnswerComponent, question_component_1.QuestionComponent, dashboard_component_1.DashboardComponent],
        providers: [auth_service_1.AuthService, data_storage_service_1.DataStorageService],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map