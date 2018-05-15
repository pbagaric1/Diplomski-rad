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
   // @ViewChild('closeEdit') closeEdit: ElementRef;
    surveys: SurveyModel[];
    surveyId: string;
    selectedIndex: number;
    survey: SurveyModel;
    isVisible: boolean;
    userId : string;

    ngOnInit() {
        this.getSurveysByUser();
        this.userId = localStorage.getItem("userId");
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
        this.survey = survey;
        this.isVisible = survey.visibility;
        this.selectedIndex = index;
        console.log(this.isVisible);
    }

    onDeleteModal() {
        this.dataStorageService.deleteSurvey(this.surveyId)
            .subscribe(
                (res) => {
                    console.log(res);
                    window.alert("Survey deleted!")
                    this.surveys.splice(this.selectedIndex);
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

    this.closeModal();
    }

    getSurveysByUser() {
        const userId = localStorage.getItem('userId');
        this.dataStorageService.getSurveysByUsername(userId)
            .subscribe((data: any) => {
                this.surveys = data;
                console.log(data);
            });
    }

}