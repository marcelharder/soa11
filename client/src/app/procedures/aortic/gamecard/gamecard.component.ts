import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { CardData } from 'src/app/_models/CardData';
import { hospitalValve } from 'src/app/_models/hospitalValve';
import { Valve } from 'src/app/_models/Valve';
import { valveSize } from 'src/app/_models/valveSize';
import { AccountService } from 'src/app/_services/account.service';
import { AorticSurgeryService } from 'src/app/_services/aorticsurgery.service';
import { ValveService } from 'src/app/_services/valve.service';

@Component({
  selector: 'app-gamecard',
  templateUrl: './gamecard.component.html',
  styleUrls: ['./gamecard.component.scss'],
  animations: [
    trigger('cardFlip', [
      state('default', style({ transform: 'none' })),
      state('flipped', style({ transform: 'rotateY(180deg)' })),
      transition('default => flipped', [animate('400ms')]),
      transition('flipped => default', [animate('200ms')])
    ])
  ]
})
export class GamecardComponent implements OnInit {
  @Input() OAC: Array<hospitalValve>;
  @Input() currentHospital: string;
  @Output() tell = new EventEmitter<Valve>();
 
  conduitDescription = '';
  optionConduitSizes: Array<valveSize> = [];
  currentProcedureId = 0;
  hv: hospitalValve = {
    HospitalNo: 0,
    codeId: 0,
    code: "",
    valveTypeId: 0,
    description: "",
    position: "Aortic",
    size: 0,
    soort: 1,
    type: "",
  };
  pd: Valve = {
    Id: 0, Implant_Position: '', IMPLANT: '', EXPLANT: '', SIZE: '', TYPE: '', SIZE_EXP: '',
    TYPE_EXP: 0, ProcedureType: 0, ProcedureAetiology: 0, MODEL: '', MODEL_EXP: '', SERIAL_IMP: '',
    SERIAL_EXP: '', RING_USED: '', REPAIR_TYPE: '', Memo: '', Combined: 0, procedure_id: 0
  };

  constructor(
    private alertify: ToastrService,
    private vs: ValveService,
    private auth: AccountService,
    private aorticService: AorticSurgeryService) { }

  ngOnInit() {
    this.auth.currentProcedure$.pipe(take(1)).subscribe((u) => {this.currentProcedureId = u;})

  }

  data: CardData = {
    imageId: "",
    state: "default"
  };

  getThisConduit(x: any) {
    // add a new record
    this.vs.addValvedConduitInProcedure(this.currentProcedureId).subscribe((next) => {
      this.pd = next;
    })

    //So the conduitType is chosen, now add a hospitalValve from the conduit type
    const index = this.OAC.findIndex(a => a.valveTypeId === x);
    this.hv = this.OAC[index];
    // show card to enter details mn serial no and save this ring
    this.pd.SERIAL_IMP = '';
    this.pd.MODEL = this.hv.code;
    this.pd.TYPE = this.hv.type;
    this.vs.getValveCodeSizes(x).subscribe((next) => { this.optionConduitSizes = next; });

    this.cardClicked();
  }

  saveConduitDetails() {


    this.pd.TYPE = this.hv.type;
    this.pd.MODEL = this.hv.code;
    
    this.vs.saveValvedConduit(this.pd).subscribe((next) => {
      
      this.tell.emit(this.pd);
       
    
    },
      (error) => { this.alertify.error(error); }, () => {
        this.alertify.show("Conduit uploaded ...");
      })
    this.cardClicked();
  }
  CancelConduitDetails(){
    this.pd.SERIAL_IMP = "";
    this.pd.SIZE = "";
    this.cardClicked();
  }

  cardClicked() {
    if (this.data.state === "default") {
      this.data.state = "flipped";
    } else {
      this.data.state = "default";
    }
  }
}



