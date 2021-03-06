import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignupComponent} from "./auth/signup/signup.component";
import { SigninComponent} from "./auth/signin/signin.component";
import { SurveyComponent} from "./survey/survey.component";
import { TestComponent } from "./test/test.component";
import { DashboardComponent } from "./dashboard/dashboard.component"

const appRoutes: Routes = [
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    { path: 'signup', component: SignupComponent},
    { path: 'signin', component: SigninComponent},
    { path: 'surveys', component: SurveyComponent },
    { path: 'test', component: TestComponent },
{ path: 'dashboard', component: DashboardComponent },

];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}