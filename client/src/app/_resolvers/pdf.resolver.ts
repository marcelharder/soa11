import { Injectable} from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PdfService } from '../_services/pdf.service';
import { PodCast } from '../_models/PodCast';

@Injectable()

export class PDFResolver implements Resolve<PodCast> {
    constructor(
        private router: Router,
        private pdfService: PdfService,
        private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<PodCast> {
        return this.pdfService.getSpecificArticle(route.params['id']).pipe(catchError(error => {
            this.alertify.error('Problem retrieving your data');
            this.router.navigate(['/home']);
            return of(null);
        }));
    }
}
