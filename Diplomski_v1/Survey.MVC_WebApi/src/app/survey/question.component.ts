import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, FormControl } from '@angular/forms';
import { InputType } from './models/input-type.model';
import { DataStorageService } from '../shared/data-storage.service';

@Component({
    selector: 'app-question',
    templateUrl: './question.component.html',
    styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {
    @Input('group') questionGroup: FormGroup;
    questionTypes: string[] = ['text', 'radiogroup', 'checkbox', 'rating'];
    selectedType: string;
    choices: FormArray[];

    constructor(private fb: FormBuilder, private dataStorageService: DataStorageService) { }

    ngOnInit() {
        // this.dataStorageService.getInputTypes().subscribe(
        //     (res) => {
        //         this.questionTypes = res;
        //         console.log(this.questionTypes);
        //     }
        // );

        this.questionGroup.addControl("title", new FormControl(""));
        //console.log(this.questionGroup)
    }

    

    //CHOICES
    initChoices() {
        return this.fb.group({
            formArray: this.fb.array([
                this.fb.control('')
            ])
        });
    }

    initAnswer() {
        return this.fb.group({
            text: ''
        });
    }

    addChoice() {
        const choiceArray = <FormArray>this.questionGroup.controls['choices'];
        const newChoice = this.initChoices();

        choiceArray.push(this.fb.control(''));

    }

    removeChoice(idx: number) {
        const choiceArray = <FormArray>this.questionGroup.controls['choices'];
        choiceArray.removeAt(idx);
    }

    //COLUMNS
    addColumn() {
        //const columnArray = <FormArray>this.questionGroup.controls['columns'];
        const columnArray = <FormArray>this.questionGroup.get('columns')['controls'];
        const newColumn = this.initColumns();

        columnArray.push(newColumn);
    }

    removeColumn(idx: number) {
        const columnArray = <FormArray>this.questionGroup.controls['columns'];
        columnArray.removeAt(idx);
    }

    initColumns() {
        return this.fb.group({
            text: '',
            value: ''
        });
    }

    //ROWS
    addRow() {
        const rowArray = <FormArray>this.questionGroup.controls['rows'];
        const newRow = this.initRows();

        rowArray.push(newRow);
    }

    removeRow(idx: number) {
        const rowArray = <FormArray>this.questionGroup.controls['rows'];
        rowArray.removeAt(idx);
    }

    initRows() {
        return this.fb.group({
            text: '',
            value: ''
        });
    }

    onChange(selectedType: string) {
        console.log(selectedType);
        this.questionGroup.controls['title'].reset();
        this.questionGroup.controls['name'].reset();
        switch (selectedType) {
        case 'radiogroup':
        {
            this.questionGroup.removeControl("mininumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");

            let fa = new FormArray([]);
            fa.push(this.fb.control(''));
            fa.push(this.fb.control(''));
            this.questionGroup.addControl("choices", fa);

            break;
        }
        case 'rating':
        {

            this.questionGroup.removeControl("mininumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            this.questionGroup.addControl("mininumRateDescription", new FormControl(""));
            this.questionGroup.addControl("maximumRateDescription", new FormControl(""));
            break;
        }

        case 'comment':
        {

            this.questionGroup.removeControl("mininumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            break;
        }

        case 'checkbox':
        {

            this.questionGroup.removeControl("mininumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            
            let fa = new FormArray([]);
            fa.push(this.fb.control(''));
            fa.push(this.fb.control(''));
            this.questionGroup.addControl("choices", fa);

            break;
        }

        //case 'Matrix':
        //{

        //    this.questionGroup.removeControl("minimumRateDescription");
        //    this.questionGroup.removeControl("maximumRateDescription");
        //    this.questionGroup.removeControl("columns");
        //    this.questionGroup.removeControl("rows");
        //    this.questionGroup.removeControl("choices");
        //    this.questionGroup.addControl("columns", new FormArray([]));
        //    this.questionGroup.addControl("rows", new FormArray([]));
        //    break;
        //        }

        case 'Text':
        {

            this.questionGroup.removeControl("mininumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            break;
        }
        }

    }
}