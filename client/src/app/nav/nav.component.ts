import { Component, OnInit } from '@angular/core';
import { ChildActivationStart, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
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
  currentRole = '';
  currentUserId = 0;
  currentRoles:Array<string> = [];

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

 

  login(){this.accountService.login(this.model).subscribe((next)=>{
    
    this.accountService.currentUser$.pipe(take(1)).subscribe((u) => { 
      this.currentUserId = u.UserId;
      this.model.username = u.Username;
      this.currentRoles = u.roles;
    })
     // push the hospitalname to the behavior subject, if the loggedin person is not admin
     if(!this.currentRoles.includes('Admin')){
      this.userService.getUser(this.currentUserId).subscribe((next) => {
        this.hospitalService.getSpecificHospital(next.hospital_id).subscribe((d) => {
           this.accountService.changeCurrentHospital(d.hospitalName); // save the name of this hospital
        });
      })

     }
      
    



    console.log(next); })}

  logout(){ 
    this.model.username = "";
    this.model.password = "";
    this.accountService.logout();
    this.router.navigate(['/']) }

}
