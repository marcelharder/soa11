import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { CandA } from 'src/app/_models/CandA';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-proceduredetails',
  templateUrl: './proceduredetails.component.html',
  styleUrls: ['./proceduredetails.component.css']
})
export class ProceduredetailsComponent implements OnInit {
  currentProcedureId = 0;
  destinationUrl = 'detailsmain';
  procedureDescription = '';
  currentHospitalName = '';

  cap: CandA;

  button_1 = 'button 1'; button_2 = 'button 2'; button_3 = 'button 3';
  button_4 = 'button 4'; button_5 = 'button 5'; button_6 = 'button 6';
  button_7 = ''; button_8 = '';

  constructor(
    private router: Router,
    private auth: AccountService,
    private alertify: ToastrService) { }

  ngOnInit(): void {
    this.auth.currentProcedure$.subscribe((next)=>{this.currentProcedureId = next.procedureId})
  }

  goToDestination(d: string) {
    switch (d) {

      case 'avr': {
        // save this information to the BehaviorSubject, so the valve page can re-arrange itself
        this.auth.changeSoortOperatie('avr');
        this.destinationUrl = 'valve';
        break;
      };
      case 'mvr': {
        // save this information to the BehaviorSubject, so the valve page can re-arrange itself
        this.auth.changeSoortOperatie('mvr');
        this.destinationUrl = 'valve';
        break;
      };
      case 'tvr': {
        // save this information to the BehaviorSubject, so the valve page can re-arrange itself
        this.auth.changeSoortOperatie('tvr');
        this.destinationUrl = 'valve';
        break;
      };
      case 'mvp': {
        // save this information to the BehaviorSubject, so the valve page can re-arrange itself
        this.auth.changeSoortOperatie('mvp');
        this.destinationUrl = 'valverepair';
        break;
      };
      case 'tvp': {
        // save this information to the BehaviorSubject, so the valve page can re-arrange itself
        this.auth.changeSoortOperatie('tvp');
        this.destinationUrl = 'valverepair';
        break;
      };
      default: { this.destinationUrl = d; break; }
    }

  }
  goDelete(){
   /* this.alertify.success('Are you sure yoy want to delete this procedure', () => {
      this.procedureService.deleteProcedure(this.currentProcedureId).subscribe(
        (next)=>{
          this.alertify.success('Procedure deleted');
          this.router.navigate(['/procedures']);

        },
        (error)=>{this.alertify.error(error)})
      return true;
    }); */
    this.alertify.success('Hello','You want to continue')
    .onTap
    .pipe(take(1))
    .subscribe((response:any) => this.toasterClickedHandler(response))
  }
  toasterClickedHandler(r: any) {
    console.log('Toastr clicked');
  }
}
