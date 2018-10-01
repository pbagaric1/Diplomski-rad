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
    @Input('element') someData: any;
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
        //this.questionGroup.addControl("title", new FormControl(""));
        console.log(this.questionGroup);

        //this.questionGroup.get('type');
        this.selectedType = this.questionGroup.get('type').value;
        this.questionGroup.valueChanges.subscribe(value => {
            this.selectedType = this.questionGroup.get('type').value;
        });
        if (this.someData) {
            this.questionGroup.patchValue({ title: this.someData.title })

            // if(this.someData.choices == null)
            // {
            //     this.questionGroup.removeControl("choices");
            // }

            if (this.someData.choices != null) {
                const choiceArray = <FormArray>this.questionGroup.controls['choices'];
                this.someData.choices.forEach(element => {
                    choiceArray.push(this.fb.control(element));
                });

            }

            // if(this.someData.mininumRateDescription == null)
            //     {
            //         this.questionGroup.removeControl("mininumRateDescription");
            //     }

            //     if(this.someData.maximumRateDescription == null)
            //     {
            //         this.questionGroup.removeControl("maximumRateDescription");
            //     }
            // }
            console.log(this.someData);
        }
    }



        // //CHOICES
        // initChoices() {
        //     return this.fb.group({
        //         formArray: this.fb.array([
        //             this.fb.control('')
        //         ])
        //     });
        // }

        addChoice() {
            const choiceArray = <FormArray>this.questionGroup.controls['choices'];
            choiceArray.push(this.fb.control(''));

        }

        removeChoice(idx: number) {
            const choiceArray = <FormArray>this.questionGroup.controls['choices'];
            choiceArray.removeAt(idx);
        }

        onChange() {
            //onsole.log(selectedType);
            this.questionGroup.controls['title'].reset();
            switch (this.selectedType) {
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