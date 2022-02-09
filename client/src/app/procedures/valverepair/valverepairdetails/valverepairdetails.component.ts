import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { dropItem } from 'src/app/_models/dropItem';
import { hospitalValve } from 'src/app/_models/hospitalValve';
import { Valve } from 'src/app/_models/Valve';
import { valveSize } from 'src/app/_models/valveSize';
import { AccountService } from 'src/app/_services/account.service';
import { DropdownService } from 'src/app/_services/dropdown.service';
import { HospitalService } from 'src/app/_services/hospital.service';
import { UserService } from 'src/app/_services/user.service';
import { ValveService } from 'src/app/_services/valve.service';

@Component({
  selector: 'app-valverepairdetails',
  templateUrl: './valverepairdetails.component.html',
  styleUrls: ['./valverepairdetails.component.css']
})
export class ValverepairdetailsComponent implements OnInit {
  @Input() pd: Valve;
  @Output() add = new EventEmitter<Valve>();

  currentUserId = 0;
  
  currentHospitalNo = '';
  currentHospital = '';
  additionalDetails = 0;
  additionalTDetails = 0;
  availableRings = 0;
  availableTRings = 0;
  ringCheck = false;
  tricuspidRingUsed = false;

  selectedRingType: hospitalValve = {
    codeId: 0,
    code: "",
    valveTypeId: 0,
    description: "",
    position: "Aortic",
    soort: 1,
    type: "",
  };
  editCard = 0;
  itring = 0;

  optionsMitralRepairType: Array<dropItem> = [];
  optionsTricuspidRepairType: Array<dropItem> = [];
  optionsAvailableMitralRings: Array<hospitalValve> = [];
  optionsAvailableTricuspidRings: Array<hospitalValve> = [];
  optionMitralRingSizes: Array<valveSize> = [];
  optionTricuspidRingSizes: Array<valveSize> = [];

  constructor(
    private auth: AccountService,
    private user: UserService,
    private hos: HospitalService,
    private vs: ValveService,
    private drops: DropdownService,
    private alertify: ToastrService) { }

  ngOnInit() {
    this.auth.currentHospitalName.subscribe((next)=>{this.currentHospital = next;});
    this.auth.currentUser$.pipe(take(1)).subscribe((u) => {this.currentUserId = u.UserId;})
    
    this.vs.getHospitalValves("Annuloplasty_Ring", "Mitral").subscribe((next) => {
      this.optionsAvailableMitralRings = next;
    })
    this.vs.getHospitalValves("Annuloplasty_Ring", "Tricuspid").subscribe((next) => {
      this.optionsAvailableTricuspidRings = next;
    })
    if (this.pd.Memo.length > 0) { this.additionalDetails = 1; this.additionalTDetails = 1; }
    if (this.pd.RING_USED === 'true') {this.availableRings = 1; this.ringCheck = true
    } else {this.availableRings = 0;this.ringCheck = false
    }
    this.loadDrops();

  }

  loadDrops() {
    let d = JSON.parse(localStorage.getItem('MitralRepairType'));
    if (d == null || d.length === 0) {
      this.drops.getMitralValveRepair().subscribe((response) => {
        this.optionsMitralRepairType = response;
        localStorage.setItem('MitralRepairType', JSON.stringify(response));
      });
    } else {
      this.optionsMitralRepairType = JSON.parse(
        localStorage.getItem('MitralRepairType')
      );
    }
    d = JSON.parse(localStorage.getItem('TricuspidRepairType'));
    if (d == null || d.length === 0) {
      this.drops.getTricuspidValveRepair().subscribe((response) => {
        this.optionsTricuspidRepairType = response;
        localStorage.setItem('TricuspidRepairType', JSON.stringify(response));
      });
    } else {
      this.optionsTricuspidRepairType = JSON.parse(
        localStorage.getItem('TricuspidRepairType')
      );
    }

  }

