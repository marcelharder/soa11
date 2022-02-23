import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RolesModalComponent } from 'src/app/_modals/roles-modal/roles-modal.component';
import { User } from 'src/app/_models/User';
import { AdminService } from 'src/app/_services/admin.service';

@Component({
  selector: 'app-app-user-management',
  templateUrl: './app-user-management.component.html',
  styleUrls: ['./app-user-management.component.css']
})
export class AppUserManagementComponent implements OnInit {
  users: Partial<User[]>;
  bsModalRef: BsModalRef;
  constructor(private adminservice: AdminService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getUsersWithRoles();
  }

  getUsersWithRoles() {

    this.adminservice.getUsersWithRoles().subscribe(next => { this.users = next })
  }

  openRolesModal(){
    const initialState = {
      list: [
        'Open a modal with component',
        'Pass your data',
        'Do something else'
      ],
     
    };

    this.bsModalRef = this.modalService.show(RolesModalComponent, {initialState});
    this.bsModalRef.content.closeBtnName = "Close";
    this.bsModalRef.content.title = "Modal with Component";

  }

}
