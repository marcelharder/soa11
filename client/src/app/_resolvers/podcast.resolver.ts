import { Injectable} from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PodCastService } from '../_services/podcast.service';
import { PodCast } from '../_models/PodCast';

@Injectable()

export class PodCastResolver implements Resolve<PodCast> {
    constructor(
        private router: Router,
        private podcast: PodCastService,
        private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<PodCast> {
        return this.podcast.getSpecificArticle(route.params['id']).pipe(catchError(error => {
            this.alertify.error('Problem retrieving your data');
            this.router.navigate(['/home']);
            return of(null);
        }));
    }
}