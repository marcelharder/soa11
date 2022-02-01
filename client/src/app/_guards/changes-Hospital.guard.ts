import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { EditHospitalComponent } from '../configuration/hospital/edit-hospital.component';


@Injectable()

// tslint:disable-next-line:class-name
export class changesHospital implements CanDeactivate<EditHospitalComponent>{
    canDeactivate(component: EditHospitalComponent) {
        if (component.hospitalForm.dirty) {
            const can = component.canDeactivate();
            return can;
        }
        return true;
    }
}