"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var QuestionComponent = (function () {
    function QuestionComponent(fb) {
        this.fb = fb;
        this.questionTypes = ['text', 'radiogroup', 'checkbox', 'matrix', 'rating', 'comment'];
    }
    QuestionComponent.prototype.ngOnInit = function () {
        this.questionGroup.addControl("title", new forms_1.FormControl(""));
        //console.log(this.questionGroup)
    };
    QuestionComponent.prototype.addAnswer = function () {
        var answerArray = this.questionGroup.controls['answers'];
        var newAnswer = this.initAnswer();
        answerArray.push(newAnswer);
        console.log(this.selectedType);
    };
    QuestionComponent.prototype.removeAnswer = function (idx) {
        var answerArray = this.questionGroup.controls['answers'];
        answerArray.removeAt(idx);
    };
    //CHOICES
    QuestionComponent.prototype.initChoices = function () {
        return this.fb.group({
            formArray: this.fb.array([
                this.fb.control('')
            ])
        });
    };
    QuestionComponent.prototype.initAnswer = function () {
        return this.fb.group({
            text: ''
        });
    };
    QuestionComponent.prototype.addChoice = function () {
        var choiceArray = this.questionGroup.controls['choices'];
        var newChoice = this.initChoices();
        choiceArray.push(this.fb.control(''));
    };
    QuestionComponent.prototype.removeChoice = function (idx) {
        var choiceArray = this.questionGroup.controls['choices'];
        choiceArray.removeAt(idx);
    };
    //COLUMNS
    QuestionComponent.prototype.addColumn = function () {
        //const columnArray = <FormArray>this.questionGroup.controls['columns'];
        var columnArray = this.questionGroup.get('columns')['controls'];
        var newColumn = this.initColumns();
        columnArray.push(newColumn);
    };
    QuestionComponent.prototype.removeColumn = function (idx) {
        var columnArray = this.questionGroup.controls['columns'];
        columnArray.removeAt(idx);
    };
    QuestionComponent.prototype.initColumns = function () {
        return this.fb.group({
            text: '',
            value: ''
        });
    };
    //ROWS
    QuestionComponent.prototype.addRow = function () {
        var rowArray = this.questionGroup.controls['rows'];
        var newRow = this.initRows();
        rowArray.push(newRow);
    };
    QuestionComponent.prototype.removeRow = function (idx) {
        var rowArray = this.questionGroup.controls['rows'];
        rowArray.removeAt(idx);
    };
    QuestionComponent.prototype.initRows = function () {
        return this.fb.group({
            text: '',
            value: ''
        });
    };
    QuestionComponent.prototype.onChange = function (selectedType) {
        this.questionGroup.controls['title'].reset();
        switch (selectedType) {
            case 'radiogroup':
                {
                    this.questionGroup.removeControl("mininumRateDescription");
                    this.questionGroup.removeControl("maximumRateDescription");
                    this.questionGroup.removeControl("columns");
                    this.questionGroup.removeControl("rows");
                    this.questionGroup.removeControl("choices");
                    this.questionGroup.addControl("choices", new forms_1.FormArray([]));
                    break;
                }
            case 'rating':
                {
                    this.questionGroup.removeControl("mininumRateDescription");
                    this.questionGroup.removeControl("maximumRateDescription");
                    this.questionGroup.removeControl("columns");
                    this.questionGroup.removeControl("rows");
                    this.questionGroup.removeControl("choices");
                    this.questionGroup.addControl("mininumRateDescription", new forms_1.FormControl(""));
                    this.questionGroup.addControl("maximumRateDescription", new forms_1.FormControl(""));
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
                    this.questionGroup.addControl("choices", new forms_1.FormArray([]));
                    break;
                }
            case 'matrix':
                {
                    this.questionGroup.removeControl("mininumRateDescription");
                    this.questionGroup.removeControl("maximumRateDescription");
                    this.questionGroup.removeControl("columns");
                    this.questionGroup.removeControl("rows");
                    this.questionGroup.removeControl("choices");
                    this.questionGroup.addControl("columns", new forms_1.FormArray([]));
                    this.questionGroup.addControl("rows", new forms_1.FormArray([]));
                    break;
                }
        }
    };
    return QuestionComponent;
}());
__decorate([
    core_1.Input('group'),
    __metadata("design:type", forms_1.FormGroup)
], QuestionComponent.prototype, "questionGroup", void 0);
QuestionComponent = __decorate([
    core_1.Component({
        selector: 'app-question',
        templateUrl: './question.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder])
], QuestionComponent);
exports.QuestionComponent = QuestionComponent;
//# sourceMappingURL=question.component.js.map