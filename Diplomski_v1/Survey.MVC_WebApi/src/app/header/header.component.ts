import { Component, OnInit } from '@angular/core';
import {AuthService} from "../auth/auth.service";

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html'
})
export class HeaderComponent{

    constructor(private authService: AuthService) { }

    loggedUser: string = localStorage.getItem('username');

    ngOnInit() {
        this.authService.userChanged.subscribe(loggedUser => {
            this.loggedUser = loggedUser;
        })
    }

    onLogout() {
        this.authService.logOut();
    }
}