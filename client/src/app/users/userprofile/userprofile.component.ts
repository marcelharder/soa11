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


@Component({
    templateUrl: './userprofile.component.html',
    styleUrls: ['./userprofile.component.css']
})

export class UserProfileComponent implements OnInit {
    @ViewChild('editForm') editForm: NgForm;
    user: User;
    baseUrl = environment.apiUrl;
    countryDescription = '';
    optionCountries: Array<dropItem> = [];
    countryWhereUserLives = '';

    @HostListener('window:beforeunload', ['$event'])
    unloadNotification($event: any) { if (this.editForm.dirty) { $event.returnValue = true; } }

    constructor(private route: ActivatedRoute,
        private router: Router,
        private drops: DropdownService,
        private alertify: ToastrService,
        private userService: UserService,
        private auth: AccountService) { }

    ngOnInit() {
        this.route.data.subscribe((data: {user: User}) => {
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

    updatePhoto(photoUrl: string) { this.user.photoUrl = photoUrl;}

    updatePassword(){}

    updateUser() {
        this.userService.updateUser(this.user.UserId, this.user).subscribe(next => {
            this.alertify.show('profile updated');
            this.editForm.reset(this.user);
        }, error => { this.alertify.error(error); });

    }

    changeCountry() {
        const help = this.optionCountries.find(z => z.value === +this.user.country);
         this.countryWhereUserLives = help.description;
    }

    updateFromWorkedIn(us: User) {
        this.userService.updateUser(this.user.UserId, us).subscribe(next => {
            // go to the procedures page
            this.router.navigate(['/procedures']);
        },
            error => { this.alertify.error(error); });
    }

    cancel(){}

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

