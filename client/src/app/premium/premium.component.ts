import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmailModel } from '../_models/EmailModel';
import { RefPhysService } from '../_services/refPhys.service';

@Component({
  selector: 'app-premium',
  templateUrl: './premium.component.html',
  styleUrls: ['./premium.component.css']
})
export class PremiumComponent implements OnInit {

  check_free_1 = true;
  check_free_2 = false;
  check_free_3 = false;
  check_free_4 = false;
  check_free_5 = false;

  check_premium_1 = true;
  check_premium_2 = true;
  check_premium_3 = true;
  check_premium_4 = true;
  check_premium_5 = true;

  req = 0;

  emodel: EmailModel = {
    id: 0,
    from: '',
    to:  '',
    subject:  '',
    body:  '',
    phone:  '',
    surgeon:  '',
    cardiologist:  '',
    surgeon_image:  '',
    soort:  '',
    hash:  '',
   }

  constructor(
    private alertify: ToastrService, 
    private router: Router, 
    private refService: RefPhysService) { }

  ngOnInit() {
    
  }

  showPRequest(){if(this.req === 1){return true;} else {return false;}}



  btnClick(no: number) {

    switch (no) {
      case 1: this.alertify.show("button 1"); break;
      case 2: this.alertify.show("button 2"); break;
      case 3: this.alertify.show("button 3"); break;
      case 4: this.alertify.show("button 4"); break;
      case 5: this.alertify.show("button 5"); break;
      case 6: this.alertify.show("button 6"); break;
      case 7: this.alertify.show("button 7"); break;
      case 8: this.alertify.show("button 8"); break;
      case 9: this.alertify.show("button 9"); break;
      case 10: this.alertify.show("button 10"); break;
    }

  }


  sendEmail(){
    this.refService.sendEmail(this.emodel).subscribe((next)=>{});
  }



  RequestPremium() {this.req = 1; }
  Cancel() { 
   // go back to the requesting page


  }

}
