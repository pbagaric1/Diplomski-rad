import { SurveyModel } from './../survey/models/survey.model';
import { Component, Input, OnInit} from '@angular/core';
import { FormGroup } from '@angular/forms';
import * as Survey from 'survey-angular';
import { DataStorageService } from '../shared/data-storage.service';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { trigger, transition, query, style, stagger, keyframes, animate, state } from '@angular/animations';

@Component({
    selector: 'app-test',
    templateUrl: './test.component.html',
    styleUrls: ['./test.component.css']
    // trigger('fadeInAnimation', [
 
    //     // route 'enter' transition
    //     transition(':enter', [
 
    //         // css styles at start of transition
    //         style({ opacity: 0 }),
 
    //         // animation and styles at end of transition
    //         animate('.3s', style({ opacity: 1 }))
    //     ]),
    // ]
})
export class TestComponent {

}