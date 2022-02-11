import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { dropItem } from 'src/app/_models/dropItem';
import { hospitalValve } from 'src/app/_models/hospitalValve';
import { Valve } from 'src/app/_models/Valve';
import { valveSize } from 'src/app/_models/valveSize';
import { AccountService } from 'src/app/_services/account.service';
import { PatientService } from 'src/app/_services/patient.service';
import { ProcedureService } from 'src/app/_services/procedure.service';
import { ValveService } from 'src/app/_services/valve.service';

@Component({
  selector: 'app-valvedetails',
  templateUrl: './valvedetails.component.html',
  styleUrls: ['./valvedetails.component.css']
})
export class ValvedetailsComponent implements OnInit {

  @Input() hv: hospitalValve;
  @Input() pd: Valve;

  @Input() hospitalId: string;
  modalRef: BsModalRef;

  currentProcedureId = 0;

  typeDescription = '';
  valveDescription = '';
  hospitalValves: Array<hospitalValve> = [];
  optionsTypes: Array<dropItem> = [];
  optionSizes: Array<valveSize> = [];
  serialNo = "";
  new_valve: Valve = {
    Id: 0,
    Implant_Position: '', IMPLANT: '', EXPLANT: '', SIZE: '', TYPE: '', SIZE_EXP: '',
    TYPE_EXP: 0, ProcedureType: 0, ProcedureAetiology: 0, MODEL: '', MODEL_EXP: '', SERIAL_IMP: '',
    SERIAL_EXP: '', RING_USED: '', REPAIR_TYPE: '', Memo: '', Combined: 0, procedure_id: 0
  };

  panel1 = 0;
  panel2 = 0;
  panel3 = 0;


  ppmAdvice = 0;
  valveSize = "Choose";
  adviceText = "Hier komt de advice text";

  constructor(
    private modalService: BsModalService,
    private alertify: ToastrService,
    private router: Router,
    private auth: AccountService,
    private proc: ProcedureService,
    private patient: PatientService,
    private vs: ValveService) { }

  ngOnInit() {
    this.auth.currentProcedure$.pipe(take(1)).subscribe((u) => { this.currentProcedureId = u; })
    this.loadDrops();
  }


  loadDrops() { this.optionsTypes.push({ value: 1, description: 'Biological' }, { value: 2, description: 'Mechanical' }); };
  showPanel_1() {

   // this.vs.getSpecificHospitalValve(this.pd.MODEL).subscribe((next) => {this.valveDescription = next.description;});

    if (this.panel1 === 1 || this.pd.Implant_Position !== '') {
      
    return true;
    }
  };
  showPanel_2() { if (this.panel2 === 1 || this.pd.Implant_Position === '') { return true; } };
  showPanel_3() { if (this.panel3 === 1) { return true; } };

  showEoaAdvice() {
    if (this.hv.implant_Position === 'Aortic') { if (this.ppmAdvice === 1) { return true; } } else { return false; }
  }

  getModelsInHospital() {
    this.vs.getHospitalValves(this.hv.type, this.hv.implant_Position).subscribe(
      (next) => { this.hospitalValves = next }, (error) => { this.alertify.error(error) })
  }

  deleteValve() {
    this.vs.deleteValve(this.pd.Id).subscribe((next) => {
      // route to the valve page
      this.alertify.show(next);
      this.pd.Implant_Position = "";
      this.pd.MODEL = "";
      this.pd.TYPE = "";
      this.pd.SIZE = "";
      this.pd.SERIAL_IMP = "";
      this.valveDescription = "";

      this.panel1 = 0; this.panel2 = 1; this.panel3 = 0;
    }, (error) => { this.alertify.error(error) })
  }

  findEOA() {
    if (this.hv.implant_Position === 'Aortic') { // give only advice about aortic valves
      let procedureId = 0;
      let patientId = 0;
      let height = 0;
      let weight = 0;
      let eoa = 0;
      let eoai = 0;

      this.proc.getProcedure(this.currentProcedureId).subscribe((next) => {
        patientId = next.patientId;
        this.patient.getPatientFromId(patientId).subscribe((next) => {
          height = next.height;
          weight = next.weight;
          debugger;
          this.vs.getPPM(this.pd.MODEL, this.valveSize, weight.toString(), height.toString()).subscribe((next) => {
            this.adviceText = "You can expect " + next.body + " PPM";
          }, (error) => { this.adviceText = error; })
        })
      })


      this.alertify.show("Finding EOAi of valve " + this.pd.MODEL + "  with size " + this.valveSize);
      this.ppmAdvice = 1;

    }
  }

  implantValve(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
    if (this.pd.SERIAL_IMP == "") { this.alertify.warning("Please enter serial number of this valve ...") }
  }
  confirm(): void {
    // save to the database
    this.vs.addValveInProcedure(this.pd.SERIAL_IMP, this.currentProcedureId).subscribe((nex) => {
      this.new_valve = nex;
      debugger;
      if (this.pd.Combined != 0) { this.new_valve.Combined = this.pd.Combined; }
      if (this.pd.ProcedureType != 0) { this.new_valve.ProcedureType = this.pd.ProcedureType; }
      if (this.pd.ProcedureAetiology != 0) { this.new_valve.ProcedureAetiology = this.pd.ProcedureAetiology; }
      this.new_valve.MODEL = this.hv.code;
      this.new_valve.TYPE = this.hv.type;
      this.new_valve.Implant_Position = this.hv.implant_Position;
      this.new_valve.SIZE = this.valveSize;
    });
    this.vs.updateValve(this.new_valve).subscribe((response) => {this.alertify.show(response);}, (error) => {
      this.alertify.error(error);
    }, ()=>{
      debugger;
      this.panel1 = 1;
      this.panel2 = 0;
      this.panel3 = 0;

    })
   

    this.modalRef?.hide();
  }

  decline(): void {
    this.panel3 = 0;
    this.modalRef?.hide();
  }

  selectThisValve(code: string) {
    // copy the hospitalValve to pd, get the specific valve details first
    this.valveSize = '0';
    this.pd.SERIAL_IMP = "";
    this.pd.MODEL = code;
    this.ppmAdvice = 0;

   /*  this.vs.getSpecificHospitalValve(code).subscribe(
      (next) => {
        this.hv = next;
        this.valveDescription = next.description;
        this.typeDescription = next.type;

        this.vs.getValveCodeSizes(next.valveTypeId).subscribe((nex) => { this.optionSizes = nex; });
      },
      (error) => { this.alertify.error(error) }) */
    this.panel1 = 0; this.panel2 = 1; this.panel3 = 1;
    this.alertify.show("select this valve ...");
  }

}
