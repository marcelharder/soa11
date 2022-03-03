import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Hospital } from 'src/app/_models/Hospital';
import { HospitalService } from 'src/app/_services/hospital.service';

@Component({
  selector: 'app-edithospital',
  templateUrl: './edithospital.component.html',
  styleUrls: ['./edithospital.component.css']
})
export class EdithospitalComponent implements OnInit {
  @Input() pd?: Hospital;
  @Output() cancelThis = new EventEmitter<number>();

  constructor(private hospitalservice: HospitalService) { }

  ngOnInit(): void {
  }

  Cancel() { this.cancelThis.emit(1); }
  Save(){
  this.hospitalservice.saveHospital(this.pd).subscribe((next)=>{
    this.cancelThis.emit(1);
  })
  }
  updatePhoto(photoUrl: string) { this.pd.imageUrl = photoUrl;}

}
