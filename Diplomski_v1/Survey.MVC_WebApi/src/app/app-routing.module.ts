import { IspitivacGuard } from './auth/ispitivac-guard.service';
import { QuestionResults } from './survey/my-surveys/my-surveys-results/question-results/question-results.component';
import { MySurveysResultsComponent } from './survey/my-surveys/my-surveys-results/my-surveys-results.component';
import { MySurveysComponent } from './survey/my-surveys/my-surveys.component';
import { SurveyItemComponent } from './survey/survey-list/survey-item/survey-item.component';
import { SurveyListComponent } from './survey/survey-list/survey-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignupComponent } from "./auth/signup/signup.component";
import { SigninComponent } from "./auth/signin/signin.component";
import { SurveyCreateComponent } from "./survey/survey-create.component";
import { TestComponent } from "./test/test.component";
import { DashboardComponent } from "./dashboard/dashboard.component"
import { SurveyTakeComponent } from './survey/survey-list/survey-take/survey-take.component';

const appRoutes: Routes = [
    { path: '', redirectTo: '/signin', pathMatch: 'full' },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'signin', component: SigninComponent },
    { path: 'createsurvey', component: SurveyCreateComponent, canActivate: [IspitivacGuard] },
    { path: 'test', component: TestComponent },
    { path: 'surveys', component: SurveyListComponent },
    { path: 'surveys/preview', component: SurveyItemComponent },
    { path: 'surveys/takesurvey', component: SurveyTakeComponent },
    { path: 'mysurveys', component: MySurveysComponent, canActivate: [IspitivacGuard] },
    { path: 'mysurveys/details', component: MySurveysResultsComponent, canActivate: [IspitivacGuard] },
    { path: 'mysurveys/details/questionresults', component: QuestionResults, canActivate: [IspitivacGuard] },
    //{ path: 'mysurveys/id/:id/questionId/:id', component: QuestionResults }

];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}