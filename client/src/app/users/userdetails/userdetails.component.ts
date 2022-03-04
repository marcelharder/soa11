import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { dropItem } from 'src/app/_models/dropItem';
import { User } from 'src/app/_models/User';
import { DropdownService } from 'src/app/_services/dropdown.service';

@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent implements OnInit {
  @Output() fromUserEdit = new EventEmitter<Partial<User>>();
  @Output() cancelThis = new EventEmitter<number>();
  @Input() user: Partial<User>;
  optionsGender:Array<dropItem> = [];
  public image = 0;
  
  constructor(
    private route: ActivatedRoute, 
    private router: Router, 
    private drops: DropdownService) { }

  ngOnInit(): void {
  
  this.loadDrops();
  }

  updateUserDetails(){ 
    this.user.worked_in = this.user.hospital_id.toString();
    this.fromUserEdit.emit(this.user);
  }

  Cancel(){this.cancelThis.emit(1)};

  loadDrops(){
    this.drops.getGenderOptions().subscribe((next) => { this.optionsGender = next; });
  }

  showChangeImage(){if(this.image == 1) {return true;}}

  updatePhoto(photoUrl: string) { this.image = 0; this.user.PhotoUrl = photoUrl; }



}
