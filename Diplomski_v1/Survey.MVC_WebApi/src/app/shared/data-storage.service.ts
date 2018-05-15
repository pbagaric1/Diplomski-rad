import { SurveyModel } from './../survey/models/survey.model';
import { Injectable, OnInit } from '@angular/core';
//import {  Response, Headers, RequestOptions } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class DataStorageService {

    surveyValue: any;
    questionValue: any;
    private surveySource = new BehaviorSubject<any>(this.surveyValue);
    currentSurvey = this.surveySource.asObservable();
    private questionSource = new BehaviorSubject<any>(this.questionValue);
    currentQuestion = this.questionSource.asObservable();

    url: string = 'http://localhost:56645/api/';

    constructor(private http: HttpClient,
                private route: ActivatedRoute) {
    }

    ngOnInit() {
    }

    onChangeSurvey(survey: any) {
        this.surveySource.next(survey);
    }

    onChangeQuestion(question: any) {
        this.questionSource.next(question);
    }

    addSurvey(survey: SurveyModel) {
        // const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        // const token = localStorage.getItem('auth_token');
        // headers.append('Authorization', 'Bearer ' + token);
        return this.http.post(this.url + 'poll/add', survey )
            .subscribe(
                (res) => {
                    console.log(res);
                    window.alert("Survey added!")
                },
                (error) => {
                    console.log(error);
                    window.alert(error.statusText);
                }
            );
    }

    addSurveyJson(survey: any) {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        const token = localStorage.getItem('auth_token');
        headers.append('Authorization', 'Bearer ' + token);
        return this.http.post(this.url + 'poll/add', survey, { headers: headers })
            .subscribe(
                (res) => {
                    console.log(res);
                },
                (error) => {
                    console.log(error);
                    window.alert(error.statusText);
                }
            );
    }

    addSurveyResults(resultsData: any) {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        const token = localStorage.getItem('auth_token');
        headers.append('Authorization', 'Bearer ' + token);
        return this.http.post(this.url + 'answer/add', resultsData, { headers: headers })
            .subscribe(
                (res) => {
                    console.log(res);
                },
                (error) => {
                    console.log(error);
                    window.alert(error.statusText);
                }
            );
    }

    getSurvey() {
        return this.http.get(this.url + 'poll/getview?id=3d92a0c4-ed4d-4d46-a6cb-e5ef836003ce')
           // .map(res => res.json());
    }

    getInputTypes() {
        return this.http.get(this.url + 'inputtype/getall')
           // .map(res => res.json());
    }

    getSurveys(pageIndex: number, pageSize: number) {
        return this.http.get(this.url + 'poll/getnumberofpolls?pageIndex=' + pageIndex + '&pageSize=' + pageSize)
          //  .map(res => res.json());
        
    }

    getSurveysByUsername(userId: string) {
        return this.http.get(this.url + 'poll/getbyusername?userId=' + userId)
          //  .map(res => res.json());
        
    }

    getQuestionsBySurvey(surveyId: string) {
        return this.http.get(this.url + 'question/getbysurvey?pollId=' + surveyId)
          //  .map(res => res.json());
        
    }

    getQuestionResults(questionId: string) {
        return this.http.get(this.url + 'answer/getquestionresults?questionId=' + questionId)
          //  .map(res => res.json());
    }

    deleteSurvey(surveyId: string) {
        return this.http.delete(this.url + 'poll/delete?id=' + surveyId )
    }

    editSurvey(survey: SurveyModel) {
        return this.http.put(this.url + 'poll/edit',  survey )
    }


}