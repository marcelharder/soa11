import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PostOpService } from '../_services/postop.service';
import { PostOp } from '../_models/PostOp';
@Injectable()

export class PostResolver implements Resolve<PostOp> {
    constructor(private postopservice: PostOpService,
        private router: Router,
        private alertify: AlertifyService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<PostOp> {
        return this.postopservice.getPostOP(route.params['id']).pipe(catchError(error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['/home']);
            return of(null);
        }));
    }
}
