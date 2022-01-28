import {Injectable} from '@angular/core';
import { User } from '../_models/User';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';
import { Procedure } from '../_models/Procedure';
import { ProcedureService } from '../_services/procedure.service';

@Injectable()

export class AioProcedureResolver implements Resolve<Procedure[]> {
    pageNumber = 1;
    pageSize = 12;
    
    constructor(private pservice: ProcedureService,
        private router: Router,
        private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<Procedure[]> {
         return this.pservice.getAioProcedures(route.params.id, this.pageNumber, this.pageSize).pipe(catchError(error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['/home']);
            return of(null);
        }));







    }
}

