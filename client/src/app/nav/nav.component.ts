import { Component, OnInit } from '@angular/core';
import { ChildActivationStart, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { User } from '../_models/User';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  UserName: string = '';

  constructor(
    public accountService: AccountService, 
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
   if(this.UserName == ''){

    this.accountService.currentUser$.pipe(take(1)).subscribe((u) => {this.UserName = u.Username;})

   }
  }

  adminLoggedIn(){if(this.UserName === 'Admin'){return true;}}

  login(){this.accountService.login(this.model).subscribe((next)=>{
    
    this.accountService.currentUser$.pipe(take(1)).subscribe((u) => {this.UserName = u.Username;})
    console.log(next); })}

  logout(){ 
    this.model.UserName = "";
    this.model.password = "";
    this.accountService.logout();
    this.router.navigate(['/']) }

}
