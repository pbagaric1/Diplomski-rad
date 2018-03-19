import { SurveyModel } from './../survey/models/survey.model';
import { Component, Input, OnInit} from '@angular/core';
import { FormGroup } from '@angular/forms';
import * as Survey from 'survey-angular';
import { DataStorageService } from '../shared/data-storage.service';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

@Component({
    selector: 'app-test',
    template: `<div class="survey-container contentcontainer codecontainer">
<div id="surveyElement"></div>
<div id="surveyResult"></div>
</div>`,
    //styleUrls: ['./survey.css']
})
export class TestComponent implements OnInit {
    surveyForm: FormGroup;

    constructor(private dataStorageService: DataStorageService) {}

    json1 = {
        "title": "anketa",
        "pages": [
            {
                "questions": [
                    {
                        "title": "asd",
                        "type": "radiogroup",
                        "isRequired": false,
                        "choices": [
                            "1",
                            "2"
                        ]
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
        //this.dataStorageService.currentSurvey.subscribe(survey => this.surveyForm = survey);
        //let surveyModel = new Survey.ReactSurveyModel(this.surveyForm.value);
        let receivedSurvey: any;
        let surveyModel: any;
       this.dataStorageService.getSurvey()
           .subscribe(data => {
               receivedSurvey = data;
               console.log(receivedSurvey);
               surveyModel = new Survey.ReactSurveyModel(receivedSurvey);
               Survey.SurveyNG.render('surveyElement', { model: surveyModel });
           });
        console.log(this.json);
        
        let asd = new Survey.Model(receivedSurvey);

        asd
            .onComplete
            .add(function(result: any) {
                document
                    .querySelector('#surveyResult')
                    .innerHTML = "result: " + JSON.stringify(result.data);
                console.log(result.data);
                
            });
    }
}