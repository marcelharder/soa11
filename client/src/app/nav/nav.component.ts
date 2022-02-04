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
  username: string = '';

  constructor(
    public accountService: AccountService, 
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
   if(this.username == ''){
    this.accountService.currentUser$.pipe(take(1)).subscribe((u) => {this.username = u.username;})
   }
  }

  login(){this.accountService.login(this.model).subscribe((next)=>{
    
    this.accountService.currentUser$.pipe(take(1)).subscribe((u) => {this.username = u.username;})
    console.log(next); })}

  logout(){ 
    this.model.username = "";
    this.model.password = "";
    this.accountService.logout();
    this.router.navigate(['/']) }

}
