import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { loginModel } from '../_models/loginModel';
import { User } from '../_models/User';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
user:Partial<User>;
editFlag = 0;
addFlag = 0;
model:loginModel = {username:'',password:''};

  constructor(private userService: UserService, private alertify:ToastrService, private router:Router) { }

  ngOnInit(): void {
    this.addFlag = 1;
  }

  cancelAdd(){this.editFlag = 0; this.addFlag = 0;};
  cancelEdit(){this.editFlag = 0; this.addFlag = 0;};

  showEdit() { if (this.editFlag === 1) return true; }
  showAdd() { if (this.addFlag === 1) return true; }


  returnFromAddUser(newUserId: number){
    this.userService.getUser(newUserId).subscribe((next)=>{
      this.user = next;
      this.editFlag = 1; this.addFlag = 0;
    }, (error)=> {this.alertify.error(error)});
  }

  returnFromUserEdit(ret: User){
    this.userService.updateUser(0, ret).subscribe(
      (next)=>{
        this.editFlag = 0; this.addFlag = 0;
        this.alertify.show("You can now login with your credentials ...");
        this.router.navigate(['/']);
      }, 
      (error)=>{
        debugger;
        this.alertify.error(error)})
  }

}
