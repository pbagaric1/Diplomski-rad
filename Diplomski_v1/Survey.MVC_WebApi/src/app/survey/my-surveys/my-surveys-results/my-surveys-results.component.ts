import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NgSwitch } from '@angular/common';
import * as Survey from 'survey-angular';
import { DataStorageService } from '../../../shared/data-storage.service';
import { SurveyModel } from '../../models/survey.model';
import { Params, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-my-surveys-results',
    templateUrl: './my-surveys-results.component.html',
})
export class MySurveysResultsComponent implements OnInit {

    constructor(private dataStorageService: DataStorageService, private activatedRoute: ActivatedRoute) { }

    //surveys: SurveyModel[];
    surveyForm: any;
    surveyId: string;
    questions : any[];

    onDetails(survey: SurveyModel)
    {
        this.dataStorageService.onChangeSurvey(survey);
    }

    ngOnInit()
     {
        this.dataStorageService.currentSurvey.subscribe(survey => this.surveyForm = survey);
         this.questions = this.surveyForm.pages[0].questions;

        console.log(this.questions);


        // this.activatedRoute.params.subscribe((params: Params) => {
        //     this.surveyId = params['id'];
        //     console.log(this.surveyId);
        //   });

        // this.dataStorageService.getQuestionsBySurvey(this.surveyId)
        //     .subscribe(data => {
        //         this.questions = data;
        //         console.log(data);
        //     });
    }

}