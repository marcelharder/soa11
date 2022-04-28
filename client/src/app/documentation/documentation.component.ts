import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-documentation',
  templateUrl: './documentation.component.html',
  styleUrls: ['./documentation.component.css']
})
export class DocumentationComponent implements OnInit {
  isFirstOpen = true;
  oneAtATime = true;
  constructor() { }
 

  ngOnInit() {
   
  }

  linkToCSD(){ window.location.href = "https://csd-website.azurewebsites.net";}

  linkToIntroduction(){}

  linkToFeatures(){}

  linkToHistory(){}

  linkToDeployment(){}


}



