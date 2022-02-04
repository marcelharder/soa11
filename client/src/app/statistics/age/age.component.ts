import { Component, Input, OnInit } from '@angular/core';
import { GraphModel } from 'src/app/_models/GraphModel';



@Component({
  selector: 'app-age',
  templateUrl: './age.component.html',
  styleUrls: ['./age.component.css']
})
export class AgeComponent implements OnInit {
  @Input() ageModel: GraphModel;
  title = "";
  type = "ColumnChart";
  data = [];
  columnNames = ['ageRange', 'Aantal'];
  width = 800;
  height = 500;
  options = {
    hAxis: {
      title: 'Age groups'
    },
    vAxis: {
      title: 'Age(years)'
    },
  };

  constructor() { }

  ngOnInit(): void {
    // combine the two datastreams in one for consumption by the graph
    var num: number = 0;
    var i: number;
    var help: Array<any> = [];
    for (i = num; i < this.ageModel.dataXas.length; i++) { help.push([this.ageModel.dataXas[i], this.ageModel.dataYas[i]]); }
    this.data = help;
    // this.data = [["3-6", 0], ["8-10", 0], ["10-12", 1], ["12-14", 0],["3-6", 0], ["8-10", 0], ["10-12", 1], ["12-14", 0]];
    this.title = this.ageModel.caption;
  }




}