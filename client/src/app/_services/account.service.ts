import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { loginModel } from '../_models/loginModel';
import { onlineUsers } from '../_models/onlineUsers';
import { Procedure } from '../_models/Procedure';
import { User } from '../_models/User';
import { PresenceService } from './presence.service';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  private currentProcedureSource = new ReplaySubject<number>(1);
  private newRegisteredUserSource = new ReplaySubject<User>(1);
  private serviceLevel = new ReplaySubject<number>(1);

  currentUser$ = this.currentUserSource.asObservable();
  newlyRegisteredUser$ = this.newRegisteredUserSource.asObservable();
  currentServiceLevel$ = this.serviceLevel.asObservable();

  currentProcedure$ = this.currentProcedureSource.asObservable();

  soortProcedure = new BehaviorSubject<string>('0');
  currentSoortProcedure = this.soortProcedure.asObservable();


  HospitalName = new BehaviorSubject<string>('0');
  currentHospitalName = this.HospitalName.asObservable();

  dst = new BehaviorSubject<string>('0');
  currentDst = this.dst.asObservable();



  constructor(private http: HttpClient, private presence: PresenceService) { }

  login(model: loginModel) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        this.setCurrentUser(user);
        this.presence.createHubConnection(user);
      })
    );
  }


  register(model: loginModel) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((user: User) => {
        if (user) {
          user.roles = [];
          const roles = this.getDecodedToken(user.Token).role;
          Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
          this.newRegisteredUserSource.next(user);
        }
      })
    )
  }




  setCurrentUser(user: User) {
    // find out if this is a premium client
    const currentDate = new Date();
    if (moment(user.paidTill).year() === 1) { this.serviceLevel.next(0) } else {
      if (moment(currentDate).isBefore(user.paidTill)) {
        this.serviceLevel.next(1);
      } else { this.serviceLevel.next(0); }
    }
    user.roles = [];
    const roles = this.getDecodedToken(user.Token).role;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  setCurrentProcedure(procedureId: number) { this.currentProcedureSource.next(procedureId); }
  changeSoortOperatie(sh: string) { this.soortProcedure.next(sh); }
  changeCurrentHospital(sh: string) { this.HospitalName.next(sh); }
  changeDst(sh: string) { this.dst.next(sh); }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.presence.stopHubConnection();
  }

  changePassword(u: User, pwd_02: string) {
    return this.http.put(this.baseUrl + 'account/changePassword/' + pwd_02, u).pipe(
      map((response: User) => {
        const user = response;
        if (user) { localStorage.setItem('user', JSON.stringify(user)) };
        this.currentUserSource.next(user);
      })
    );
  }

  getDecodedToken(token) {
    return JSON.parse(atob(token.split('.')[1]));
  }


}
