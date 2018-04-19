import { ActivatedRoute, Params, ParamMap } from '@angular/router';
import { DataStorageService } from './../../../../shared/data-storage.service';
import { BaseChartComponent } from '@swimlane/ngx-charts';
import { Component, Input, OnInit, OnChanges } from '@angular/core';

@Component({
  selector: 'app-question-results',
  templateUrl: './question-results.component.html',
})
export class QuestionResults implements OnInit {

  constructor(private dataStorageService: DataStorageService, private route: ActivatedRoute) { }

  data: any[] = [];
  question : any;
  questionType: string;

  ngOnInit() {

    this.dataStorageService.currentQuestion.subscribe(question => this.question = question);

    console.log(this.question.type);
    this.questionType = this.question.type;

          this.dataStorageService.getQuestionResults(this.question.id)
              .subscribe(
                  (data : any[]) => {
                      this.data = data;

                      console.log(this.data);
                  });
  }

  single: any[];
  multi: any[];

  view: any[] = [700, 400];

  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = false;
  xAxisLabel = 'Country';
  showYAxisLabel = false;
  yAxisLabel = 'Population';

  colorScheme = {
    domain: ['#F44336', '#3F51B5', '#8BC34A', '#2196F3', '#009688', '#FF5722', '#CDDC39', '#00BCD4', '#FFC107', '#795548', '#607D8B']
  };

  data2 = [ {
    "name": "Rating",
    "value": 3.4
  }]

  data1 = [
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


  asd = [{"name":"Monthly","value":2},{"name":"Weekly","value":0},{"name":"Daily","value":1},{"name":"Yearly","value":0}]
}