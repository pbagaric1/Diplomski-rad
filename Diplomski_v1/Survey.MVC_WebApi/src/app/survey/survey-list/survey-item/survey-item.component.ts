import { SurveyModel } from './../../models/survey.model';
import { DataStorageService } from './../../../shared/data-storage.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NgSwitch } from '@angular/common';
import * as Survey from 'survey-angular';

@Component({
    selector: 'app-survey-item',
    templateUrl: './survey-item.component.html',
    styleUrls: ['./survey-item.component.css']
})
export class SurveyItemComponent implements OnInit {

    constructor(private dataStorageService: DataStorageService) { }

    survey: any;
    questionsShown: boolean = false;
    currentTime: number;
    isExpired: boolean = false;
    surveyId: any;
    userId: string;
    showSurvey: boolean = true ;

    ngOnInit() {
        const self = this;
        this.userId = localStorage.getItem("userId");
        this.currentTime = Date.now();
        this.currentTime = new Date(this.currentTime).getTime();
        
        this.dataStorageService.currentSurvey.subscribe(survey => {
            console.log(survey)
            this.survey = survey;
            this.surveyId = survey.Id;
        });

        this.dataStorageService.checkIfVoted(this.userId, this.surveyId).subscribe((response: boolean) => {
            console.log(response);
            this.showSurvey = !response;

            if (!this.showSurvey) {
                let surveyModel = new Survey.Model(this.survey)
                surveyModel.mode = 'display';
                Survey.SurveyNG.render('surveyElement', { model: surveyModel });
            }
    
            else {
                this.compareDates(this.survey.activityStartTime, this.survey.activityEndTime);
                let surveyModel = new Survey.Model(this.survey)
            if (this.isExpired) {
                surveyModel.mode = 'display';
            }
            Survey.SurveyNG.render('surveyElement', { model: surveyModel });
    
            surveyModel
                .onComplete
                .add(function (result) {
                    document
                    const userId = localStorage.getItem("userId");
                    let resultsData = {
                        results: result.data,
                        userId: userId,
                        surveyId: self.surveyId
                    };
                    self.dataStorageService.addSurveyResults(resultsData);
    
                });
            }
        });

        

        

    }


    showQuestions() {
        if (this.questionsShown == true)
            this.questionsShown = false;
        else if (this.questionsShown == false)
            this.questionsShown = true;
    }

    compareDates(startTime: any, endTime: any) {
        console.log(this.currentTime)
        if (this.getMillies(endTime) > this.currentTime && this.getMillies(startTime) < this.currentTime) {
            //console.log("end: ", this.getMillies(endTime), "current: ", this.currentTime);
            console.log("aktiv")
            this.isExpired = false;
        }
        else if (this.getMillies(endTime) > this.currentTime && this.getMillies(startTime) > this.currentTime) {
            //console.log("end: ", this.getMillies(endTime), "current: ", this.currentTime);
            console.log("inaktiv")
            this.isExpired = true;
        }
        else
        {
            this.isExpired = true;
            console.log("expir")
        } 
    }

    getMillies(input: any): number {
        return new Date(input).getTime();
    }
}