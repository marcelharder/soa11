import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../_models/User';
import { UserService } from '../../_services/user.service';
import { environment } from '../../../environments/environment';
import { DropdownService } from '../../_services/dropdown.service';
import { dropItem } from '../../_models/dropItem';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';
import { countryItem } from 'src/app/_models/countryItem';
import { take } from 'rxjs/operators';


@Component({
    templateUrl: './userprofile.component.html',
    styleUrls: ['./userprofile.component.css']
})

export class UserProfileComponent implements OnInit {
    @ViewChild('editForm') editForm: NgForm;
    user: User;
    currentUserId = 0;
    baseUrl = environment.apiUrl;
    countryDescription = '';
    optionCountries: Array<countryItem> = [];
    countryWhereUserLives = '';
    password_01 = '';
    password_02 = '';
    password_03 = '';
    CompliancePanel = 0;

    @HostListener('window:beforeunload', ['$event'])
    unloadNotification($event: any) { if (this.editForm.dirty) { $event.returnValue = true; } }

    constructor(private route: ActivatedRoute,
        private router: Router,
        private drops: DropdownService,
        private alertify: ToastrService,
        private userService: UserService,
        private auth: AccountService) { }

    ngOnInit() {

        this.auth.currentUser$.pipe(take(1)).subscribe((u) => { this.currentUserId = u.UserId; });

        this.route.data.subscribe((data: { user: User }) => {
            this.user = data.user;
            this.loadDrops();
            // focus on the correct drops
            this.changeCountry();// let the country name follow the change in country

        });

    }

    loadDrops() {
        const d = JSON.parse(localStorage.getItem('optionCountries'));
        if (d == null || d.length === 0) {
            this.drops.getAllCountries().subscribe((response) => {
                this.optionCountries = response; localStorage.setItem('optionCountries', JSON.stringify(response));
            });
        } else {
            this.optionCountries = JSON.parse(localStorage.getItem('optionCountries'));
        }


    }

    showCompliancePanel() { if (this.CompliancePanel === 1) { return true; } }

    updatePhoto(photoUrl: string) { this.user.PhotoUrl = photoUrl; }

    updatePassword() { }

    updateUser() {
        this.userService.updateUser(this.currentUserId, this.user).subscribe(next => {
            this.alertify.show('profile updated');
            this.editForm.reset(this.user);
        }, error => { this.alertify.error(error); });

    }

    changeCountry() {
        let help = this.optionCountries.find(z => z.value === this.user.country);
        this.countryWhereUserLives = help.description;
    }

    updateFromWorkedIn(us: User) {

        this.userService.updateUser(this.user.UserId, us).subscribe(next => {
            // go to the procedures page
            this.router.navigate(['/procedures']);
        },
            error => { this.alertify.error(error); });
    }



    changePasswordNow() {
        this.CompliancePanel = 0;
        if (this.password_01 !== '') {
            if (this.meetsComplexity(this.password_01)) {
                if (this.password_02 !== this.password_03) {
                    this.alertify.show('New password does not match !!');
                }
                else {
                    if (this.meetsComplexity(this.password_02)) {
                        this.alertify.show('New password is good!!');
                        /* this.auth.changePassword(this.user, this.password_02).subscribe((next)=>{
                            this.alertify.show('Password changed');
                        }, error => this.alertify.error(error)); */
                    } else {
                        this.password_02 = '';
                        this.password_03 = '';
                        this.alertify.error('New password is not compliant');
                        this.CompliancePanel = 1;
                    }
                }
            } else {
                this.alertify.error('Please enter the current password ...');
            }
        } else {
            this.password_01 = '';
            this.alertify.error('Password is not correct ...');
        }
    }

    cancel() { }



    meetsComplexity(te: string) {
        let h = true;
        let regexp = new RegExp('^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$');
        h = regexp.test(te);
        return h;
    }

    canDeactivate() {
        this.updateUser();
        return true;
        // if (confirm("Are you sure you want to navigate away ?")) {
        //    return true;
        // } else {
        //    return false;
        // }
    }


}

