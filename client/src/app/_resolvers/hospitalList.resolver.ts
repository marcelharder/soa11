import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Hospital } from '../_models/Hospital';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HospitalService } from '../_services/hospital.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()

export class HospitalListResolver implements Resolve<Hospital[]> {
    constructor(
        private router: Router,
        private hos: HospitalService,
        private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<Hospital[]> {
        return this.hos.allHospitals().pipe(catchError(error => {
            this.alertify.error('Problem retrieving your data');
            this.router.navigate(['/home']);
            return of(null);
        }));
    }
}
