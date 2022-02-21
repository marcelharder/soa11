import { Component, OnInit } from '@angular/core';
import { ChildActivationStart, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { loginModel } from '../_models/loginModel';
import { User } from '../_models/User';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: loginModel = {username:'',password:''};

  constructor(
    public accountService: AccountService, 
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
   if(this.model.username == ''){

    this.accountService.currentUser$.pipe(take(1)).subscribe((u) => {this.model.username = u.Username;})

   }
  }

  adminLoggedIn(){if(this.model.username === 'Admin'){return true;}}

  login(){this.accountService.login(this.model).subscribe((next)=>{
    
    this.accountService.currentUser$.pipe(take(1)).subscribe((u) => {this.model.username = u.Username;})
    console.log(next); })}

  logout(){ 
    this.model.username = "";
    this.model.password = "";
    this.accountService.logout();
    this.router.navigate(['/']) }

}
