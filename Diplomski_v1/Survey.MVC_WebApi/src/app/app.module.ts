import { IspitivacGuard } from './auth/ispitivac-guard.service';
import { AdminGuard } from './auth/admin-guard.service';
import { CapitalizePipe } from './shared/capitalize.pipe';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { CustomChartComponent } from './shared/custom-chart.component';
import { QuestionResults } from './survey/my-surveys/my-surveys-results/question-results/question-results.component';
import { MySurveysComponent } from './survey/my-surveys/my-surveys.component';
import { SurveyTakeComponent } from './survey/survey-list/survey-take/survey-take.component';
import { SurveyItemComponent } from './survey/survey-list/survey-item/survey-item.component';
import { SurveyListComponent } from './survey/survey-list/survey-list.component';
import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpModule } from '@angular/http';
import {HttpClientModule} from '@angular/common/http';
import {AppRoutingModule} from './app-routing.module';
import {HeaderComponent} from "./header/header.component";
import {AuthService} from "./auth/auth.service";
import {SignupComponent} from "./auth/signup/signup.component";
import {SigninComponent} from "./auth/signin/signin.component";
import {SurveyCreateComponent} from "./survey/survey-create.component";
import {TestComponent} from "./test/test.component";
import { AnswerComponent} from "./survey/answer.component";
import { QuestionComponent} from "./survey/question.component";
import { DataStorageService } from "./shared/data-storage.service";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { DatePipe, AsyncPipe} from '@angular/common';
import {NgxPaginationModule} from 'ngx-pagination'; //importing ng2-pagination
import { MySurveysResultsComponent } from './survey/my-surveys/my-surveys-results/my-surveys-results.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './shared/token.interceptor';
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { AlertModule } from 'ngx-bootstrap';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@NgModule({
    imports: [BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        //HttpModule,
        HttpClientModule,
        AppRoutingModule,
        NgxPaginationModule,
        NgxChartsModule,
        BrowserAnimationsModule,
        LoadingBarHttpClientModule,
        AlertModule.forRoot(),
        NgbModule.forRoot(),
        BsDatepickerModule.forRoot()
    ],

    declarations: [AppComponent, HeaderComponent, SignupComponent, SigninComponent, SurveyCreateComponent, TestComponent,
        AnswerComponent, QuestionComponent, DashboardComponent, SurveyListComponent, SurveyItemComponent, SurveyTakeComponent,
        MySurveysComponent, MySurveysResultsComponent, QuestionResults, CustomChartComponent, CapitalizePipe],

    providers: [AuthService, DataStorageService, DatePipe, AsyncPipe, CapitalizePipe, AdminGuard, IspitivacGuard,
         { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true}
        ],

    bootstrap: [AppComponent]
})
export class AppModule {
}
