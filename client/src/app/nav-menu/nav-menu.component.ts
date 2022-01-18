import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { AuthService } from '../_services/AuthService.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  model: any = {};
  welcometext = 'Welcome';

  loginFailed = false;

  constructor(
    public auth: AuthService,
    private alertify: AlertifyService,
    private router: Router
  ) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnInit() { }

  loggedIn() {return this.auth.loggedIn();}

  loggedInAsSurgeon() {
    if (this.loggedIn()) {
      if (this.auth.decodedToken?.role === 'Surgery') {
        return true;
      } else {
        return false;
      }
    } else {
      return false;
    }
  }

  loggedInAsChef() {
    if (this.loggedIn()) {
      if (this.auth.decodedToken?.role === 'Chef') {
        return true;
      } else {
        return false;
      }
    } else {
      return false;
    }
  }

  loggedInAsAdmin() {
    if (this.loggedIn()) {
      if (this.auth.decodedToken?.role === 'admin') {
        return true;
      } else {
        return false;
      }
    } else {
      return false;
    }
  }

  logIn() { this.router.navigate(['/login']); }

  logOut() {
    this.router.navigate(['/home']);
    this.alertify.message('Logged out');
    localStorage.removeItem('token');
  }

  showRegister() {
    this.loginFailed = false;
    this.router.navigate(['/register']);
  }

  showProfile() {
    this.router.navigate(['/profile/', +this.auth.decodedToken.nameid]);
  }

  loginFail() {
    if (this.loginFailed === true) {
      return true;
    } else {
      return false;
    }
  }
}
