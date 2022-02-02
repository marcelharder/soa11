import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { dropItem } from 'src/app/_models/dropItem';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit  {
  selectedPerson = '';
  @Input() profession: string;
  @Input() list: Array<dropItem>;
  @Output() edit = new EventEmitter<string>();
  @Output() add = new EventEmitter<string>();

  constructor() {

  }
  ngOnInit(): void {
    //  this.selectedPerson = this.list[0].description;
   }

  editEmployee(id: number) { this.edit.emit(id.toString()); }
  addEmployee() { this.add.emit(this.profession); }
}
