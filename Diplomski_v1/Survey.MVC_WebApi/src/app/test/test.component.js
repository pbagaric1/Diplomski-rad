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
var Survey = require("survey-angular");
var data_storage_service_1 = require("../shared/data-storage.service");
var TestComponent = (function () {
    function TestComponent(dataStorageService) {
        this.dataStorageService = dataStorageService;
        this.json1 = {
            title: 'Product Feedback Survey Example',
            pages: [
                {
                    questions: [
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
                        {
                            type: "checkbox",
                            name: "car",
                            title: "What car are you driving?",
                            isRequired: true,
                            colCount: 4,
                            choices: [
                                "None",
                                "Ford",
                                "Vauxhall",
                                "Volkswagen",
                                "Nissan",
                                "Audi",
                                "Mercedes-Benz",
                                "BMW",
                                "Peugeot",
                                "Toyota",
                                "Citroen"
                            ]
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
    TestComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dataStorageService.currentSurvey.subscribe(function (survey) { return _this.surveyForm = survey; });
        //let surveyModel = new Survey.ReactSurveyModel(this.surveyForm.value);
        var surveyModel = new Survey.ReactSurveyModel(this.json1);
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        var asd = new Survey.Model(this.json1);
        surveyModel
            .onComplete
            .add(function (result) {
            document
                .querySelector('#surveyResult')
                .innerHTML = "result: " + JSON.stringify(result.data);
        });
    };
    return TestComponent;
}());
TestComponent = __decorate([
    core_1.Component({
        selector: 'app-test',
        template: "<div class=\"survey-container contentcontainer codecontainer\">\n<div id=\"surveyElement\"></div>\n<div id=\"surveyResult\"></div>\n</div>",
    }),
    __metadata("design:paramtypes", [data_storage_service_1.DataStorageService])
], TestComponent);
exports.TestComponent = TestComponent;
//# sourceMappingURL=test.component.js.map