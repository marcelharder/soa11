import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { loginModel } from 'src/app/_models/loginModel';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
 @Output() fromUserAdd = new EventEmitter<number>();
 currentHospitalId = 0;
 lm: loginModel = {username: "", password: ""};
 newUserId = 0;
  constructor(private auth: AccountService, 
    private route: ActivatedRouteSnapshot,
    private alertify:ToastrService, 
    private router: Router) { }

  ngOnInit(): void { }

  Cancel(){this.router.navigate(['users'])}

  registerNewUser(){
    this.auth.register(this.lm).subscribe( (next)=>{
      this.auth.currentUser$.pipe(take(1)).subscribe((u) => { this.newUserId = u.UserId; });
      this.fromUserAdd.emit(this.newUserId);
    },(error)=>{this.alertify.error(error)});

  }

}
