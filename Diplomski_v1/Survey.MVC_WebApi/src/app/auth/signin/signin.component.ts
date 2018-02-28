import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-signin',
    templateUrl: './signin.component.html'
})
export class SigninComponent implements OnInit {
    localUser = {
        userName: '',
        password: ''
    }
    constructor(private authService: AuthService, private router: Router) { }

    ngOnInit() {

    }

    onLogin() {
        this.authService.login(this.localUser);
    }
}