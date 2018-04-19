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
var Survey = require("survey-angular");
var SurveyCreateComponent = /** @class */ (function () {
    function SurveyCreateComponent(fb, dataStorageService, router, datePipe) {
        this.fb = fb;
        this.dataStorageService = dataStorageService;
        this.router = router;
        this.datePipe = datePipe;
        this.surveyId = '';
        this.pollTypeId = '';
        this.json1 = {
            "Id": "00000000-0000-0000-0000-000000000000",
            "title": "anketa",
            "userId": "d94d6498-2632-4fbc-bf8e-fde9e4fabbb5",
            "createdOn": "2018-03-18T04:48:33",
            "pages": [
                {
                    "questions": [
                        {
                            "title": "Koju zivotinju imate?",
                            "name": "zivotinja",
                            "type": "checkbox",
                            "isRequired": true,
                            "choices": [
                                "pas",
                                "macka",
                                "čuko"
                            ]
                        },
                        {
                            "title": "jeste li?",
                            "name": "jeste",
                            "type": "radiogroup",
                            "isRequired": true,
                            "choices": [
                                "da",
                                "ne"
                            ]
                        },
                        {
                            "title": "Koliko?",
                            "name": "koliko",
                            "type": "rating",
                            "isRequired": true,
                            "maximumRateDescription": "10",
                            "mininumRateDescription": "1"
                        },
                        {
                            "title": "Ocjenite ",
                            "name": "ocjena",
                            "type": "rating",
                            "isRequired": false,
                            "maximumRateDescription": "Hladno",
                            "mininumRateDescription": "Toplo"
                        }
                    ]
                }
            ]
        };
        this.json = {
            title: 'Product Feedback Survey Example',
            pages: [
                {
                    questions: [
                        {
                            type: 'matrix',
                            name: 'Quality',
                            title: 'Please indicate if you agree or disagree with the following statements',
                            columns: [
                                {
                                    value: 1,
                                    text: 'Strongly Disagree'
                                },
                                {
                                    value: 2,
                                    text: 'Disagree'
                                },
                                {
                                    value: 3,
                                    text: 'Neutral'
                                },
                                {
                                    value: 4,
                                    text: 'Agree'
                                },
                                {
                                    value: 5,
                                    text: 'Strongly Agree'
                                }
                            ],
                            rows: [
                                {
                                    value: 'affordable',
                                    text: 'Product is affordable'
                                },
                                {
                                    value: 'does what it claims',
                                    text: 'Product does what it claims'
                                },
                                {
                                    value: 'better then others',
                                    text: 'Product is better than other products on the market'
                                },
                                {
                                    value: 'easy to use',
                                    text: 'Product is easy to use'
                                }
                            ]
                        },
                        {
                            type: 'rating',
                            name: 'satisfaction',
                            title: 'How satisfied are you with the Product?',
                            mininumRateDescription: 'Not Satisfied',
                            maximumRateDescription: 'Completely satisfied'
                        },
                        {
                            type: 'rating',
                            name: 'recommend friends',
                            visibleIf: '{satisfaction} > 3',
                            title: 'How likely are you to recommend the Product to a friend or co-worker?',
                            mininumRateDescription: 'Will not recommend',
                            maximumRateDescription: 'I will recommend'
                        },
                        {
                            type: 'comment',
                            name: 'suggestions',
                            title: 'What would make you more satisfied with the Product?',
                        },
                    ]
                }
            ]
        };
    }
    SurveyCreateComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dataStorageService.currentSurvey.subscribe(function (survey) { return _this.surveyForm = survey; });
        this.surveyForm = this.fb.group({
            title: ['', forms_1.Validators.required],
            organization: ['', forms_1.Validators.required],
            pages: this.fb.array([this.initPages()])
        });
    };
    ;
    SurveyCreateComponent.prototype.onModalClick = function () {
        var surveyModel = new Survey.Model(this.surveyForm.value);
        surveyModel.mode = 'display';
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        console.log(surveyModel);
        console.log(this.surveyForm.value);
        //console.log(this.json1);
    };
    SurveyCreateComponent.prototype.initPages = function () {
        return this.fb.group({
            questions: this.fb.array([this.initQuestion()])
        });
    };
    SurveyCreateComponent.prototype.initQuestion = function () {
        return this.fb.group({
            type: ['', forms_1.Validators.required],
            name: ['', forms_1.Validators.required],
            isRequired: false
            //answers: this.fb.array([])
        });
    };
    SurveyCreateComponent.prototype.addQuestion = function (j) {
        //const questionArray = <FormArray>this.surveyForm.get['pages'].value[j].get['questions'];
        var questionArray = this.surveyForm.get('pages')['controls'][j]['controls']['questions'];
        //console.log(questionArray);
        var newQuestion = this.initQuestion();
        questionArray.push(newQuestion);
    };
    SurveyCreateComponent.prototype.removeQuestion = function (idArray, idQuestion) {
        console.log(idArray, idQuestion);
        var questionsArray = this.surveyForm.get('pages')['controls'][idArray]['controls']['questions'];
        questionsArray.removeAt(idQuestion);
    };
    SurveyCreateComponent.prototype.getPages = function (form) {
        //console.log(form.get('sections').controls);
        return form.controls.pages.controls;
    };
    SurveyCreateComponent.prototype.getQuestions = function (form) {
        //console.log(form.get('sections').controls);
        //return form.controls.questions.controls;
        return form.get('questions')['controls'];
    };
    SurveyCreateComponent.prototype.closeModal = function () {
        this.closeBtn.nativeElement.click();
    };
    SurveyCreateComponent.prototype.onSubmit = function () {
        this.dataStorageService.onChangeSurvey(this.surveyForm);
        //this.router.navigate(['test']);
        var userId = localStorage.getItem('userId');
        var createdOn = this.datePipe.transform(Date.now(), 'dd-MM-yyyy HH:mm:ss a');
        var asd = this.surveyForm.controls;
        var newSurvey = new survey_model_1.SurveyModel("", userId, this.surveyForm.value['title'], this.surveyForm.value['organization'], createdOn, this.surveyForm.value['pages'][0]['questions']);
        console.log(this.surveyForm);
        this.dataStorageService.addSurvey(newSurvey);
        console.log(newSurvey);
        this.closeModal();
    };
    __decorate([
        core_1.ViewChild('closeBtn'),
        __metadata("design:type", core_1.ElementRef)
    ], SurveyCreateComponent.prototype, "closeBtn", void 0);
    SurveyCreateComponent = __decorate([
        core_1.Component({
            selector: 'app-survey-create',
            templateUrl: './survey-create.component.html',
            styleUrls: ['./survey-create.component.css']
        }),
        __metadata("design:paramtypes", [forms_1.FormBuilder, data_storage_service_1.DataStorageService,
            router_1.Router, common_1.DatePipe])
    ], SurveyCreateComponent);
    return SurveyCreateComponent;
}());
exports.SurveyCreateComponent = SurveyCreateComponent;
//# sourceMappingURL=survey-create.component.js.map