import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-documentation',
  templateUrl: './documentation.component.html',
  styleUrls: ['./documentation.component.css']
})
export class DocumentationComponent implements OnInit {
 
  constructor() { }
 

  ngOnInit() {
  }

  linkToCSD(){ window.location.href = "https://csd-website.azurewebsites.net";}


}



