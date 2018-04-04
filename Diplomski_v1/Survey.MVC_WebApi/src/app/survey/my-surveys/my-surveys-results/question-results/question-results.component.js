"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
//import { BaseChartComponent } from '@swimlane/ngx-charts';
var core_1 = require("@angular/core");
var QuestionResults = /** @class */ (function () {
    function QuestionResults() {
        this.colorScheme = {
            domain: ['#F44336', '#3F51B5', '#8BC34A', '#2196F3', '#009688', '#FF5722', '#CDDC39', '#00BCD4', '#FFC107', '#795548', '#607D8B']
        };
        this.data = [
            {
                "name": "Germany",
                "value": 46268
            },
            {
                "name": "USA",
                "value": 53041
            },
            {
                "name": "France",
                "value": 42503
            },
            {
                "name": "United Kingdom",
                "value": 41787
            },
            {
                "name": "Spain",
                "value": 29863
            },
            {
                "name": "Italy",
                "value": 35925
            }
        ];
    }
    QuestionResults.prototype.ngOnInit = function () {
    };
    QuestionResults = __decorate([
        core_1.Component({
            selector: 'app-question-results',
            templateUrl: './question-results.component.html',
        })
    ], QuestionResults);
    return QuestionResults;
}());
exports.QuestionResults = QuestionResults;
//# sourceMappingURL=question-results.component.js.map