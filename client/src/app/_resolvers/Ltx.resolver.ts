import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { Ltx } from '../_models/Ltx';
import { LtxService } from '../_services/ltx.service';

@Injectable()

export class LtxResolver implements Resolve<Ltx> {
    constructor(
        private router: Router,
        private ltx: LtxService,
        private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<Ltx> {
        return this.ltx.getLTX(route.params.id).pipe(catchError(error => {
            this.alertify.error('Problem retrieving your data');
            this.router.navigate(['/home']);
            return of(null);
        }));
    }
}
