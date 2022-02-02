import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { dropItem } from 'src/app/_models/dropItem';
import { Valve } from 'src/app/_models/Valve';
import { AccountService } from 'src/app/_services/account.service';
import { DropdownService } from 'src/app/_services/dropdown.service';
import { HospitalService } from 'src/app/_services/hospital.service';
import { UserService } from 'src/app/_services/user.service';
import { ValveService } from 'src/app/_services/valve.service';

@Component({
  selector: 'app-valverepair',
  templateUrl: './valverepair.component.html',
  styleUrls: ['./valverepair.component.css']
})
export class ValverepairComponent implements OnInit {
  @ViewChild('valveRepairForm') vrForm: NgForm;
  pd: Array<Valve> = [];
  procedureValve: Valve = {
    Id: 0,
    Implant_Position: '', IMPLANT: '', EXPLANT: '', SIZE: '', TYPE: '', SIZE_EXP: '',
    TYPE_EXP: 0, ProcedureType: 0, ProcedureAetiology: 0, MODEL: '', MODEL_EXP: '', SERIAL_IMP: '',
    SERIAL_EXP: '', RING_USED: '', REPAIR_TYPE: '', Memo: '', Combined: 0, procedure_id: 0
  };
  h = '';
  title = '';
  valveDescription = '';

  exring = 0;
  exrepair = 0;
  chooseUpdate = 0;

  currentHospitalNo = '';
  currentUserId = 0;
  currentProcedureId = 0;
  oviHospital = 0;
  selectedCard = 1;
  mitralRingUsed = false;
  tricuspidRingUsed = false;
  showManual = false;

  optionsMitralRepairType: Array<dropItem> = [];
  optionsTricuspidRepairType: Array<dropItem> = [];
  optionsMitralSizes: Array<string> = [];
  optionsTricuspidSizes: Array<string> = [];
  optionsMitralRingType: Array<dropItem> = [];
  optionsTricuspidRingType: Array<dropItem> = [];

  optionsAvailableMitralRings: Array<dropItem> = [];
  optionsAvailableTricuspidRings: Array<dropItem> = [];

  saveAlways = false;

  constructor(
    private alertify: ToastrService,
    private auth: AccountService,
    private hos: HospitalService,
    private userService: UserService,
    private drops: DropdownService,
    private valveService: ValveService,
    private router: Router,
    private route: ActivatedRoute
  ) { }
  ngOnInit(): void {
    this.auth.currentUser$.pipe(take(1)).subscribe((u) => {this.currentUserId = u.userId;})
    this.userService
      .getUser(this.currentUserId)
      .subscribe((next) => {
        this.currentHospitalNo = next.hospital_id.toString();
        var index = next.hospital_id;
        // find out if I can show the available valves in the participating hospital
        this.hos.IsThisHospitalUsingOVI(index).subscribe(
          (next) => { if (next) { this.oviHospital = 1; } })
      });
    this.auth.currentSoortProcedure.subscribe((next) => { this.h = next; });

    this.route.data.subscribe((data) => {
      if (data.valve.length > 0) { // there are repairs recorded for this procedure_id, because the resolver only finds repairs
        this.exrepair = 1;
        this.pd = data.valve;
        //get the index of this list, which are all valve repairs
        if (this.h === 'mvp') {
          const index = this.pd.findIndex(a => a.Implant_Position === 'Mitral');
          this.procedureValve = this.pd[index];
          // find out if a ring was used
          if (this.procedureValve.RING_USED === 'true') {
            // get the description of this valve
            this.valveService.getValveDescription(this.procedureValve.MODEL).subscribe((response) => { this.valveDescription = response; });
            this.exring = 1;
          } else { this.exring = 0; }
        } else {
          if (this.h === 'tvp') {
            const index = this.pd.findIndex(a => a.Implant_Position === 'Tricuspid'); 
            this.procedureValve = this.pd[index];
            // find out if a ring was used
            if (this.procedureValve.RING_USED === 'true') {
              // get the description of this valve
              this.valveService.getValveDescription(this.procedureValve.MODEL).subscribe((response) => { this.valveDescription = response; });
              this.exring = 1;
            } else { this.exring = 0; }
          }
        }
      } else { // there is no repair recorded for this procedure_id
        this.exrepair = 0;
        // add a new record to the database
        this.auth.currentProcedure$.pipe(take(1)).subscribe((next) => { this.currentProcedureId = next });
        if (this.h === 'mvp') {
          this.valveService.addValveRepairInProcedure('Mitral', this.currentProcedureId).subscribe((response) => { this.procedureValve = response; });
        } else {
          if (this.h === 'tvp') {
            this.valveService.addValveRepairInProcedure('Tricuspid', this.currentProcedureId).subscribe((response) => { this.procedureValve = response; });
          };
        }
      }
    });

  }

  IsOVIHospital() { if (this.oviHospital === 1 && this.exrepair === 0) { return true; } }

  getRepairDescription(test: string) {
    var index = 0;
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
    if (this.procedureValve.Implant_Position === 'Mitral') {
      index = this.optionsMitralRepairType.findIndex(x => x.value === +test);
      return this.optionsMitralRepairType[index].description;
    } else {
      index = this.optionsTricuspidRepairType.findIndex(x => x.value === +test);
      return this.optionsTricuspidRepairType[index].description;
    };
  }
  showExistingRing() { if (this.exring === 1) { return true; } }
  showExistingRepair() { if (this.exrepair === 1) { return true; } }

  deleteRepair() {
    this.chooseUpdate = 0;
    this.valveService.deleteValve(this.procedureValve.Id).subscribe((next) => {
        this.router.navigate(['/valverepair/' + this.currentProcedureId]);
     });

  }
  editRepair() { this.chooseUpdate = 1; this.exrepair = 0; }

  /* saveAos() {
    this.valveService.saveValve(this.procedureValve).subscribe(
      (next) => { this.alertify.message("Repair saved ...") },
      (error) => { this.alertify.error(error) }, () => { })
  } */

  receiveCompletedValve(gift: Valve) {
    this.procedureValve = gift;
    // update annuloplasty item to this procedure
    this.valveService.saveValveRepair(this.procedureValve).subscribe(
      (next) => { this.alertify.show("Repair saved ...") },
      (error) => { this.alertify.error(error) }, () => { this.exrepair = 1; })
  } // show the completed valve repair})

  canDeactivate() {

    return true;
  }

}
