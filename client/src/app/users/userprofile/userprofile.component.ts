import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../_models/User';
import { UserService } from '../../_services/user.service';
import { environment } from '../../../environments/environment';
import { DropdownService } from '../../_services/dropdown.service';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';
import { countryItem } from 'src/app/_models/countryItem';
import { take } from 'rxjs/operators';
import * as moment from 'moment';


@Component({
    templateUrl: './userprofile.component.html',
    styleUrls: ['./userprofile.component.css']
})

export class UserProfileComponent implements OnInit {
    @ViewChild('editForm') editForm: NgForm;
    user: User;
    model: any = {};
    currentUserId = 0;
    currentUserName = '';
    baseUrl = environment.apiUrl;
    countryDescription = '';
    optionCountries: Array<countryItem> = [];
    countryWhereUserLives = '';
    password_01 = '';
    password_02 = '';
    password_03 = '';
    CompliancePanel = 0;
    premium = 0;

    @HostListener('window:beforeunload', ['$event'])
    unloadNotification($event: any) { if (this.editForm.dirty) { $event.returnValue = true; } }

    constructor(private route: ActivatedRoute,
        private router: Router,
        private drops: DropdownService,
        private alertify: ToastrService,
        private userService: UserService,
        private auth: AccountService) { }

    ngOnInit() {

        this.loadDrops();

        this.auth.currentUser$.pipe(take(1)).subscribe((u) => {
            this.currentUserName = u.Username;
            this.currentUserId = u.UserId;
        });

        this.route.data.subscribe((data: { user: User }) => {
            this.user = data.user;
            // focus on the correct drops
            this.changeCountry();// let the country name follow the change in country
            const currentDate = new Date();
            debugger;
            if (moment(currentDate).isBefore(this.user.paidTill)) {  // find out if this is a premium client
                debugger;
                this.premium = 1; } else {
                    debugger;
                    this.premium = 0;}

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
    updateUser() {
        this.userService.updateUser(this.currentUserId, this.user).subscribe(next => {
            this.editForm.reset(this.user);
            this.router.navigate(['/procedures']);
        }, error => { this.alertify.error(error); });

    }

    changeCountry() {
        let help = this.optionCountries.find(z => z.value === this.user.country);
        this.countryWhereUserLives = help.description;
    }

    updateFromWorkedIn(us: User) {
        this.userService.updateUser(this.currentUserId, us).subscribe(next => {
            this.router.navigate(['/procedures']);
        },
            error => { this.alertify.error(error); });
    }

    requestPremium() {this.router.navigate(['/premium']); }

    showPremium() {if (this.premium === 1) { return true } else { return false }}

    changePasswordNow() {
        this.CompliancePanel = 0;
        if (this.password_01 !== '') {
            if (this.meetsComplexity(this.password_01)) {
                if (this.password_02 !== this.password_03) {
                    this.alertify.show('New password does not match !!');
                }
                else {
                    if (this.meetsComplexity(this.password_02)) {
                        this.model.UserName = this.currentUserName;
                        this.model.password = this.password_01;
                        this.auth.changePassword(this.model, this.password_02).subscribe((next) => {
                            // redirect to main page
                            this.router.navigate(['/procedures']);
                        }, error => this.alertify.error(error));
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

    cancel() { this.router.navigate(['/procedures']); }


    meetsComplexity(te: string) {
        let h = true;
        let regexp = new RegExp("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$");
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

