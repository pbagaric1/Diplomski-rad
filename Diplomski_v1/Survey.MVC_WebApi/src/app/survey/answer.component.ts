import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NgSwitch } from '@angular/common';

@Component({
    selector: 'app-answer',
    templateUrl: './answer.component.html',
})
export class AnswerComponent {

    @Input('group') answerGroup: FormGroup;
    @Input('type') questionType: any;
}