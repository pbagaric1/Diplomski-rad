import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class AuthService {
    constructor(private http: Http, private router: Router) { }

    userChanged = new Subject<string>();

    isLogged: boolean;
    isAuth: boolean;
    loggedUser: string;
    userAdded = false;

    registerUser(localUser: any) {
        return this.http.post('http://localhost:52797/api/user/add', localUser);
    }

    login(usercreds: any) {
        this.isLogged = false;
        const headers = new Headers();
        const creds = 'grant_type=password&username=' + usercreds.userName + '&password=' + usercreds.password;
        headers.append('Content-Type', 'application/X-www-form=urlencoded');


        this.http.post('http://localhost:52797/api/token', creds, { headers: headers })
            .subscribe(
            (response: Response) => {
                this.router.navigate(['/']);
                this.loggedUser = response.json().username;
                window.localStorage.setItem('auth_token', response.json().access_token);
                window.localStorage.setItem('username', this.loggedUser);
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
        this.router.navigate(['signin']);
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


    getLoggedUser(currentUser: string) {
        this.userChanged.next(this.loggedUser);
    }
}