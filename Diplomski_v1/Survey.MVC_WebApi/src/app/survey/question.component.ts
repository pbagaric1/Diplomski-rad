import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, FormControl } from '@angular/forms';
import { InputType } from './models/input-type.model';
import { DataStorageService } from '../shared/data-storage.service';

@Component({
    selector: 'app-question',
    templateUrl: './question.component.html'
})
export class QuestionComponent implements OnInit {
    @Input('group') questionGroup: FormGroup;
    questionTypes: InputType[];
    selectedType: InputType;
    choices: FormArray[];

    constructor(private fb: FormBuilder, private dataStorageService: DataStorageService) { }

    ngOnInit() {
        this.dataStorageService.getInputTypes().subscribe(
            (res) => {
                this.questionTypes = res;
                console.log(this.questionTypes);
            }
        );

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
        this.questionGroup.controls['title'].reset();
        switch (selectedType) {
        case 'Radiogroup':
        {
            this.questionGroup.removeControl("minimumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            this.questionGroup.addControl("choices", new FormArray([]));

            break;
        }
        case 'Rating':
        {

            this.questionGroup.removeControl("minimumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            this.questionGroup.addControl("minimumRateDescription", new FormControl(""));
            this.questionGroup.addControl("maximumRateDescription", new FormControl(""));
            break;
        }

        case 'Comment':
        {

            this.questionGroup.removeControl("minimumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            break;
        }

        case 'Checkbox':
        {

            this.questionGroup.removeControl("minimumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            this.questionGroup.addControl("choices", new FormArray([]));
            break;
        }

        case 'Matrix':
        {

            this.questionGroup.removeControl("minimumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            this.questionGroup.addControl("columns", new FormArray([]));
            this.questionGroup.addControl("rows", new FormArray([]));
            break;
                }

        case 'Text':
        {

            this.questionGroup.removeControl("minimumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            break;
        }
        }

    }
}