import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { dropItem } from 'src/app/_models/dropItem';
import { Hospital } from 'src/app/_models/Hospital';
import { HospitalService } from 'src/app/_services/hospital.service';

@Component({
  selector: 'app-listhospitals',
  templateUrl: './listhospitals.component.html',
  styleUrls: ['./listhospitals.component.css']
})
export class ListhospitalsComponent implements OnInit {

  hospitals: Array<Partial<Hospital>> = [];
  selectedHospital: Hospital;
  selectedCountry = 31;
  listOfCountries:Array<dropItem> = [];
  editFlag = 0;
  addFlag = 0;
  listFlag = 1;

  constructor(
    private hospitalService: HospitalService, 
    private router: Router, 
    private alertify: ToastrService) { }

  ngOnInit(): void {
    this.loadDrops();
   this.filterCountry();
  }

  loadDrops(){
    this.listOfCountries.push({value:31,description:"Netherlands"});
    this.listOfCountries.push({value:1,description:"US"});
    this.listOfCountries.push({value:49,description:"UK"});
    this.listOfCountries.push({value:63,description:"France"});
    this.listOfCountries.push({value:37,description:"Germany"});
    this.listOfCountries.push({value:39,description:"Italy"});
    this.listOfCountries.push({value:966,description:"KSA"});
  }

  filterCountry(){
    this.hospitalService.getHospitalsInCountry(this.selectedCountry).subscribe((next)=>{this.hospitals = next;})
  }

  showAdd(){if(this.addFlag === 1){return true;}}
  showEdit(){if(this.editFlag === 1){return true;}}
  showList(){if(this.listFlag === 1){return true;}}

  Cancel() { this.router.navigate(['/']) }

  addHospital() {
    this.addFlag = 1;
    this.editFlag = 0;
    this.listFlag = 0;
   }
   editHospital(ret: string) {
    this.hospitalService.getSpecificHospital(+ret).subscribe((next)=>{ 
    
      this.selectedHospital = next});
    this.addFlag = 0;
    this.listFlag = 0;
    this.editFlag = 1;
  }
  deleteHospital(ret: string) {
    this.addFlag = 0;
    this.editFlag = 0;
    this.listFlag = 1;
    this.hospitalService.deleteHospital(ret).subscribe((next)=>{this.alertify.show("Hospital removed ...")});
    this.filterCountry();
  }

   backFromAdd(ret: any){
    this.addFlag = 0;
    this.listFlag = 1;
    this.editFlag = 0;
   }

   backFromEdit(ret: any){
    this.addFlag = 0;
    this.listFlag = 1;
    this.editFlag = 0;
  }

  receiveSelectedCountry(ret: number){
    this.selectedCountry = ret;
    this.filterCountry();
    this.addFlag = 0;
    this.listFlag = 1;
    this.editFlag = 0;
  }


}
