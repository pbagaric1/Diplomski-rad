import { SurveyModel } from './../survey/models/survey.model';
import { Injectable, OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class DataStorageService {

    value: any;
    private surveySource = new BehaviorSubject<any>(this.value);
    currentSurvey = this.surveySource.asObservable();

    constructor(private http: Http,
                private route: ActivatedRoute) {
    }

    ngOnInit() {
    }

    addSurvey(survey: SurveyModel) {
        const headers = new Headers({ 'Content-Type': 'application/json' });
        const token = localStorage.getItem('auth_token');
        headers.append('Authorization', 'Bearer ' + token);
        return this.http.post('http://localhost:52797/api/poll/add', survey, { headers: headers })
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
        const headers = new Headers({ 'Content-Type': 'application/json' });
        const token = localStorage.getItem('auth_token');
        headers.append('Authorization', 'Bearer ' + token);
        return this.http.post('http://localhost:52797/api/poll/add', survey, { headers: headers })
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
        return this.http.get('http://localhost:52797/api/poll/getview?id=3d92a0c4-ed4d-4d46-a6cb-e5ef836003ce')
            .map(res => res.json());
        
    }

    getInputTypes() {
        return this.http.get('http://localhost:52797/api/inputtype/getall')
            .map(res => res.json());
    }

    onChangeSurvey(survey: any) {
        this.surveySource.next(survey);
    }


}