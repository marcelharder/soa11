import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { dropItem } from 'src/app/_models/dropItem';
import { ProcedureDetails } from 'src/app/_models/procedureDetails';
import { AccountService } from 'src/app/_services/account.service';
import { DropdownService } from 'src/app/_services/dropdown.service';
import { HospitalService } from 'src/app/_services/hospital.service';
import { ProcedureService } from 'src/app/_services/procedure.service';

@Component({
  selector: 'app-detailsmain',
  templateUrl: './detailsmain.component.html',
  styleUrls: ['./detailsmain.component.css']
})
export class DetailsmainComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;

  proc: ProcedureDetails;
  CurrentUserName='';
  Surgeons: Array<dropItem> = [];
  Assistants: Array<dropItem> = [];
  Perfusionists: Array<dropItem> = [];
  Anaesthesists: Array<dropItem> = [];
  Nurses: Array<dropItem> = [];
  timingOptions: Array<dropItem> = [];
  hours: Array<string> = [];
  mins: Array<string> = [];
  urgentOptions: Array<dropItem> = [];
  emergentOptions: Array<dropItem> = [];
  inotropeOptions: Array<dropItem> = [];
  pacemakerOptions: Array<dropItem> = [];
  pericardOptions: Array<dropItem> = [];
  pleuraOptions: Array<dropItem> = [];

  constructor(
    private procedureService: ProcedureService,
    private hospitalService: HospitalService,
    private route: ActivatedRoute,
    public auth: AccountService,
    private alertify: ToastrService,
    private drops: DropdownService
  ) {}

  ngOnInit(): void {
    /* 
    this.auth.currentUser$.pipe(take(1)).subscribe((u) => {this.CurrentUserName = u.username;})
    this.CurrentUserName = this.CurrentUserName[0].toUpperCase() + this.CurrentUserName.slice(1); // capitalize
    */
    this.route.data.subscribe(
      (data) => {
        this.proc = data.procedureDetails;

        this.loadEmployeeDrops(this.proc.hospital.toString());
      },
      (error) => {
        this.alertify.error(error);
      }
    );
    this.loadDrops();
  }

  loadEmployeeDrops(hospitalId: string) {
    // find out if this is the first time this procedure is added, if so then so only the active employees
    this.drops.isProcedureComplete(this.proc.patientId).subscribe((next) => {
      if (next === 'No') {
        // so we should show only the people that are still selectable
        this.drops
          .getEmployees(hospitalId, 'Surgery', 'true', 'Yes')
          .subscribe((response) => {
            this.Surgeons = response;
          });
        this.drops
          .getEmployees(hospitalId, 'Surgery', 'true', 'No')
          .subscribe((response) => {
            this.Assistants = response;
          });
        this.drops
          .getEmployees(hospitalId, 'anaesthesie', 'true', 'No')
          .subscribe((response) => {
            this.Anaesthesists = response;
          });
        this.drops
          .getEmployees(hospitalId, 'nurse', 'true', 'No')
          .subscribe((response) => {
            this.Nurses = response;
          });
        this.drops
          .getEmployees(hospitalId, 'perfusion', 'true', 'No')
          .subscribe((response) => {
            this.Perfusionists = response;
          });

       

      } // this is a historic record so all the employees in the database should be available
      else {
        this.drops
          .getEmployees(hospitalId, 'Surgery', 'false', 'Yes')
          .subscribe((response) => {
            this.Surgeons = response;
          });
        this.drops
          .getEmployees(hospitalId, 'Surgery', 'false', 'No')
          .subscribe((response) => {
            this.Assistants = response;
          });
        this.drops
          .getEmployees(hospitalId, 'anaesthesie', 'false', 'No')
          .subscribe((response) => {
            this.Anaesthesists = response;
          });
        this.drops
          .getEmployees(hospitalId, 'nurse', 'false', 'No')
          .subscribe((response) => {
            this.Nurses = response;
          });
        this.drops
          .getEmployees(hospitalId, 'perfusion', 'false', 'No')
          .subscribe((response) => {
            this.Perfusionists = response;
          });
      }
    });
  }
  loadDrops() {
    let d = JSON.parse(localStorage.getItem('timingOptions'));
    if (d == null || d.length === 0) {
      this.drops.getTimingOptions().subscribe((response) => {
        this.timingOptions = response;
        localStorage.setItem(
          'timingOptions',
          JSON.stringify(this.timingOptions)
        );
      });
    } else {
      this.timingOptions = JSON.parse(localStorage.getItem('timingOptions'));
    }

    d = JSON.parse(localStorage.getItem('urgentOptions'));
    if (d == null || d.length === 0) {
      this.drops.getUrgentOptions().subscribe((response) => {
        this.urgentOptions = response;
        localStorage.setItem(
          'urgentOptions',
          JSON.stringify(this.urgentOptions)
        );
      });
    } else {
      this.urgentOptions = JSON.parse(localStorage.getItem('urgentOptions'));
    }

    d = JSON.parse(localStorage.getItem('emergentOptions'));
    if (d == null || d.length === 0) {
      this.drops.getEmergentOptions().subscribe((response) => {
        this.emergentOptions = response;
        localStorage.setItem(
          'emergentOptions',
          JSON.stringify(this.emergentOptions)
        );
      });
    } else {
      this.emergentOptions = JSON.parse(
        localStorage.getItem('emergentOptions')
      );
    }

    d = JSON.parse(localStorage.getItem('inotropeOptions'));
    if (d == null || d.length === 0) {
      this.drops.getInotropeOptions().subscribe((response) => {
        this.inotropeOptions = response;
        localStorage.setItem(
          'inotropeOptions',
          JSON.stringify(this.inotropeOptions)
        );
      });
    } else {
      this.inotropeOptions = JSON.parse(
        localStorage.getItem('inotropeOptions')
      );
    }

    d = JSON.parse(localStorage.getItem('pacemakerOptions'));
    if (d == null || d.length === 0) {
      this.drops.getPacemakerOptions().subscribe((response) => {
        this.pacemakerOptions = response;
        localStorage.setItem(
          'pacemakerOptions',
          JSON.stringify(this.pacemakerOptions)
        );
      });
    } else {
      this.pacemakerOptions = JSON.parse(
        localStorage.getItem('pacemakerOptions')
      );
    }

    d = JSON.parse(localStorage.getItem('pericardOptions'));
    if (d == null || d.length === 0) {
      this.drops.getPericardOptions().subscribe((response) => {
        this.pericardOptions = response;
        localStorage.setItem(
          'pericardOptions',
          JSON.stringify(this.pericardOptions)
        );
      });
    } else {
      this.pericardOptions = JSON.parse(
        localStorage.getItem('pericardOptions')
      );
    }

    d = JSON.parse(localStorage.getItem('pleuraOptions'));
    if (d == null || d.length === 0) {
      this.drops.getPleuraOptions().subscribe((response) => {
        this.pleuraOptions = response;
        localStorage.setItem(
          'pleuraOptions',
          JSON.stringify(this.pleuraOptions)
        );
      });
    } else {
      this.pleuraOptions = JSON.parse(localStorage.getItem('pleuraOptions'));
    }

    for (let x = 0; x < 24; x++) {
      this.hours.push(x.toString());
    }
    for (let x = 0; x < 60; x++) {
      this.mins.push(x.toString());
    }
  }
  setStartTime() {
    let dayLightSavingTime = '0';
    let localDate = new Date();
    this.auth.dst.subscribe((next) => {
      dayLightSavingTime = next;
      const help = new Date();
      let timeOffSetMin = help.getTimezoneOffset();
      if (dayLightSavingTime === '1') {
        timeOffSetMin = timeOffSetMin + 60;
      }
      localDate = new Date(help.getTime() + timeOffSetMin * 60 * 1000);

      this.proc.selectedStartMin = localDate.getMinutes();
      this.proc.selectedStartHr = localDate.getHours();
    });
  }
  setStopTime() {
    let dayLightSavingTime = '0';
    let localDate = new Date();
    this.auth.dst.subscribe((next) => {
      dayLightSavingTime = next;
      const help = new Date();
      let timeOffSetMin = help.getTimezoneOffset();
      if (dayLightSavingTime === '1') {
        timeOffSetMin = timeOffSetMin + 60;
      }
      localDate = new Date(help.getTime() + timeOffSetMin * 60 * 1000);

      this.proc.selectedStopMin = localDate.getMinutes();
      this.proc.selectedStopHr = localDate.getHours();
    });
  }

  saveProcDetails() {
    // check that the assistant is entered
    let userId: number = 0;
    this.auth.currentUser$.pipe(take(1)).subscribe((u) => {userId = u.userId;})
    
    this.procedureService
      .saveProcedureDetails(userId, this.proc)
      .subscribe((next) => {
        if (next.toString() === '1') {
        } else {
          this.alertify.error('Procedure details did not update correctly ...');
        }
      });
  }

  surgeonHasNoLTK(){}

  canDeactivate() {
    this.saveProcDetails();
    this.alertify.show('saving procedure details');
    return true;
  }
}