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
var survey_model_1 = require("./models/survey.model");
var data_storage_service_1 = require("../shared/data-storage.service");
var router_1 = require("@angular/router");
var common_1 = require("@angular/common");
var SurveyComponent = (function () {
    function SurveyComponent(fb, dataStorageService, router, datePipe) {
        this.fb = fb;
        this.dataStorageService = dataStorageService;
        this.router = router;
        this.datePipe = datePipe;
        this.surveyId = '';
        this.pollTypeId = '';
    }
    SurveyComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dataStorageService.currentSurvey.subscribe(function (survey) { return _this.surveyForm = survey; });
        this.surveyForm = this.fb.group({
            title: '',
            organization: '',
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
            type: '',
            isRequired: false
            //answers: this.fb.array([])
        });
    };
    SurveyComponent.prototype.addQuestion = function (j) {
        //const questionArray = <FormArray>this.surveyForm.get['pages'].value[j].get['questions'];
        var questionArray = this.surveyForm.get('pages')['controls'][j]['controls']['questions'];
        //console.log(questionArray);
        var newQuestion = this.initQuestion();
        questionArray.push(newQuestion);
    };
    SurveyComponent.prototype.removeQuestion = function (idx) {
        var questionsArray = this.surveyForm.get('pages')['controls'][idx]['controls']['questions'];
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
        //this.router.navigate(['test']);
        var userId = localStorage.getItem('userId');
        var createdOn = this.datePipe.transform(Date.now(), 'yyyy-MM-dd hh:mm:ss');
        var newSurvey = new survey_model_1.Survey(userId, this.surveyForm.value['title'], this.surveyForm.value['organization'], createdOn, this.surveyForm.value['pages'][0]['questions']);
        console.log(this.surveyForm);
        var json = {
            "title": "Anketa",
            "organization": "Konzum",
            "questions": [
                {
                    "type": "Text",
                    "isRequired": true,
                    "title": "Prvo"
                },
                {
                    "type": "Radiogroup",
                    "isRequired": false,
                    "title": "Drugo",
                    "choices": [
                        "1",
                        "2"
                    ]
                }
            ]
        };
        this.dataStorageService.addSurvey(newSurvey);
        console.log(newSurvey);
        //this.dataStorageService.addSurveyJson(json);
    };
    return SurveyComponent;
}());
SurveyComponent = __decorate([
    core_1.Component({
        selector: 'app-survey',
        templateUrl: './survey.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, data_storage_service_1.DataStorageService,
        router_1.Router, common_1.DatePipe])
], SurveyComponent);
exports.SurveyComponent = SurveyComponent;
//# sourceMappingURL=survey.component.js.map