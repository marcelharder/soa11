import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/_models/User';

@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent implements OnInit {
  @Output() fromUserEdit = new EventEmitter<User>();
  @Output() cancelThis = new EventEmitter<number>();
  @Input() user: User;
  
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
  
  }

  updateUserDetails(){
    this.fromUserEdit.emit(this.user);
  }

  Cancel(){this.cancelThis.emit(1)};

}
