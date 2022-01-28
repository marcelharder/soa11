import {Injectable} from '@angular/core';
import { User } from '../_models/User';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';
import { Course } from '../_models/Course';
import { CourseService } from '../_services/course.service';

@Injectable()

export class AioCourseResolver implements Resolve<Course[]> {
    pageNumber = 1;
    pageSize = 12;
    
    constructor(private cservice: CourseService,
        private router: Router,
        private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<Course[]> {
         return this.cservice.getCourses(route.params.id).pipe(catchError(error => {
            this.alertify.error('Problem retrieving data');
            this.router.navigate(['/home']);
            return of(null);
        }));







    }
}

