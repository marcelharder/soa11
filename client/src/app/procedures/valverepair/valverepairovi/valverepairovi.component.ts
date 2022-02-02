import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { take } from 'rxjs/operators';
import { User } from 'src/app/_models/User';
import { Valve } from 'src/app/_models/Valve';
import { AccountService } from 'src/app/_services/account.service';
import { HospitalService } from 'src/app/_services/hospital.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-valverepairovi',
  templateUrl: './valverepairovi.component.html',
  styleUrls: ['./valverepairovi.component.css']
})
export class ValverepairoviComponent implements OnInit  {
  @Input() pd: Valve;
  @Output() add = new EventEmitter<Valve>();
 
  currentHospital = "";

  constructor(
    private auth: AccountService, 
    ) { }

  ngOnInit() {
   
    this.auth.currentHospitalName.subscribe((next)=>{this.currentHospital = next;})
  }

  showMVP() { if (this.pd.Implant_Position === 'Mitral') { return true; } }
  showTVP() { if (this.pd.Implant_Position === 'Tricuspid') { return true; } }

  saveRing(){
    this.add.emit(this.pd);
  }

}