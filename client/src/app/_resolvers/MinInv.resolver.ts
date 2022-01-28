import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MinInv } from '../_models/MinInv';
import { MinInvService } from '../_services/mininv.service';

@Injectable()

export class MinInvResolver implements Resolve<MinInv> {
    constructor(
        private router: Router,
        private min: MinInvService,
        private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<MinInv> {
        return this.min.getSpecificMinInv(route.params['id']).pipe(catchError(error => {
            this.alertify.error('Problem retrieving your data');
            this.router.navigate(['/home']);
            return of(null);
        }));
    }
}
