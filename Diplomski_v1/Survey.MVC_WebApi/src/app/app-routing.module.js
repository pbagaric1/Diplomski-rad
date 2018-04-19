"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var question_results_component_1 = require("./survey/my-surveys/my-surveys-results/question-results/question-results.component");
var my_surveys_results_component_1 = require("./survey/my-surveys/my-surveys-results/my-surveys-results.component");
var my_surveys_component_1 = require("./survey/my-surveys/my-surveys.component");
var survey_item_component_1 = require("./survey/survey-list/survey-item/survey-item.component");
var survey_list_component_1 = require("./survey/survey-list/survey-list.component");
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var signup_component_1 = require("./auth/signup/signup.component");
var signin_component_1 = require("./auth/signin/signin.component");
var survey_create_component_1 = require("./survey/survey-create.component");
var test_component_1 = require("./test/test.component");
var dashboard_component_1 = require("./dashboard/dashboard.component");
var survey_take_component_1 = require("./survey/survey-list/survey-take/survey-take.component");
var appRoutes = [
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    { path: 'signup', component: signup_component_1.SignupComponent },
    { path: 'signin', component: signin_component_1.SigninComponent },
    { path: 'createsurvey', component: survey_create_component_1.SurveyCreateComponent },
    { path: 'test', component: test_component_1.TestComponent },
    { path: 'surveys', component: survey_list_component_1.SurveyListComponent },
    { path: 'surveys/details', component: survey_item_component_1.SurveyItemComponent },
    { path: 'surveys/takesurvey', component: survey_take_component_1.SurveyTakeComponent },
    { path: 'dashboard', component: dashboard_component_1.DashboardComponent },
    { path: 'mysurveys', component: my_surveys_component_1.MySurveysComponent },
    { path: 'mysurveys/details', component: my_surveys_results_component_1.MySurveysResultsComponent },
    { path: 'mysurveys/details/questionresults', component: question_results_component_1.QuestionResults },
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        core_1.NgModule({
            imports: [router_1.RouterModule.forRoot(appRoutes)],
            exports: [router_1.RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
exports.AppRoutingModule = AppRoutingModule;
//# sourceMappingURL=app-routing.module.js.map