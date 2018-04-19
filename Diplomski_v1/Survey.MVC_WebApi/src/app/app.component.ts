import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { Subscription } from 'rxjs';

export interface LoaderState {
  show: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})

export class AppComponent implements OnInit {

  form: FormGroup;
  name: FormControl;
  sortItem: FormArray;

  showSpinner: boolean;

  constructor(private _fb: FormBuilder) {
  }

  ngOnInit(): void {

    this.name = new FormControl('', [Validators.required]);
    this.sortItem = this._fb.array([this.initSort()]);

    this.form = this._fb.group({
      name: this.name,
      sortItem: this.sortItem
    });
  }

  initSort() {
    return this._fb.group({
      locationName: ['', [Validators.required]],
      locationItems: this._fb.array([
        this.initSortItems()
      ])
    })
  }

  initSortItems() {
    return this._fb.group({
      itemName: ['', [Validators.required]],
      itemPicture: ['', []],
    })
  }

  addSort() {
    this.sortItem.push(this.initSort());
  }

  addSortLocationItem(i?: number, t?: number) {
    const control: FormArray = <FormArray>this.sortItem.at(i).get('locationItems');
    control.push(this.initSortItems());
  }
}