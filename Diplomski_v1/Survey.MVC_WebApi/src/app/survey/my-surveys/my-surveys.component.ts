import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NgSwitch } from '@angular/common';
import * as Survey from 'survey-angular';
import { DataStorageService } from '../../shared/data-storage.service';
import { SurveyModel } from '../models/survey.model';

@Component({
    selector: 'app-my-surveys',
    templateUrl: './my-surveys.component.html',
})
export class MySurveysComponent implements OnInit {

    constructor(private dataStorageService: DataStorageService) {}

    surveys: SurveyModel[];

    ngOnInit()
    {
        const userId = localStorage.getItem('userId');
        this.dataStorageService.getSurveysByUsername(userId)
        .subscribe(data => {
            this.surveys = data;
            console.log(data);
        });
    }

    onDetails(survey: SurveyModel)
    {
        this.dataStorageService.onChangeSurvey(survey);
    }
    
}