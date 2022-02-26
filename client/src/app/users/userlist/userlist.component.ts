import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TabDirective } from 'ngx-bootstrap/tabs';
import { take } from 'rxjs/operators';
import { dropItem } from 'src/app/_models/dropItem';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';
import { DropdownService } from 'src/app/_services/dropdown.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {
  users: Array<User> = [];
  allUsers:Array<User> = [];
  position="";
  currentUserId = 0;
  currentHospital = 0;
  hospitals:Array<dropItem> = [];
  value?: string = 'User management';
  constructor(private userService: UserService, 
    private drop: DropdownService, 
    private router: Router,
    private auth: AccountService) { }

  ngOnInit(): void {
    // this.auth.currentUser$.pipe(take(1)).subscribe((u) => { this.currentUserId = u.UserId; });
    this.drop.getAllHospitals().subscribe(response => { 
      this.hospitals = response;
      this.currentHospital = response[0].value
    }, (error) => { console.log(error); });
   
    this.loadDrops();
    this.getUsers();
  }

  getUsers() { 
    this.userService.getUsers().subscribe(next => {

      this.allUsers = next.result;
      this.users = this.allUsers.filter(a => a.hospital_id == this.currentHospital);
    
    
    
    }) }

    onSelect(data: TabDirective): void {
      this.value = data.heading;
    }

  showHospitalDrop(){if(this.value === 'User management'){return true}}

  loadDrops(){

  }
  getPosition(ltk: boolean){ if(ltk){return "Surgeon"} else {return "Resident"} }

  selectUserPerHospital(){
    this.users = this.allUsers.filter(a => a.hospital_id == this.currentHospital);
  }

  editUser(id: number){
    debugger;
    this.router.navigate(['userdetails/'+ id])}
  deleteUser(id: number){}


}



function foreach(Hospital: any, arg1: boolean) {
  throw new Error('Function not implemented.');
}

function Hospital(Hospital: any, arg1: boolean) {
  throw new Error('Function not implemented.');
}

