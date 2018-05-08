import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { fadeInAnimation } from '../../animations/fade-in.animation';

@Component({
    selector: 'app-signin',
    templateUrl: './signin.component.html',
    styleUrls: ['./signin.component.css'],
    animations: [fadeInAnimation]
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