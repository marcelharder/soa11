import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { CasesPerMonthModel } from '../_models/CasesPerMonthModel';
import { dropItem } from '../_models/dropItem';
import { GraphModel } from '../_models/GraphModel';
import { AccountService } from '../_services/account.service';
import { DropdownService } from '../_services/dropdown.service';
import { GraphService } from '../_services/graph.service';
import { UserService } from '../_services/user.service';

@Component({
    selector: 'app-statistics',
    templateUrl: './statistics.component.html',
    styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
    currentUserId = 0;
    hospitals: Array<dropItem> = [];
    selectedHospital = 0;
    AllButton = '0';
    showGraphNo = 0;
    vladModel: GraphModel = { dataXas: [], dataYas: [], caption: "" };
    cmModel: GraphModel = { dataXas: [], dataYas: [], caption: "" };
    ageModel: GraphModel = { dataXas: [], dataYas: [], caption: "" };
    perYearModel: GraphModel = { dataXas: [], dataYas: [], caption: "" };
    perMonthModel: GraphModel = { dataXas: [], dataYas: [], caption: "" };
    euroModel: GraphModel = { dataXas: [], dataYas: [], caption: "" };
    PMModel: CasesPerMonthModel;
    PYModel: GraphModel = { dataXas: [], dataYas: [], caption: "" };

    constructor(private drop: DropdownService,
        private userservice: UserService,
        private graph: GraphService,
        private auth: AccountService,
        private alertify: ToastrService) { }

    ngOnInit() {
        this.auth.currentUser$.pipe(take(1)).subscribe((u) => { this.currentUserId = u.userId; });

        this.drop.getHospitals(this.currentUserId).subscribe(response => {
            this.hospitals = response;
            this.hospitals.unshift({ value: 0, description: 'All hospitals' });
        }, (error) => { console.log(error); });

         this.userservice.getUser(this.currentUserId).subscribe((response)=>{
             this.selectedHospital = response.hospital_id;
             this.getAG();


         })

       
    }


    getVL() {
        this.vladModel = { dataXas: [], dataYas: [], caption: "" };
        this.graph.getVlad(this.currentUserId, this.selectedHospital).subscribe(
            (next) => {
                this.vladModel = next;this.showGraphNo = 1;
            });
    }
    getCM() {
        this.cmModel = { dataXas: [], dataYas: [], caption: "" };
        this.graph.getCM(this.currentUserId, this.selectedHospital).subscribe(
            (next) => {
              this.cmModel = next;this.showGraphNo = 2;
            });
    }
    getAG() {
        this.ageModel = { dataXas: [], dataYas: [], caption: "" };
        this.graph.getAge(this.currentUserId, this.selectedHospital).subscribe(
            (next) => {
                this.ageModel = next; this.showGraphNo = 3;
            });
    }
    getEU() {
        this.euroModel = { dataXas: [], dataYas: [], caption: "" };
        this.graph.getBand(this.currentUserId, this.selectedHospital).subscribe(
            (next) => {
                this.euroModel = next; this.showGraphNo = 4;
            });
    }
    getPY() {
        this.PYModel = { dataXas: [], dataYas: [], caption: "" };
        this.graph.getPY(this.currentUserId, this.selectedHospital).subscribe(
            (next) => {
                this.PYModel = next; this.showGraphNo = 5;
            });
    }
    getPM() {
        this.PMModel = { dataXas: [], dataYas: [], caption: "" };
        this.graph.getPM(this.currentUserId, this.selectedHospital).subscribe(
            (next) => {
                this.PMModel = next; this.showGraphNo = 6;
            });
    }
}

