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
var forms_1 = require("@angular/forms");
var data_storage_service_1 = require("../shared/data-storage.service");
var router_1 = require("@angular/router");
var SurveyComponent = (function () {
    function SurveyComponent(fb, dataStorageService, router) {
        this.fb = fb;
        this.dataStorageService = dataStorageService;
        this.router = router;
        this.surveyId = '';
        this.pollTypeId = '';
    }
    SurveyComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dataStorageService.currentSurvey.subscribe(function (survey) { return _this.surveyForm = survey; });
        this.surveyForm = this.fb.group({
            title: '',
            //location: '',
            pages: this.fb.array([this.initPages()])
        });
    };
    SurveyComponent.prototype.initPages = function () {
        return this.fb.group({
            questions: this.fb.array([this.initQuestion()])
        });
    };
    SurveyComponent.prototype.initQuestion = function () {
        return this.fb.group({
            //name: '',
            type: '',
        });
    };
    SurveyComponent.prototype.addQuestion = function (j) {
        //const questionArray = <FormArray>this.surveyForm.get['pages'].value[j].get['questions'];
        var questionArray = this.surveyForm.get('pages')['controls'][j]['controls']['questions'];
        console.log(questionArray);
        var newQuestion = this.initQuestion();
        questionArray.push(newQuestion);
    };
    SurveyComponent.prototype.removeQuestion = function (idx) {
        var questionsArray = this.surveyForm.controls['questions'];
        questionsArray.removeAt(idx);
    };
    SurveyComponent.prototype.getPages = function (form) {
        //console.log(form.get('sections').controls);
        return form.controls.pages.controls;
    };
    SurveyComponent.prototype.getQuestions = function (form) {
        //console.log(form.get('sections').controls);
        //return form.controls.questions.controls;
        return form.get('questions')['controls'];
    };
    SurveyComponent.prototype.onSubmit = function () {
        this.dataStorageService.onChangeSurvey(this.surveyForm);
        this.router.navigate(['test']);
        //const userId = localStorage.getItem('username');
        //const newSurvey = new Survey(userId, "asd", this.surveyForm.value['name'],
        //    this.surveyForm.value['location'], this.surveyForm.value['questions']);
        //this.dataStorageService.addSurvey(newSurvey);
    };
    return SurveyComponent;
}());
SurveyComponent = __decorate([
    core_1.Component({
        selector: 'app-survey',
        templateUrl: './survey.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, data_storage_service_1.DataStorageService, router_1.Router])
], SurveyComponent);
exports.SurveyComponent = SurveyComponent;
//# sourceMappingURL=survey.component.js.map