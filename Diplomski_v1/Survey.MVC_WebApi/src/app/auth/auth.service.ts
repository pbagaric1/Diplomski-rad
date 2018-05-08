import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class AuthService {
    constructor(private http: HttpClient, private router: Router) { }

    userChanged = new Subject<string>();

    isLogged: boolean;
    isAuth: boolean;
    loggedUser: string;
    userAdded = false;
    url: string = 'http://localhost:56645/api/';

    registerUser(localUser: any) {
        return this.http.post(this.url + 'user/add', localUser);
    }

    login(usercreds: any) {
        this.isLogged = false;
        const headers = new HttpHeaders().set('Content-Type', 'application/X-www-form=urlencoded');
        const creds = 'grant_type=password&username=' + usercreds.userName + '&password=' + usercreds.password;
        //headers.append('Content-Type', 'application/X-www-form=urlencoded');

        return this.http.post(this.url + 'token', creds, { headers : headers})
            .subscribe(
                (response: any) => {
                    console.log(response);
                    this.router.navigate(['/dashboard']);
                    this.loggedUser = response.username;
                    window.localStorage.setItem('auth_token', response.access_token);
                    window.localStorage.setItem('username', this.loggedUser);
                    window.localStorage.setItem('userId', response.userId);
                    window.localStorage.setItem('userRole', response.userRole);
                    this.isLogged = true;
                    this.getLoggedUser(this.loggedUser);
                    console.log("Succesfully logged in");
                },
                (error) => {
                    console.log(error);
                    window.alert("You entered wrong username or password.");
                }
            )
    }

    logOut() {
        window.localStorage.removeItem('auth_token');
        window.localStorage.removeItem('username');
        window.localStorage.removeItem('userId');
        window.localStorage.removeItem('userRole');
        this.router.navigate(['signin']);
        this.isLogged = false;
    }
    
    isLoggedIn() {
        return this.isLogged;
    }

    isAuthenticated() {
        if (localStorage.getItem('auth_token'))
            return true;
        else return false;
    }

    isAdmin() {
        if (localStorage.getItem('username') == "admin")
            return true;
        else return false;
    }

    isIspitanik() {
        if (localStorage.getItem('userRole') == "Ispitanik")
            return true;
        else return false;
    }

    isIspitivac() {
        if (localStorage.getItem('userRole') == "Ispitivac")
            return true;
        else return false;
    }

    getLoggedUser(currentUser: string) {
        this.userChanged.next(this.loggedUser);
    }

    getToken() {
        return localStorage.getItem('auth_token');
    }
}