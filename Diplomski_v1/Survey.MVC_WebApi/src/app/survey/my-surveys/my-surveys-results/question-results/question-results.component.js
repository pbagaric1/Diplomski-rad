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
var router_1 = require("@angular/router");
var data_storage_service_1 = require("./../../../../shared/data-storage.service");
var core_1 = require("@angular/core");
var QuestionResults = /** @class */ (function () {
    function QuestionResults(dataStorageService, route) {
        this.dataStorageService = dataStorageService;
        this.route = route;
        this.data = [];
        this.view = [700, 400];
        this.showXAxis = true;
        this.showYAxis = true;
        this.gradient = false;
        this.showLegend = true;
        this.showXAxisLabel = false;
        this.xAxisLabel = 'Country';
        this.showYAxisLabel = false;
        this.yAxisLabel = 'Population';
        this.colorScheme = {
            domain: ['#F44336', '#3F51B5', '#8BC34A', '#2196F3', '#009688', '#FF5722', '#CDDC39', '#00BCD4', '#FFC107', '#795548', '#607D8B']
        };
        this.data1 = [
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
        this.asd = [{ "name": "Monthly", "value": 2 }, { "name": "Weekly", "value": 0 }, { "name": "Daily", "value": 1 }, { "name": "Yearly", "value": 0 }];
    }
    QuestionResults.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            var questionid = params['id'];
            console.log(_this.route.snapshot.params);
            _this.dataStorageService.getQuestionResults(questionid)
                .subscribe(function (data) {
                _this.data = data;
                console.log(_this.data);
            });
        });
    };
    QuestionResults = __decorate([
        core_1.Component({
            selector: 'app-question-results',
            templateUrl: './question-results.component.html',
        }),
        __metadata("design:paramtypes", [data_storage_service_1.DataStorageService, router_1.ActivatedRoute])
    ], QuestionResults);
    return QuestionResults;
}());
exports.QuestionResults = QuestionResults;
//# sourceMappingURL=question-results.component.js.map