import { Component, OnInit, TemplateRef, ViewChild, ElementRef } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { SurveyModel } from "./models/survey.model";
import { DataStorageService } from '../shared/data-storage.service';
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import * as Survey from 'survey-angular';


@Component({
    selector: 'app-survey-create',
    templateUrl: './survey-create.component.html'
})
export class SurveyCreateComponent implements OnInit{

    @ViewChild('closeBtn') closeBtn: ElementRef;
    surveyForm: FormGroup;
    surveyId: string = '';
    pollTypeId: string = '';
    selectedQuestion: string;
    jQuery : any;


    constructor(private fb: FormBuilder, private dataStorageService: DataStorageService,
        private router: Router, private datePipe: DatePipe) { }


        json1 = {
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
                }

    json = {
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

    ngOnInit() {
        this.dataStorageService.currentSurvey.subscribe(survey => this.surveyForm = survey);
        this.surveyForm = this.fb.group({
            title: '',
            organization: '',
            pages: this.fb.array([this.initPages()])
        });
    };

    onModalClick() {
        let surveyModel = new Survey.Model(this.surveyForm.value);
        surveyModel.mode = 'display';
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        console.log(surveyModel);
        console.log(this.surveyForm.value);
        //console.log(this.json1);
    }

    initPages() {
        return this.fb.group({
            questions: this.fb.array([this.initQuestion()])
        });
    }

    initQuestion() {
        return this.fb.group({
            type: '',
            name: '',
            isRequired: false
            //answers: this.fb.array([])
        });
    }

    addQuestion(j: any) {
        //const questionArray = <FormArray>this.surveyForm.get['pages'].value[j].get['questions'];
        const questionArray = <FormArray>this.surveyForm.get('pages')['controls'][j]['controls']['questions'];
        //console.log(questionArray);
        const newQuestion = this.initQuestion();
            
        questionArray.push(newQuestion);
    }

    removeQuestion(idx: number) {
        const questionsArray = <FormArray>this.surveyForm.get('pages')['controls'][idx]['controls']['questions'];
        questionsArray.removeAt(idx);
    }

    getPages(form: any) {
        //console.log(form.get('sections').controls);
        return form.controls.pages.controls;
    }

    getQuestions(form: any) {
        //console.log(form.get('sections').controls);
        //return form.controls.questions.controls;
        return (<FormArray>form.get('questions')['controls']);
    }

    private closeModal() {
        this.closeBtn.nativeElement.click();
    }

    onSubmit() {
        this.dataStorageService.onChangeSurvey(this.surveyForm);
        //this.router.navigate(['test']);

        const userId = localStorage.getItem('userId');
        let createdOn = this.datePipe.transform(Date.now(), 'dd-MM-yyyy HH:mm:ss a');

        const asd = this.surveyForm.controls;

        const newSurvey = new SurveyModel("", userId, this.surveyForm.value['title'],
            this.surveyForm.value['organization'], createdOn, this.surveyForm.value['pages'][0]['questions']);


        console.log(this.surveyForm);

        this.dataStorageService.addSurvey(newSurvey);
        console.log(newSurvey);
        this.closeModal();
    }
}