import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { EmailModel } from 'src/app/_models/EmailModel';
import { RefPhysService } from 'src/app/_services/refPhys.service';

@Component({
  selector: 'app-email-ref-phys',
  templateUrl: './email-ref-phys.component.html',
  styleUrls: ['./email-ref-phys.component.css']
})
export class EmailRefPhysComponent implements OnInit {
  @Input() email: EmailModel;
  @Output() sendCancel = new EventEmitter<string>();

  editPanel = 0;

  constructor(private refPhys: RefPhysService, private alertify: ToastrService,) { }

  ngOnInit() {
  }

  editText(){
    this.editPanel = 1;

  }

  Cancel(){this.sendCancel.emit('1');}
  showEditPanel(){ if(this.editPanel === 1){return true;}}
  Send(){
    //send the email to the email service
    this.refPhys.sendEmail(this.email).subscribe((nex) => {
      this.alertify.show(nex);
      this.sendCancel.emit('1');
    },
    (error)=>{this.alertify.error('Sending email failed ...' + error);});
  }

}