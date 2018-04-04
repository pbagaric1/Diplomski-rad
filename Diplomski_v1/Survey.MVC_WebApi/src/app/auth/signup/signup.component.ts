import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-signup',
    templateUrl: './signup.component.html'
})
export class SignupComponent implements OnInit {

    userRoles: string[] = ['Ispitivac', 'Ispitanik'];

    localUser = {
        userName: '',
        passwordHash: '',
        email: '',
        userRole: ''
    }
    constructor(private authService: AuthService, private router: Router) { }

    ngOnInit() {

    }

    onSignup() {
        console.log(this.localUser);
        this.authService.registerUser(this.localUser)
        .subscribe(
            (res) => {
                window.alert("Registration successful.");
                this.router.navigate(['signin']);
                
            },
        (error) => {
            window.alert(error.statusText);
        }
            );
    }
}