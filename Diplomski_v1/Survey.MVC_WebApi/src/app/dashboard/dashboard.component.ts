import { Component } from '@angular/core';
import { fadeInAnimation } from '../animations/fade-in.animation';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    animations: [fadeInAnimation],
    //host: { '[@fadeInAnimation]': '' }
})
export class DashboardComponent {

}