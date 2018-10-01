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
    showSurvey: boolean;

    ngOnInit() {
        const self = this;
        this.userId = localStorage.getItem("userId");
        this.dataStorageService.currentSurvey.subscribe(survey => {
            console.log(survey)
            this.survey = survey;
            this.surveyId = survey.Id;
        });

        this.dataStorageService.checkIfVoted(this.surveyId, this.userId).subscribe((response: boolean) => {
            console.log(response);
            this.showSurvey = response;
        });
        if (!this.showSurvey) {
            let surveyModel = new Survey.Model(this.survey);
            if (this.isExpired) {
                surveyModel.mode = 'display';
            }
            Survey.SurveyNG.render('surveyElement', { model: surveyModel });

            surveyModel
                .onComplete
                .add(function (result) {
                    document
                    console.log(result.data);
                    const userId = localStorage.getItem("userId");
                    console.log(userId);
                    console.log(self.surveyId);
                    let resultsData = {
                        results: result.data,
                        userId: userId,
                        surveyId: self.surveyId
                    };
                    self.dataStorageService.addSurveyResults(resultsData);

                });

        }

    }

    showQuestions() {
        if (this.questionsShown == true)
            this.questionsShown = false;
        else if (this.questionsShown == false)
            this.questionsShown = true;
    }

    compareDates(startTime: any, endTime: any) {
        if (this.getMillies(endTime) > this.currentTime && this.getMillies(startTime) < this.currentTime) {
            //console.log("end: ", this.getMillies(endTime), "current: ", this.currentTime);
            return "Active";
        }
        else if (this.getMillies(endTime) > this.currentTime && this.getMillies(startTime) > this.currentTime) {
            //console.log("end: ", this.getMillies(endTime), "current: ", this.currentTime);
            return "Inactive";
        }
        else return "Expired";
    }

    getMillies(input: any): number {
        return new Date(input).getTime();
    }
}