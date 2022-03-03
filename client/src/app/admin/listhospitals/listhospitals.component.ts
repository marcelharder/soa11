import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Hospital } from 'src/app/_models/Hospital';
import { HospitalService } from 'src/app/_services/hospital.service';

@Component({
  selector: 'app-listhospitals',
  templateUrl: './listhospitals.component.html',
  styleUrls: ['./listhospitals.component.css']
})
export class ListhospitalsComponent implements OnInit {

  hospitals: Array<Partial<Hospital>> = [];
  editFlag = 0;
  addFlag = 0;
  listFlag = 1;

  constructor(private hospitalService: HospitalService, private router: Router) { }

  ngOnInit(): void {
    this.hospitalService.getHospitalsInCountry(31);
  }

  Cancel() { }

  addHospital() { }

  deleteHospital() { }

  editHospital() { }



}
