import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CABG } from '../_models/CABG';
import { CABGService } from '../_services/cabg.service';
@Injectable()

export class PreviewCABGResolver implements Resolve<CABG> {
    constructor(private cabgservice: CABGService,
        private router: Router,
        private alertify: AlertifyService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<CABG> {
        return this.cabgservice.getCABGDescriptions(route.params['id']).pipe(catchError(error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['/home']);
            return of(null);
        }));
    }
}
