import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { fadeInAnimation } from '../../animations/fade-in.animation';

@Component({
    selector: 'app-signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.css'],
    animations: [fadeInAnimation],
    
})
export class SignupComponent implements OnInit {

    userRoles: string[] = ['Select your role', 'Ispitivac', 'Ispitanik'];

    localUser = {
        userName: '',
        passwordHash: '',
        confirmPassword: '',
        email: '',
        userRole: ''
    }
    constructor(private authService: AuthService, private router: Router) { }

    ngOnInit() {

    }

    onSignup() {
        if(this.localUser.passwordHash != this.localUser.confirmPassword)
        window.alert("Passwords don't match. Try again.")
        else {
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
}