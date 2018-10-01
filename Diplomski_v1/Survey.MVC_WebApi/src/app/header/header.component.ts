import { Component, OnInit } from '@angular/core';
import {AuthService} from "../auth/auth.service";

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent{

    constructor(public authService: AuthService) { }
    userRole: string  = localStorage.getItem('userRole');
    loggedUser: string = localStorage.getItem('username');
    

    ngOnInit() {
        this.authService.userChanged.subscribe((response : string) => {
            this.loggedUser = response;
            this.loggedUser = this.loggedUser;
            this.userRole = localStorage.getItem('userRole');
            console.log(this.userRole);
        });
       
    }

    onLogout() {
        this.authService.logOut();
    }
}