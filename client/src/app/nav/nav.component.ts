import { Component, OnInit } from '@angular/core';
import { ChildActivationStart, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { loginModel } from '../_models/loginModel';
import { User } from '../_models/User';
import { AccountService } from '../_services/account.service';
import { HospitalService } from '../_services/hospital.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: loginModel = {username:'',password:''};
  currentUserId = 0;

  constructor(
    public accountService: AccountService, 
    private router: Router,
    private hospitalService: HospitalService,
    private userService: UserService) { }

  ngOnInit(): void {
   if(this.model.username == ''){
    this.accountService.currentUser$.pipe(take(1)).subscribe((u) => { this.model.username = u.Username;})
   }
  }

  adminLoggedIn(){if(this.model.username === 'Admin'){return true;}}

  login(){this.accountService.login(this.model).subscribe((next)=>{
    
    this.accountService.currentUser$.pipe(take(1)).subscribe((u) => { 
      this.currentUserId = u.UserId;
      this.model.username = u.Username;})
     // push the hospitalname to the behavior subject
     this.userService.getUser(this.currentUserId).subscribe((next) => {
      this.hospitalService.getSpecificHospital(next.hospital_id).subscribe((d) => {
         this.accountService.changeCurrentHospital(d.hospitalName); // save the name of this hospital
      });
    })



    console.log(next); })}

  logout(){ 
    this.model.username = "";
    this.model.password = "";
    this.accountService.logout();
    this.router.navigate(['/']) }

}
