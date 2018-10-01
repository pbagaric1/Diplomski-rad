import { DataStorageService } from './../../shared/data-storage.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manage-surveys',
  templateUrl: './manage-surveys.component.html',
  styleUrls: ['./manage-surveys.component.css']
})
export class ManageSurveysComponent implements OnInit {

  surveys: any[];
  currentTime: number;
  currentPage: number = 1;
  totalItems: number;
  itemsPerPage: number = 10;

  constructor(private dataStorageService: DataStorageService) { }

  ngOnInit() {
    this.pageChange(1);

    this.currentTime = Date.now();
    this.currentTime = new Date(this.currentTime).getTime();
    // this.dataStorageService.getAllSurveys()
    //   .subscribe((data: any) => {
    //     console.log(data);
    //     this.surveys = data;
    //   }
    //   );
  };

  model: any = {
    onColor: 'primary',
    offColor: 'sample',
    onText: 'Shown',
    offText: 'Hidden',
    disabled: false,
    size: '',
    //value: true
  };

  compareDates(endTime: any) {
    //console.log(endTime)
    if (this.getMillies(endTime) > this.currentTime) {
      //console.log("end: ", this.getMillies(endTime), "current: ", this.currentTime);
      return true;
    }
    else return false;
  }

  getMillies(input: any): number {
    return new Date(input).getTime();
  }

  pageChange(page: any) {
    this.dataStorageService.getAllSurveys()
      .subscribe((data: any) => {
        this.surveys = data;
        this.totalItems = data.length;
        this.currentPage = page;
        // console.log(data);
      }
      )
  };

  onChange(survey) {
    if (survey.visibility == true)
      survey.visibility = false;
    else if (survey.visibility == false)
      survey.visibility = true;

    this.dataStorageService.changeVisibility(survey)
      .subscribe(response => {
        //console.log(response);
      })
  }

}
