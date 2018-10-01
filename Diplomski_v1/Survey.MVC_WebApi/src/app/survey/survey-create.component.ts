import { fadeInAnimation } from './../animations/fade-in.animation';
import { Component, OnInit, TemplateRef, ViewChild, ElementRef, ChangeDetectorRef } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { SurveyModel } from "./models/survey.model";
import { DataStorageService } from '../shared/data-storage.service';
import { Router } from '@angular/router';
import { DatePipe, PathLocationStrategy } from '@angular/common';
import * as Survey from 'survey-angular';
import { query, trigger, style, stagger, animate, transition, keyframes, state } from '@angular/animations';
import { slideInOutAnimation } from '../animations/slide-in-out.animation';
import { slideAnimation } from '../animations/slideAnimation';
import { SavedSurvey } from './models/saved-survey.model';
import { NgbModal, NgbActiveModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

type Orientation = ("prev" | "next" | "none");

@Component({
    selector: 'app-survey-create',
    templateUrl: './survey-create.component.html',
    styleUrls: ['./survey-create.component.css'],
    animations: [slideInOutAnimation, fadeInAnimation]
})

export class SurveyCreateComponent implements OnInit {

    @ViewChild('closeBtn') closeBtn: ElementRef;
    @ViewChild('closeBtn1') closeBtn1: ElementRef;
    @ViewChild('openModal') openModal: ElementRef;
    surveyForm: any;
    surveyId: string = '';
    pollTypeId: string = '';
    selectedQuestion: any;
    questionsArray: FormArray;
    lastIndex: number;
    currentIndex: number;
    state: string;
    activityRange: string[] = [];
    elements: any = [];
    surveyJson: string = '';
    randomString: string = '';
    userId: string = localStorage.getItem('userId');
    continuedSurvey: any;
    showContinuedModal: boolean;
    bsRangeValue: Date[];
    minDate: Date;

    constructor(private fb: FormBuilder, private dataStorageService: DataStorageService,
        private router: Router, private datePipe: DatePipe, private modalService: NgbModal) {
    }

    ngOnInit() {
        this.minDate = new Date();
        this.minDate.setDate(this.minDate.getDate());

        this.dataStorageService.getSurveyJson(this.userId).subscribe(
            (survey: SurveyModel) => {
                if (survey != null) {
                    console.log(survey);
                    this.showContinuedModal = true;
                    this.continuedSurvey = survey;
                    this.openModal.nativeElement.click();
                }

            }
        );
        this.dataStorageService.currentSurvey.subscribe(survey => this.surveyForm = survey);
        this.surveyForm = this.fb.group({
            title: ['', Validators.required],
            organization: ['', Validators.required],
            description: ['', Validators.required],
            activityDateRange: '',
            pages: this.fb.array([this.initPages()])
        });
        this.currentIndex = 0;
        this.lastIndex = 0;
        this.questionsArray = <FormArray>this.surveyForm.get('pages')['controls'][0]['controls']['questions']['controls'];
        console.log(this.questionsArray.length)

    };

    loadItems() {
        this.closeBtn1.nativeElement.click();
        let startDate = new Date(this.continuedSurvey.activityStartTime);
        let endDate = new Date(this.continuedSurvey.activityEndTime);
        this.bsRangeValue = [startDate, endDate];



        this.surveyForm.patchValue({
            title: this.continuedSurvey.title,
            organization: this.continuedSurvey.organization,
            description: this.continuedSurvey.description
        });
        <FormArray>this.surveyForm.get('pages')['controls'][0]['controls']['questions'].removeAt(0);
        this.continuedSurvey.pages[0].questions.forEach((element, index) => {
            <FormArray>this.surveyForm.get('pages')['controls'][0]['controls']['questions'].push(this.initQuestion(element));
            this.elements.push(element);
            //this.patch(index, element);
        });
        console.log(this.surveyForm.get('pages')['controls'][0]['controls']['questions']['controls'])
    }

    saveForm() {
        let createdOn = this.datePipe.transform(Date.now(), 'MM-dd-yyyy HH:mm:ss a');

        let activityStartTime = this.datePipe.transform(this.activityRange[0], 'MM-dd-yyyy');
        let activityEndTime = this.datePipe.transform(this.activityRange[1], 'MM-dd-yyyy');

        const newSurvey = new SurveyModel("", this.userId, this.surveyForm.value['title'],
            this.surveyForm.value['organization'], createdOn, this.surveyForm.value['pages'][0]['questions'], true,
            activityStartTime, activityEndTime, this.surveyForm.value['description']);

        this.dataStorageService.addSurveyJson(newSurvey);
    }

    onModalClick() {
        let surveyModel = new Survey.Model(this.surveyForm.value);
        surveyModel.mode = 'display';
        Survey.SurveyNG.render('surveyElement', { model: surveyModel });
        console.log(this.surveyForm.value);


        let activityStartTime = this.datePipe.transform(this.activityRange[0], 'MM-dd-yyyy');
        let activityEndTime = this.datePipe.transform(this.activityRange[1], 'MM-dd-yyyy');

        console.log(activityStartTime);
        console.log(activityEndTime);
    }

    removeSavedSurvey() {
        this.closeBtn1.nativeElement.click();
        this.dataStorageService.removeSavedSurvey(this.userId).subscribe(response => console.log(response));
    }

    initPages() {
        return this.fb.group({
            questions: this.fb.array([this.initQuestion()])
        });
    }

    initQuestion(item?: any): FormGroup {
        if (!item) {
            return this.fb.group({
                title: ['', Validators.required],
                type: ['', Validators.required],
                isRequired: false,
                hidden: false
                //answers: this.fb.array([])
            });
        }
        else if (item) {
            if (item.type == 'text') {
                console.log("item", item.type);
                return this.fb.group({
                    title: [item.title, Validators.required],
                    isRequired: item.isRequired,
                    hidden: item.hidden,
                    type: item.type
                });
            }

            else if (item.type == 'checkbox' || item.type == 'radiogroup') {
                console.log("item", item.type);
                return this.fb.group({
                    title: [item.title, Validators.required],
                    isRequired: item.isRequired,
                    hidden: item.hidden,
                    type: item.type,
                    choices: this.fb.array([]),
                });
            }


            else if (item.type == 'rating') {
                return this.fb.group({
                    title: [item.title, Validators.required],
                    isRequired: item.isRequired,
                    hidden: item.hidden,
                    type: item.type,
                    mininumRateDescription: item.mininumRateDescription,
                    maximumRateDescription: item.maximumRateDescription
                });
            }
        }
        // else if (item.type == "rating")
        // {
        //     console.log("item", item.type);
        //     return this.fb.group({

        //         name: [item.name, Validators.required],
        //         isRequired: item.isRequired,
        //         hidden: item.hidden,
        //         type: item.type,
        //         minimumRateDescription: item.minimumRateDescription,
        //         maximumRateDescription: item.maximumRateDescription
        //     });
        // }
    }

    addQuestion(j: any) {
        //const questionArray = <FormArray>this.surveyForm.get['pages'].value[j].get['questions'];
        this.selectedQuestion = this.surveyForm.get('pages')['controls'][0]['controls']['questions']['controls'][this.currentIndex] as FormArray;
        const questionArray = <FormArray>this.surveyForm.get('pages')['controls'][j]['controls']['questions'];
        const newQuestion = this.initQuestion();

        questionArray.push(newQuestion);

    }

    removeQuestion(idArray: number, idQuestion: number) {
        const questionsArray = <FormArray>this.surveyForm.get('pages')['controls'][idArray]['controls']['questions'];
        questionsArray.removeAt(idQuestion);
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
        let createdOn = this.datePipe.transform(Date.now(), 'MM-dd-yyyy HH:mm:ss a');

        let activityStartTime = this.datePipe.transform(this.activityRange[0], 'MM-dd-yyyy');
        let activityEndTime = this.datePipe.transform(this.activityRange[1], 'MM-dd-yyyy');

        console.log(activityStartTime, activityEndTime);


        const newSurvey = new SurveyModel("", this.userId, this.surveyForm.value['title'],
            this.surveyForm.value['organization'], createdOn, this.surveyForm.value['pages'][0]['questions'], true,
            activityStartTime, activityEndTime, this.surveyForm.value['description']);


        console.log(this.surveyForm);

        this.dataStorageService.addSurvey(newSurvey);
        console.log(newSurvey);
        this.closeModal();
        
    }
}