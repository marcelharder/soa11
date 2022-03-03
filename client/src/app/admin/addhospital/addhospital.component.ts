import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { dropItem } from 'src/app/_models/dropItem';
import { Hospital } from 'src/app/_models/Hospital';
import { DropdownService } from 'src/app/_services/dropdown.service';
import { HospitalService } from 'src/app/_services/hospital.service';

@Component({
  selector: 'app-addhospital',
  templateUrl: './addhospital.component.html',
  styleUrls: ['./addhospital.component.css']
})
export class AddhospitalComponent implements OnInit {
  @Output() pushResult = new EventEmitter<number>();
  @Output() cancelThis = new EventEmitter<number>();
  @Input() selectedCountry: number;

  pd: Hospital = {
    hospitalName: '',
    selected_hospital_name: '',
    hospitalNo: '',
    description: '',
    imageUrl: '',
    city: '',
    address: '',
    country: 0,
    telephone: '',
    OpReportDetails1: '',
    OpReportDetails2: '',
    OpReportDetails3: '',
    OpReportDetails4: '',
    OpReportDetails5: '',
    OpReportDetails6: '',
    OpReportDetails7: '',
    OpReportDetails8: '',
    OpReportDetails9: ''
  };

  

  constructor(private hospitalService: HospitalService, 
    private alertify: ToastrService,
    private drop: DropdownService) { }

  ngOnInit(): void {
  
  }

 
  
  translateCountryNumberInISO(test: number){

  }

  Save(){
    this.hospitalService.addHospital(this.selectedCountry, +this.pd.hospitalNo).subscribe((next)=>{
    // get the rest from the entered data and update the hospital
    next.hospitalName = this.pd.hospitalName;
    next.hospitalNo = this.pd.hospitalNo;
    next.address = this.pd.address;
    next.telephone = this.pd.telephone;
    next.selected_hospital_name = this.pd.selected_hospital_name;

    this.hospitalService.saveHospital(next).subscribe(()=>{
    this.pushResult.emit(this.selectedCountry);
    })
   }, (error)=>{this.alertify.error(error)})
    
  }
  Cancel() { this.cancelThis.emit(1); }


}
