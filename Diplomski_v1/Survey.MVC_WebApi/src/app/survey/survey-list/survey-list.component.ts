import { AuthService } from './../../auth/auth.service';
import { Observable } from 'rxjs/Observable';
import { SurveyModel } from './../models/survey.model';
import { DataStorageService } from './../../shared/data-storage.service';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

export interface PagedResponse<T> {
    total: number;
    surveys: SurveyModel[];
}

@Component({
    selector: 'app-survey-list',
    templateUrl: './survey-list.component.html',
})
export class SurveyListComponent implements OnInit {

    constructor(private dataStorageService: DataStorageService, private authService : AuthService) {}

    private currentPage: number = 1;
    private totalItems: number;
    private _data: Observable<SurveyModel[]>;
    private itemsPerPage : number =  5;

    surveys: any[];

    showSpinner : boolean = true;

    ngOnInit() {
        this.pageChange(1);
    }

    onDetails(survey: SurveyModel)
    {
        this.dataStorageService.onChangeSurvey(survey);
    }

    pageChange(page: any) {
        this.dataStorageService.getSurveys(page, this.itemsPerPage)
            .subscribe((data : any) => {
                this.showSpinner = false;
                    this.surveys = data.Data;
                    this.totalItems = data.Total;
                    this.currentPage = page;
                    console.log(data);
                }
            )};
    
}