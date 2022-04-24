import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

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

  constructor(private alertify: ToastrService) { }

  ngOnInit() {
  }

  btnClick(no: number){

    switch(no){
      case 1: this.alertify.show("button 1");break;

    }

  }

  RequestPremium(){}
  Cancel(){}

}
