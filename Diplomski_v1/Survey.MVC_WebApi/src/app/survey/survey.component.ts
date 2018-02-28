import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { Survey } from "./survey.model";
import { DataStorageService } from '../shared/data-storage.service';
import { Question } from "./question/question.model";
import { Router } from '@angular/router';

@Component({
    selector: 'app-survey',
    templateUrl: './survey.component.html'
})
export class SurveyComponent implements OnInit{

    surveyForm: FormGroup;
    surveyId: string = '';
    pollTypeId: string = '';
    selectedQuestion: string;

    constructor(private fb: FormBuilder, private dataStorageService: DataStorageService, private router: Router) { }

    ngOnInit() {
        this.dataStorageService.currentSurvey.subscribe(survey => this.surveyForm = survey);
        this.surveyForm = this.fb.group({
            title: '',
            //location: '',
            pages: this.fb.array([this.initPages()])
        });
    }

    initPages() {
        return this.fb.group({
            questions: this.fb.array([this.initQuestion()])
        });
    }

    initQuestion() {
        return this.fb.group({
            //name: '',
            type: '',
            //answers: this.fb.array([])
        });
    }

    addQuestion(j: any) {
        //const questionArray = <FormArray>this.surveyForm.get['pages'].value[j].get['questions'];
        const questionArray = <FormArray>this.surveyForm.get('pages')['controls'][j]['controls']['questions'];
        console.log(questionArray);
        const newQuestion = this.initQuestion();
            
        questionArray.push(newQuestion);
    }

    removeQuestion(idx: number) {
        const questionsArray = <FormArray>this.surveyForm.controls['questions'];
        questionsArray.removeAt(idx);
    }

    getPages(form: any) {
        //console.log(form.get('sections').controls);
        return form.controls.pages.controls;
    }

    getQuestions(form: any) {
        //console.log(form.get('sections').controls);
        //return form.controls.questions.controls;
        return (<FormArray>form.get('questions')['controls']);
    }

    onSubmit() {
        this.dataStorageService.onChangeSurvey(this.surveyForm);
        this.router.navigate(['test']);

        //const userId = localStorage.getItem('username');
        //const newSurvey = new Survey(userId, "asd", this.surveyForm.value['name'],
        //    this.surveyForm.value['location'], this.surveyForm.value['questions']);

        //this.dataStorageService.addSurvey(newSurvey);
    }

    //initForm() {
    //    this.surveyForm = new FormGroup({
    //        'name': new FormControl(this.name, Validators.required),
    //        'location': new FormControl(this.location, Validators.required)
    //    });
    //}
}