import { Component, Input, OnInit } from '@angular/core';
import { GraphModel } from 'src/app/_models/GraphModel';

@Component({
  selector: 'app-casemix',
  templateUrl: './casemix.component.html',
  styleUrls: ['./casemix.component.css']
})
export class CasemixComponent implements OnInit {
  @Input() cmModel: GraphModel;
  title = "";
  type = "ColumnChart";
  data = [];
  columnNames = ['ageRange', 'Aantal'];
  width = 800;
  height = 500;
  options = {
    hAxis: {
      title: 'Procedures'
    },
    vAxis: {
      title: '# cases'
    },
  };

  constructor() { }

  ngOnInit(): void {
     // combine the two datastreams in one for consumption by the graph
     var num: number = 0;
     var i: number;
     var help: Array<any> = [];
     for (i = num; i < this.cmModel.dataXas.length; i++) { help.push([this.cmModel.dataXas[i], this.cmModel.dataYas[i]]); }
     this.data = help;
     // this.data = [["3-6", 0], ["8-10", 0], ["10-12", 1], ["12-14", 0],["3-6", 0], ["8-10", 0], ["10-12", 1], ["12-14", 0]];
     this.title = this.cmModel.caption;
  }

}
