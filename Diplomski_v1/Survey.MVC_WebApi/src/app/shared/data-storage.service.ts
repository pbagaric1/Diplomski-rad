import { Injectable, OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ActivatedRoute, Params } from '@angular/router';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import { Survey } from "../survey/survey.model";
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'

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

    addSurvey(survey: Survey) {
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

    onChangeSurvey(survey: any) {
        this.surveySource.next(survey);
    }


}