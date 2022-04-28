import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tutorials',
  templateUrl: './tutorials.component.html',
  styleUrls: ['./tutorials.component.css']
})
export class TutorialsComponent implements OnInit {
  isFirstOpen = true;
  oneAtATime = true;
  constructor() { }

  ngOnInit() {
  }

  linkToCSD(){ window.location.href = "https://csd-website.azurewebsites.net";}

  linkToFeatures(){}

  linkToConfiguration(){}

  linkToAddingProcedures(){}

  linkToReporting(){}

  linkToStatistics(){}

}
