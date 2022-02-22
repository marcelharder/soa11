import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  contact = 0;
  version = 1;

  constructor() { }

  ngOnInit(): void {
    
  }
  switchPanel(t: number){
    switch (t) {
      case 1: this.contact = 1; this.version = 0;break;
      case 2: this.contact = 0; this.version = 1;break;
    }
  }


  showContact(){if(this.contact === 1){return true;}}
  showVersion(){if(this.version === 1){return true;}}

  linkToCSD(){ window.location.href = "https://csd-website.azurewebsites.net";}

}
