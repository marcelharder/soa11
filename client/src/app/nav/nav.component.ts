import { Component, OnInit } from '@angular/core';
import { ChildActivationStart } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn: boolean;
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.model).subscribe((next)=>{
      console.log(next);
      this.loggedIn = true;
    }, error => console.log(error))
  }

}
