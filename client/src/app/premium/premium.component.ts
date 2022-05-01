import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { dropItem } from '../_models/dropItem';
import { EmailModel } from '../_models/EmailModel';
import { AccountService } from '../_services/account.service';
import { RefPhysService } from '../_services/refPhys.service';

@Component({
  selector: 'app-premium',
  templateUrl: './premium.component.html',
  styleUrls: ['./premium.component.css']
})
export class PremiumComponent implements OnInit {
  additionalComments = "";
  modalRef: BsModalRef;
  commitTime: any = {};

  vrijeText = "";
  money = 0.00;
  optionTimePeriod: Array<dropItem> = [];

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
  currentUserName = '';

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
    private modalService: BsModalService,
    private auth: AccountService,
    private alertify: ToastrService, 
    private router: Router, 
    private refService: RefPhysService) { }

  ngOnInit() {

    this.loadDrops();
     this.commitTime = 0;
     this.auth.currentUser$.pipe(take(1)).subscribe((u) => {
      this.currentUserName = u.Username;
  });
    
  }

  calculateFee(id: number){
    this.money = id;
    this.emodel.subject = "requested tier " + this.money;
  }

  loadDrops(){
    this.optionTimePeriod.push(
      {value:0, description: 'Choose'},
      {value:50, description: '3 months'},
      {value:99, description: '6 months'},
      {value:190, description: '1 year'})
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

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
  

  confirm(): void {
    // fill in all the details we need for the email
    this.emodel.to = "marcelharder@protonmail.com";
    this.emodel.body = "Requested by: " + this.currentUserName + " comments: " + this.additionalComments;


    this.refService.sendEmail(this.emodel).subscribe((next)=>{});
    this.router.navigate(['/']);
    this.modalRef?.hide();
  }
  
  decline(): void {
    this.modalRef?.hide();
  }


  



  RequestPremium() {this.req = 1; }
  Cancel() { 
   // go back to the requesting page
   this.router.navigate(['/profile'])

  }

}
