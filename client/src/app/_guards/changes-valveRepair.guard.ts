import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { ValverepairComponent } from '../procedures/valverepair/valverepair.component';


@Injectable()


export class changesValveRepairDetails implements CanDeactivate<ValverepairComponent>{
    canDeactivate(component: ValverepairComponent) {
        if (component.saveAlways) {
            const can = component.canDeactivate();
            return can;
        }
        return true;
    }
}