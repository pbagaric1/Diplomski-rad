import { SurveyModel } from './../../models/survey.model';
import { DataStorageService } from './../../../shared/data-storage.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NgSwitch } from '@angular/common';
import * as Survey from 'survey-angular';

@Component({
    selector: 'app-survey-item',
    templateUrl: './survey-item.component.html',
})
export class SurveyItemComponent implements OnInit {

    constructor(private dataStorageService: DataStorageService) {}

    surveyForm: SurveyModel;

    ngOnInit()
    {
        this.dataStorageService.currentSurvey.subscribe(survey => this.surveyForm = survey);
        let surveyModel = new Survey.Model(this.surveyForm);
        surveyModel.mode = 'display';
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        console.log(this.surveyForm);
    }
    
}