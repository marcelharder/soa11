import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { loginModel } from 'src/app/_models/loginModel';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  @Output() fromUserAdd = new EventEmitter<number>();
  @Output() cancelThis = new EventEmitter<number>();
  currentHospitalId = 0;
  user:Partial<User> = {
    UserId:0,
    hospital_id: 0,
    password: '',
    Username:  '',
    Token:  '',
    knownAs:  '',
    age: 0,
    gender:  '',
    city:  '',
    mobile:  '',
    email:  '',
    country:  '',
    worked_in:  '',
  };
  //lm: loginModel = { username: "", password: "" };
  newUserId = 0;
  constructor(private auth: AccountService,
    private alertify: ToastrService) { }

  ngOnInit(): void { }

  Cancel() { this.cancelThis.emit(1); }

  registerNewUser() {
    if (this.checkUserNameIsEmail(this.user)) {
      if (this.readytobeSentUp(this.user)) {
        this.auth.register(this.user).subscribe((next) => {
          this.auth.newlyRegisteredUser$.pipe(take(1)).subscribe((u) => { this.newUserId = u.UserId; });
          this.fromUserAdd.emit(this.newUserId);
        }, (error) => { this.alertify.error(error) });
      }
    } else { this.alertify.error("Username is not a valid email")}
  }

  checkUserNameIsEmail(test: Partial<User>) {
    var help = false;
    let regexpEmail =
      new RegExp('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$');
    help = regexpEmail.test(test.Username);
    return help;
  }



  readytobeSentUp(test: Partial<User>) {
    let helpDigit = false;
    let helpUpper = false;
    let helpLength = false;
   
    // check for one digit
    let containsDigit = new RegExp('\\d');
    helpDigit = containsDigit.test(test.password);
    
    if (!helpDigit) { this.alertify.error("Password should contain digit") };

    // check for one Uppercase
    let containsUpperCase = new RegExp('.*[A-Z].*');
    helpUpper = containsUpperCase.test(test.password);
    if (!helpUpper) { this.alertify.error("Password should contain Uppercase") };

    // check for correct length
    let containsCorrectLength = new RegExp('^(?=.{6,8}$).*');
    helpLength = containsCorrectLength.test(test.password);
    if (!helpLength) { this.alertify.error("Password should be between 6-8 char") };


    if (helpDigit && helpUpper && helpLength) { return true } else return false;

  }

}
