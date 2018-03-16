import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { Survey } from "./models/survey.model";
import { DataStorageService } from '../shared/data-storage.service';
import { Question } from "./question/question.model";
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'app-survey',
    templateUrl: './survey.component.html'
})
export class SurveyComponent implements OnInit{

    surveyForm: FormGroup;
    surveyId: string = '';
    pollTypeId: string = '';
    selectedQuestion: string;

    constructor(private fb: FormBuilder, private dataStorageService: DataStorageService,
        private router: Router, private datePipe: DatePipe) { }

    ngOnInit() {
        this.dataStorageService.currentSurvey.subscribe(survey => this.surveyForm = survey);
        this.surveyForm = this.fb.group({
            title: '',
            organization: '',
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
            type: '',
            isRequired: false
            //answers: this.fb.array([])
        });
    }

    addQuestion(j: any) {
        //const questionArray = <FormArray>this.surveyForm.get['pages'].value[j].get['questions'];
        const questionArray = <FormArray>this.surveyForm.get('pages')['controls'][j]['controls']['questions'];
        //console.log(questionArray);
        const newQuestion = this.initQuestion();
            
        questionArray.push(newQuestion);
    }

    removeQuestion(idx: number) {
        const questionsArray = <FormArray>this.surveyForm.get('pages')['controls'][idx]['controls']['questions'];
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
        //this.router.navigate(['test']);

        const userId = localStorage.getItem('userId');
        let createdOn = this.datePipe.transform(Date.now(), 'yyyy-MM-dd hh:mm:ss');

        const newSurvey = new Survey(userId, this.surveyForm.value['title'],
            this.surveyForm.value['organization'], createdOn, this.surveyForm.value['pages'][0]['questions']);

        console.log(this.surveyForm);

        const json = {
            "title": "Anketa",
            "organization": "Konzum",
                    "questions": [
                        {
                            "type": "Text",
                            "isRequired": true,
                            "title": "Prvo"
                        },
                        {
                            "type": "Radiogroup",
                            "isRequired": false,
                            "title": "Drugo",
                            "choices": [
                                "1",
                                "2"
                            ]
                        }
                    ]
        };

        this.dataStorageService.addSurvey(newSurvey);
        console.log(newSurvey);
        //this.dataStorageService.addSurveyJson(json);
    }
}