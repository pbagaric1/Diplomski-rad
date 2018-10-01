import { Component, Input, OnInit, ViewChild, ElementRef } from '@angular/core';
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

    constructor(private dataStorageService: DataStorageService) { }

    @ViewChild('closeBtn') closeBtn: ElementRef;
    @ViewChild('closeEdit') closeEdit: ElementRef;
    surveys: SurveyModel[];
    surveyId: string;
    selectedIndex: number;
    survey: SurveyModel;
    isVisible: boolean;
    userId : string;
    initialEndDate: any;
    activityEndDate: any;

    minDate: Date;

    ngOnInit() {
        this.getSurveysByUser();
        this.userId = localStorage.getItem("userId");

        this.minDate = new Date();
        this.minDate.setDate(this.minDate.getDate() + 1);
    }

    private closeModal() {
        this.closeBtn.nativeElement.click();
      //  this.closeEdit.nativeElement.click();
    }

    onDetails(survey: SurveyModel) {
        this.dataStorageService.onChangeSurvey(survey);
    }

    onDelete(id: string, index: number) {
        this.surveyId = id;
        this.selectedIndex = index;
        console.log(this.selectedIndex)
        console.log(id);
    }

    logAsd(value: boolean)
    {
        this.isVisible = value;
        console.log(this.isVisible);
        this.survey.visibility = this.isVisible;
        this.survey.userId = this.userId;
    }

    onEdit(survey: any, index: number) {
        console.log(survey);
        this.survey = survey;
        this.isVisible = survey.visibility;
        this.selectedIndex = index;
        let endDate = new Date(survey.activityEndTime);
        this.initialEndDate = endDate;
       
    }

    onDeleteModal() {
        this.dataStorageService.deleteSurvey(this.surveyId)
            .subscribe(
                (res) => {
                    console.log(res);
                    window.alert("Survey deleted!")
                    this.surveys.splice(this.selectedIndex, 1);
                    //this.getSurveysByUser();
                },
                (error) => {
                    console.log(error);
                    window.alert(error.statusText);
                }
            );

        this.closeModal();
    }

    onEditModal() {
        this.survey.activityEndTime = this.activityEndDate;
        this.dataStorageService.editSurvey(this.survey)
        .subscribe(
            (res) => {
                console.log(res);
                window.alert("Survey updated!")
                //this.getSurveysByUser();
            },
            (error) => {
                console.log(error);
                window.alert(error.statusText);
            }
        );

        this.closeEdit.nativeElement.click();
    }

    getSurveysByUser() {
        const userId = localStorage.getItem('userId');
        this.dataStorageService.getSurveysByUsername(userId)
            .subscribe((data: any) => {
                this.surveys = data;
                console.log(data);
            });
    }

    onChange(survey) {
        if (this.survey.visibility == true)
          this.survey.visibility = false;
        else if (this.survey.visibility == false)
          this.survey.visibility = true;
      }

}