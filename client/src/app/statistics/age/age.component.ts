import { Component, Input, OnInit } from '@angular/core';
import { GoogleChartComponent } from 'angular-google-charts'
import { GraphModel } from 'src/app/_models/GraphModel';

@Component({
  selector: 'app-age',
  templateUrl: './age.component.html',
  styleUrls: ['./age.component.css']
})
export class AgeComponent implements OnInit  {
  @Input() ageModel: GraphModel;
  title="";
  type="ColumnChart";
  data= [];
  columnNames= ['ageRange','Aantal'];

  width = 800;
  height = 500;
  options = {   
    hAxis: {
       title: 'Age groups'
    },
    vAxis:{
       title: 'Age(years)'
    },
 };

  constructor() { }

  ngOnInit() {

      this.data = [["3-6",10],["8-10",5],["10-12",8],["12-14",14]];
     // this.data = [[10,"6-8"],[3,"8-10"],[8,"10-12"],[14,"12-14"]];
      this.title = this.ageModel.caption;

      //this.barChartData = [{ data: this.ageModel.dataYas, label: this.ageModel.caption, backgroundColor: ['Green'] }];
      // this.barChartData = [{ data: this.ageModel.dataYas, label: this.ageModel.caption }];
      //this.barChartLabels = this.ageModel.dataXas;

  }

}