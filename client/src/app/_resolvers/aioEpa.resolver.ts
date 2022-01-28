import {Injectable} from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Epa } from '../_models/Epa';
import { EpaService } from '../_services/epa.service';

@Injectable()

export class AioEpaResolver implements Resolve<Epa[]> {
    pageNumber = 1;
    pageSize = 12;
    
    constructor(private epaservice: EpaService,
        private router: Router,
        private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<Epa[]> {
         return this.epaservice.getEpas(route.params.id).pipe(catchError(error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['/home']);
            return of(null);
        }));







    }
}

