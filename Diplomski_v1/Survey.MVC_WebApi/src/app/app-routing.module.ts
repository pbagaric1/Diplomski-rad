import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MoviesComponent } from './movies/movies.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MovieDetailComponent } from './movies/movie-detail/movie-detail.component';
import { MovieEditComponent } from './movies/movie-edit/movie-edit.component';
import { SignupComponent } from './auth/signup/signup.component';
import { SigninComponent } from './auth/signin/signin.component';
import { BestRatedComponent } from './best-rated/best-rated.component';
import { AuthGuard } from './auth/auth-guard.service';
import { AdminGuard } from './auth/admin-guard.service';
import { GenresComponent } from './genres/genres.component';
import { GenreEditComponent } from './genres/genre-edit/genre-edit.component';

const appRoutes: Routes = [
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
        {path: 'movies', component: MoviesComponent, children: [
            { path: 'new', component: MovieEditComponent, canActivate: [AuthGuard] },
            { path: 'movieId/:id', component: MovieDetailComponent },
            { path: 'movieId/:id/edit', component: MovieEditComponent, canActivate: [AuthGuard] }

        ]
    },
        {
            path: 'genres', component: GenresComponent, canActivate: [AdminGuard], children: [
                { path: 'new', component: GenreEditComponent, canActivate: [AdminGuard] },
                { path: 'genreId/:id', component: GenreEditComponent, canActivate: [AdminGuard] }

            ]},

    { path: 'signup', component: SignupComponent },
    { path: 'signin', component: SigninComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'bestrated', component: BestRatedComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}