import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tutorials',
  templateUrl: './tutorials.component.html',
  styleUrls: ['./tutorials.component.css']
})
export class TutorialsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  linkToCSD(){ window.location.href = "https://csd-website.azurewebsites.net";}

}
