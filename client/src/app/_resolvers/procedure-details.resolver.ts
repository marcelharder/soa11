import {Injectable} from '@angular/core';
import { Procedure } from '../_models/Procedure';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ProcedureService } from '../_services/procedure.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ProcedureDetails } from '../_models/procedureDetails';

@Injectable()

export class ProcedureDetailsResolver implements Resolve<ProcedureDetails> {
    constructor(private procservice: ProcedureService,
        private router: Router,
        private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<ProcedureDetails> {
        return this.procservice.getProcedure(route.params['id']).pipe(catchError(error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['/home']);
            return of(null);
        }));
    }
}


