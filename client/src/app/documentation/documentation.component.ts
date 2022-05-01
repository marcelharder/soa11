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

  linkToIntroduction(){window.location.href = "https://docs.google.com/document/d/15xb1ceMfCEqKYpYXL-0vomYm_gAtWhiy3bY-MWzB-0U/edit?usp=sharing"}

  linkToFeatures(){window.location.href = "https://docs.google.com/document/d/128XynzpsdFw5UU6CMi5NQCM_StVvHxrq1FWuFqZeoUM/edit?usp=sharing"}

  linkToHistory(){window.location.href = "https://docs.google.com/document/d/1_R0pHK49oQ1t-F2Rf5uQmbgvDt2WnLSsK_IA69k2j6Y/edit?usp=sharing"}

  linkToDeployment(){window.location.href = "https://docs.google.com/document/d/16SP_tfH3onP3PKxXHrV7Z-9yQ9emN1FWExO5RmiTjaY/edit?usp=sharing"}


}



