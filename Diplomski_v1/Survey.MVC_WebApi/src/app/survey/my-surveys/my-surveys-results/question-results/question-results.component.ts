import { ActivatedRoute, Params, ParamMap } from '@angular/router';
import { DataStorageService } from './../../../../shared/data-storage.service';
import { BaseChartComponent } from '@swimlane/ngx-charts';
import { Component, Input, OnInit, OnChanges } from '@angular/core';

@Component({
  selector: 'app-question-results',
  templateUrl: './question-results.component.html',
  styleUrls: ['./question-results.component.css']
})
export class QuestionResults implements OnInit {

  constructor(private dataStorageService: DataStorageService, private route: ActivatedRoute) { }

  data: any[] = [];
  question: any;
  questionType: string;
  textAnswers: any[] = [];
  noResults: boolean;

  ngOnInit() {

    this.dataStorageService.currentQuestion.subscribe(question => this.question = question);

    console.log(this.question);
    this.questionType = this.question.type;

    this.dataStorageService.getQuestionResults(this.question.id)
      .subscribe(
        (data: any[]) => {
          this.data = data;
          if(this.questionType == 'rating')
          {
            if(this.data[0].value %1 == 0)
            {
              console.log("dobar")
              this.data[0].value = this.data[0].value.toFixed(2);
            }
            console.log(this.data[0].value)
          }
          console.log(this.data);
          if (this.data == null)
            this.noResults = true;
          else
            this.textAnswers = data[0].TextAnswers;

        });
  }

  someValueFormat(val: any): string {
    if (val instanceof Array) {
        return val[0]['name'] + ' ' + val[0]['value'].toLocaleString();
    } else {
        return val.toLocaleString();
    }
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
}