import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../auth.service';

@Component({
    selector: 'app-signup',
    templateUrl: './signup.component.html'
})
export class SignupComponent implements OnInit {
    localUser = {
        userName: '',
        password: ''
    }
    constructor(private authService: AuthService) { }

    ngOnInit() {

    }

    onSignup() {
        console.log(this.localUser);
        this.authService.registerUser(this.localUser)
        .subscribe(
            (res) => {
                window.alert("Registration successful.");
            },
        (error) => {
            window.alert(error.statusText);
        }
            );
    }
}