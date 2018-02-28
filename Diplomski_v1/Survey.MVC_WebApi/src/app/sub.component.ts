import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'sub-component',
    templateUrl: './sub.component.html'
})
export class SubComponent {
    @Input() myForm: FormGroup; // This component is passed a FormGroup from the base component template
}