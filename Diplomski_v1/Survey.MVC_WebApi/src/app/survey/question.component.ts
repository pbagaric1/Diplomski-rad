import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, FormControl } from '@angular/forms';

@Component({
    selector: 'app-question',
    templateUrl: './question.component.html'
})
export class QuestionComponent implements OnInit {
    @Input('group') questionGroup: FormGroup;
    questionTypes: string[] = ['text', 'radiogroup', 'checkbox', 'matrix', 'rating', 'comment'];
    selectedType: string;
    choices: FormArray[];

    constructor(private fb: FormBuilder) { }

    ngOnInit() {
        this.questionGroup.addControl("title", new FormControl(""));
        //console.log(this.questionGroup)
    }

    addAnswer() {
        const answerArray = <FormArray>this.questionGroup.controls['answers'];
        const newAnswer = this.initAnswer();

        answerArray.push(newAnswer);
        console.log(this.selectedType);
    }

    removeAnswer(idx: number) {
        const answerArray = <FormArray>this.questionGroup.controls['answers'];
        answerArray.removeAt(idx);
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
        case 'radiogroup':
        {
            this.questionGroup.removeControl("mininumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            this.questionGroup.addControl("choices", new FormArray([]));

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
            this.questionGroup.addControl("choices", new FormArray([]));
            break;
        }

        case 'matrix':
        {

            this.questionGroup.removeControl("mininumRateDescription");
            this.questionGroup.removeControl("maximumRateDescription");
            this.questionGroup.removeControl("columns");
            this.questionGroup.removeControl("rows");
            this.questionGroup.removeControl("choices");
            this.questionGroup.addControl("columns", new FormArray([]));
            this.questionGroup.addControl("rows", new FormArray([]));
            break;
        }
        }

    }
}