import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';

import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpModule } from '@angular/http';
import {AppRoutingModule} from './app-routing.module';
import {HeaderComponent} from "./header/header.component";
import {AuthService} from "./auth/auth.service";
import {SignupComponent} from "./auth/signup/signup.component";
import {SigninComponent} from "./auth/signin/signin.component";
import {SurveyComponent} from "./survey/survey.component";
import {TestComponent} from "./test/test.component";
import { AnswerComponent} from "./survey/answer.component";
import { QuestionComponent} from "./survey/question.component";
import { DataStorageService } from "./shared/data-storage.service";
import { DashboardComponent } from "./dashboard/dashboard.component";

@NgModule({
    imports: [BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        AppRoutingModule],

    declarations: [AppComponent, HeaderComponent, SignupComponent, SigninComponent, SurveyComponent, TestComponent,
                     AnswerComponent, QuestionComponent, DashboardComponent],

    providers: [AuthService, DataStorageService],

    bootstrap: [AppComponent]
})
export class AppModule {
}
