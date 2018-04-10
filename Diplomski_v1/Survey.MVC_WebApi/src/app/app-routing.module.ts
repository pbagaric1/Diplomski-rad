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
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    { path: 'signup', component: SignupComponent },
    { path: 'signin', component: SigninComponent },
    { path: 'createsurvey', component: SurveyCreateComponent },
    { path: 'test', component: TestComponent },
    { path: 'surveys', component: SurveyListComponent },
    { path: 'surveys/id/:id', component: SurveyItemComponent },
    { path: 'surveys/takesurvey/id/:id', component: SurveyTakeComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'mysurveys', component: MySurveysComponent },
    { path: 'mysurveys/id/:id', component: MySurveysResultsComponent },
    { path: 'questionresults', component: QuestionResults },
    { path: 'mysurveys/id/:id/questionId/:id', component: QuestionResults }

];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}