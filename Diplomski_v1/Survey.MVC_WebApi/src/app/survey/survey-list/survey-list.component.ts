import { DatePipe } from '@angular/common';
import { AuthService } from './../../auth/auth.service';
import { Observable } from 'rxjs/Observable';
import { SurveyModel } from './../models/survey.model';
import { DataStorageService } from './../../shared/data-storage.service';
import { Component, Input, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
//import { MatSort, MatPaginator } from '@angular/material';

export interface PagedResponse<T> {
    total: number;
    surveys: SurveyModel[];
}

@Component({
    selector: 'app-survey-list',
    templateUrl: './survey-list.component.html',
    styleUrls: ['./survey-list.component.css']
})
export class SurveyListComponent implements OnInit {

    constructor(private dataStorageService: DataStorageService, private authService: AuthService,
        private datePipe: DatePipe) { }

    // @ViewChild(MatSort) sort: MatSort;
    // @ViewChild(MatPaginator) paginator: MatPaginator;
    // @ViewChild('filter') filter: ElementRef;

    currentPage: number = 1;
    totalItems: number;
    itemsPerPage: number = 10;

    // displayedColumns = ['title', 'activityEndTime', 'userName', 'createdOn'];
    // dataSource: ExampleDataSource | null;
    // exampleDatabase = new TaskService(this.httpClient, this.database);


    surveyEndTime: string;
    currentTime: number;

    surveys: any[];

    showSpinner: boolean = true;

    ngOnInit() {
        this.pageChange(1);

        this.currentTime = Date.now();
        this.currentTime = new Date(this.currentTime).getTime();
        //console.log(this.currentTime);
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

    onDetails(survey: SurveyModel) {
        this.dataStorageService.onChangeSurvey(survey);
    }

    pageChange(page: any) {
        this.dataStorageService.getSurveys(page, this.itemsPerPage)
            .subscribe((data: any) => {
                this.showSpinner = false;
                this.surveys = data.Data;
                this.totalItems = data.Total;
                this.currentPage = page;
                console.log(data);
            }
            )
    };

}
