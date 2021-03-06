﻿import { Component, Input, OnInit} from '@angular/core';
import { FormGroup } from '@angular/forms';
import * as Survey from 'survey-angular';
import { DataStorageService } from '../shared/data-storage.service';

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
        surveyId: '5af48e08-a0a5-44a5-83f4-1c90e8e98de1'
    };


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
                    }
                ]
            }
        ]
    };

    ngOnInit() {
        this.dataStorageService.currentSurvey.subscribe(survey => this.surveyForm = survey);
        let surveyModel = new Survey.ReactSurveyModel(this.surveyForm.value);
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        //console.log(this.surveyForm.value);
        //console.log(surveyModel.pages);
        let asd = new Survey.Model(this.surveyForm.value);

        surveyModel
            .onComplete
            .add(function(result) {
                document
                    .querySelector('#surveyResult')
                    .innerHTML = "result: " + JSON.stringify(result.data);
            });
    }
}