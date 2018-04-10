"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var ngx_charts_1 = require("@swimlane/ngx-charts");
var custom_chart_component_1 = require("./shared/custom-chart.component");
var question_results_component_1 = require("./survey/my-surveys/my-surveys-results/question-results/question-results.component");
var my_surveys_component_1 = require("./survey/my-surveys/my-surveys.component");
var survey_take_component_1 = require("./survey/survey-list/survey-take/survey-take.component");
var survey_item_component_1 = require("./survey/survey-list/survey-item/survey-item.component");
var survey_list_component_1 = require("./survey/survey-list/survey-list.component");
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
var survey_create_component_1 = require("./survey/survey-create.component");
var test_component_1 = require("./test/test.component");
var answer_component_1 = require("./survey/answer.component");
var question_component_1 = require("./survey/question.component");
var data_storage_service_1 = require("./shared/data-storage.service");
var dashboard_component_1 = require("./dashboard/dashboard.component");
var common_1 = require("@angular/common");
var ngx_pagination_1 = require("ngx-pagination"); //importing ng2-pagination
var my_surveys_results_component_1 = require("./survey/my-surveys/my-surveys-results/my-surveys-results.component");
var animations_1 = require("@angular/platform-browser/animations");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [platform_browser_1.BrowserModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                http_1.HttpModule,
                app_routing_module_1.AppRoutingModule,
                ngx_pagination_1.NgxPaginationModule,
                ngx_charts_1.NgxChartsModule,
                animations_1.BrowserAnimationsModule
            ],
            declarations: [app_component_1.AppComponent, header_component_1.HeaderComponent, signup_component_1.SignupComponent, signin_component_1.SigninComponent, survey_create_component_1.SurveyCreateComponent, test_component_1.TestComponent,
                answer_component_1.AnswerComponent, question_component_1.QuestionComponent, dashboard_component_1.DashboardComponent, survey_list_component_1.SurveyListComponent, survey_item_component_1.SurveyItemComponent, survey_take_component_1.SurveyTakeComponent,
                my_surveys_component_1.MySurveysComponent, my_surveys_results_component_1.MySurveysResultsComponent, question_results_component_1.QuestionResults, custom_chart_component_1.CustomChartComponent],
            providers: [auth_service_1.AuthService, data_storage_service_1.DataStorageService, common_1.DatePipe, common_1.AsyncPipe],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map