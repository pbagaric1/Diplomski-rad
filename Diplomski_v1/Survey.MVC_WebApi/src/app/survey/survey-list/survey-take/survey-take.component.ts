import { AuthService } from '../../../auth/auth.service';
import { Observable } from 'rxjs/Observable';
import { SurveyModel } from '../../models/survey.model';
import { DataStorageService } from '../../../shared/data-storage.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import * as Survey from 'survey-angular';

@Component({
    selector: 'app-survey-take',
    templateUrl: './survey-take.component.html',
})
export class SurveyTakeComponent implements OnInit {

    surveyForm: SurveyModel;
    surveyId : any;
    asd : any;
    

    constructor(private dataStorageService: DataStorageService) { }

    ngOnInit() {
        const self = this;
        this.dataStorageService.currentSurvey.subscribe(survey => {
                this.surveyForm = survey;
                this.surveyId = survey;
            }   
        );
        let surveyModel = new Survey.Model(this.surveyForm);
        //surveyModel.mode = 'display';
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        //console.log(this.surveyId.Id);
        

        surveyModel
            .onComplete
            .add(function (result) {
                document
                    .querySelector('#surveyResult')
                    .innerHTML = "result: " + JSON.stringify(result.data);
                    console.log(result.data);
                    const userId = localStorage.getItem("userId");
                    console.log(userId);
                    console.log(self.surveyId.Id);
                    let resultsData = {
                        results: result.data,
                        userId : userId,
                        surveyId: self.surveyId.Id
                    };
                    self.dataStorageService.addSurveyResults(resultsData);
                
            });
    }
}