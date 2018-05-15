import { fadeInAnimation } from './../animations/fade-in.animation';
import { Component, OnInit, TemplateRef, ViewChild, ElementRef, ChangeDetectorRef } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { SurveyModel } from "./models/survey.model";
import { DataStorageService } from '../shared/data-storage.service';
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import * as Survey from 'survey-angular';
import { query, trigger, style, stagger, animate, transition, keyframes, state } from '@angular/animations';
import { slideInOutAnimation } from '../animations/slide-in-out.animation';
import { slideAnimation } from '../animations/slideAnimation';

type Orientation = ( "prev" | "next" | "none");

@Component({
    selector: 'app-survey-create',
    templateUrl: './survey-create.component.html',
    styleUrls: ['./survey-create.component.css'],
    animations: [slideInOutAnimation, fadeInAnimation]
})

export class SurveyCreateComponent implements OnInit{

    @ViewChild('closeBtn') closeBtn: ElementRef;
    surveyForm: any;
    surveyId: string = '';
    pollTypeId: string = '';
    selectedQuestion: any;
    questionsArray: FormArray;
    lastIndex : number;
    currentIndex: number;
    state: string;

    private changeDetectorRef: ChangeDetectorRef;
    
    hideme: any = {};

    constructor(private fb: FormBuilder, private dataStorageService: DataStorageService,
        private router: Router, private datePipe: DatePipe, changeDetectorRef: ChangeDetectorRef) {
            this.changeDetectorRef = changeDetectorRef;
            this.state = "none";
         }

    ngOnInit() {
        this.dataStorageService.currentSurvey.subscribe(survey => this.surveyForm = survey);
        this.surveyForm = this.fb.group({
            title: ['', Validators.required],
            organization: ['', Validators.required],
            pages: this.fb.array([this.initPages()])
        });
        this.currentIndex = 0;
        this.lastIndex = 0;
        this.questionsArray =  <FormArray>this.surveyForm.get('pages')['controls'][0]['controls']['questions']['controls'];
        //this.selectedQuestion = <FormArray>this.surveyForm.get('pages')['controls'][0]['controls']['questions']['controls'][this.currentIndex]['controls'];
        
    };

    onModalClick() {
        let surveyModel = new Survey.Model(this.surveyForm.value);
        surveyModel.mode = 'display';
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        //console.log(surveyModel);
        console.log(this.surveyForm.value);
        //console.log(this.json1);
    }
    initPages() {
        return this.fb.group({
            questions: this.fb.array([this.initQuestion()])
        });
    }

    initQuestion() {
        return this.fb.group({
            type: ['', Validators.required],
            name: ['', Validators.required],
            isRequired: false,
            hidden: false
            //answers: this.fb.array([])
        });
    }

    addQuestion(j: any) {
        //const questionArray = <FormArray>this.surveyForm.get['pages'].value[j].get['questions'];
        this.selectedQuestion = this.surveyForm.get('pages')['controls'][0]['controls']['questions']['controls'][this.currentIndex] as FormArray;
        const questionArray = <FormArray>this.surveyForm.get('pages')['controls'][j]['controls']['questions'];
        const newQuestion = this.initQuestion();

        questionArray.push(newQuestion);
      
        this.currentIndex = this.lastIndex;
        this.currentIndex++;
        this.lastIndex++;

        this.state = "slideRight";
        this.changeDetectorRef.detectChanges();
        console.log(this.currentIndex);
       
    }

    removeQuestion(idArray: number, idQuestion: number) {
        const questionsArray = <FormArray>this.surveyForm.get('pages')['controls'][idArray]['controls']['questions'];
        questionsArray.removeAt(idQuestion);
        this.lastIndex--;
        this.currentIndex--;

        if(this.state != "slideLeft")
        this.state = "slideLeft";
        else if (this.state === "slideLeft")
        this.state = "slideLeftLeft"
        this.changeDetectorRef.detectChanges();
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

    private closeModal() {
        this.closeBtn.nativeElement.click();
    }

    onSubmit() {
        this.dataStorageService.onChangeSurvey(this.surveyForm);
        //this.router.navigate(['test']);

        const userId = localStorage.getItem('userId');
        let createdOn = this.datePipe.transform(Date.now(), 'MM-dd-yyyy HH:mm:ss a');

        const asd = this.surveyForm.controls;

        const newSurvey = new SurveyModel("", userId, this.surveyForm.value['title'],
            this.surveyForm.value['organization'], createdOn, this.surveyForm.value['pages'][0]['questions'], true);


        console.log(this.surveyForm);

        this.dataStorageService.addSurvey(newSurvey);
        console.log(newSurvey);
        this.closeModal();
    }

    previousQuestion() {
        this.currentIndex--;
        if(this.state != "slideLeft")
        this.state = "slideLeft";
        else if (this.state === "slideLeft")
        this.state = "slideLeftLeft"
        this.changeDetectorRef.detectChanges();
        console.log(this.state);
    }

    nextQuestion() {
        this.currentIndex++;
        if(this.state != "slideRight")
        this.state = "slideRight";
        else if (this.state === "slideRight")
        this.state = "slideRightRight"
        this.changeDetectorRef.detectChanges();
        console.log(this.state);
    }
}