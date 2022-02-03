import { Component, Input, OnInit } from '@angular/core';
import { Valve } from 'src/app/_models/Valve';
import { ValveService } from 'src/app/_services/valve.service';

@Component({
  selector: 'app-valvesinovi',
  templateUrl: './valvesinovi.component.html',
  styleUrls: ['./valvesinovi.component.css']
})
export class ValvesinoviComponent implements OnInit  {
  @Input() hospitalId: string;
  optionsAvailableValves:Array<Valve> = [];

 

  constructor(private vs:ValveService) { }

  ngOnInit() {
 
  


  }

  

}