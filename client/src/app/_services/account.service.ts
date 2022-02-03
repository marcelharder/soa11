import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Procedure } from '../_models/Procedure';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  private currentProcedureSource = new ReplaySubject<number>(1);

  currentUser$ = this.currentUserSource.asObservable();
  currentProcedure$ = this.currentProcedureSource.asObservable();

  soortProcedure = new BehaviorSubject<string>('0');
  currentSoortProcedure = this.soortProcedure.asObservable();

  HospitalName = new BehaviorSubject<string>('0');
  currentHospitalName = this.soortProcedure.asObservable();

  dst = new BehaviorSubject<string>('0');
  currentDst = this.dst.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response:User)=>{
        const user = response;
        if (user) {localStorage.setItem('user', JSON.stringify(user))};
        this.currentUserSource.next(user);
      })
    );
  }
  setCurrentUser(u: User){this.currentUserSource.next(u);}
  setCurrentProcedure(procedureId: number){this.currentProcedureSource.next(procedureId);}
  changeSoortOperatie(sh: string) { this.soortProcedure.next(sh); }
  changeCurrentHospital(sh: string){ this.HospitalName.next(sh);}
  changeDst(sh: string) { this.dst.next(sh); }

  logout(){localStorage.removeItem('user'); this.currentUserSource.next(null);}
}
