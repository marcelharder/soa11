import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { CabgComponent } from '../procedures/Cabg/cabg.component';


@Injectable()

// tslint:disable-next-line:class-name
export class changesCABGDetails implements CanDeactivate<CabgComponent>{
    canDeactivate(component: CabgComponent) {
        if (component.cabgForm.dirty) {
            const can = component.canDeactivate();
            return can;
        }
        return true;
    }
}