  showMVP() { if (this.pd.Implant_Position === 'Mitral') { return true; } }
  showTVP() { if (this.pd.Implant_Position === 'Tricuspid') { return true; } }
  showEditCard() { if (this.editCard === 1) { return true; } }
  showAdditionalDetails() { if (this.additionalDetails === 1) { return true } }
  showAdditionalTDetails() { if (this.additionalTDetails === 1) { return true } }
  showAvailableRings() { if (this.availableRings === 1) { return true; } }
  showTricuspidRingDetails(){if (this.availableTRings === 1) { return true; }}
  showTricuspidIndividualRing(){if (this.itring === 1) { return true; }}

  getThisOne(x: number) {
    // x = the id of the valvetype in the mitral position that is chosen.
    const index = this.optionsAvailableMitralRings.findIndex(a => a.valveTypeId === x);
    this.selectedRingType = this.optionsAvailableMitralRings[index];
    // show card to enter details mn serial no and save this ring
    this.editCard = 1;
    this.availableRings = 0;
    this.pd.SERIAL_IMP = '';
    this.pd.MODEL = this.selectedRingType.code;
    this.pd.TYPE = this.selectedRingType.type;
    this.vs.getValveCodeSizes(x).subscribe((next) => { this.optionMitralRingSizes = next; });

  }
  getThisTricuspidRing(x: number){
    this.itring = 1;
    const index = this.optionsAvailableTricuspidRings.findIndex(a => a.valveTypeId === x);
    this.selectedRingType = this.optionsAvailableTricuspidRings[index];
    this.pd.SERIAL_IMP = '';
    this.pd.MODEL = this.selectedRingType.code;
    this.pd.TYPE = this.selectedRingType.type;
    this.vs.getValveCodeSizes(x).subscribe((next) => { this.optionTricuspidRingSizes = next; });
  }
  saveRing() { // send the changed valve to the parent

   if(this.showTVP()){
    this.itring = 0; // hide panel with individualTricuspidRing
    if (this.tricuspidRingUsed) {
      if (this.pd.SERIAL_IMP != '' && this.pd.SIZE != '') {
        this.pd.RING_USED = 'true'; 
        this.add.emit(this.pd);
      }
      else { this.alertify.warning("Pls, enter serial and/or size ...") }
    } else {
      // remove all that relates to a ring that is not placed
      this.pd.RING_USED = 'false'; 
      this.pd.SERIAL_IMP = "";
      this.pd.MODEL = "";
      this.pd.SIZE = "";
      this.add.emit(this.pd);
    }


   }
   if(this.showMVP()){
    if (this.ringCheck === true) {
      if (this.pd.SERIAL_IMP != '' && this.pd.SIZE != '') {
        this.pd.RING_USED = 'true'; 
        this.add.emit(this.pd);
      }
      else { this.alertify.warning("Pls, enter serial and/or size ...") }
    } else {
      // remove all that relates to a ring that is not placed
      this.pd.RING_USED = 'false'; 
      this.pd.SERIAL_IMP = "";
      this.pd.MODEL = "";
      this.pd.SIZE = "";
      this.add.emit(this.pd);
    }
  }

  }



  onCheckBoxChange(test: any) {
    if(this.showMVP()){
    if (test.target.id === 'customCheckDetails') { if (!test.target.checked) { this.pd.Memo = ''; } }

    if (test.target.id === 'customCheck') {
      if (this.ringCheck === false) {
        this.editCard = 0;
        this.availableRings = 0;
        this.pd.SERIAL_IMP = "";
        this.pd.MODEL = "";
        this.pd.SIZE = "";
        this.pd.Combined = 0;
      } else {
        this.availableRings = 1;
        this.editCard = 0;
      }
    }}

    if(this.showTVP()){

    if (test.target.id === 'customCheckTDetails') { if (!test.target.checked) { this.pd.Memo = ''; } }
   
    if (test.target.id === 'customTCheck') {
      if (this.tricuspidRingUsed === false) {
        this.alertify.show("hide");
        this.availableTRings = 0;
        this.pd.SERIAL_IMP = "";
        this.pd.MODEL = "";
        this.pd.SIZE = "";
        this.pd.Combined = 0;
      } else {
        this.alertify.show("show");
        this.availableTRings = 1;
        
      }
    }

  }
  }



}

