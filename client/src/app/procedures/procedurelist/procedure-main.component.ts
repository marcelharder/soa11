import { Component, OnInit } from '@angular/core';
import { ProcedureService } from 'src/app/_services/procedure.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PaginatedResult, Pagination } from 'src/app/_models/pagination';
import { Procedure } from 'src/app/_models/Procedure';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';
import { HospitalService } from 'src/app/_services/hospital.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/_services/user.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-procedure-main',
  templateUrl: './procedure-main.component.html',
  styleUrls: ['./procedure-main.component.css']
})
export class ProcedureMainComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  currentUserId = 0;
  user: User;
  primarySurgeon = true;
  

  procedures: Array<Procedure> = [];
  pagination: Pagination;
  selectedHospital = '';

  constructor(
    
    private procedureService: ProcedureService,
    private userService: UserService,
    private alertify: ToastrService,
    private auth: AccountService,
    private hos: HospitalService,
    private router:Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {

    // find out if this surgeon has a LTK

    //this.auth.currentLTK.subscribe((next)=>{this.primarySurgeon = next});
    
    
    // get all the procedures for this user filtered per current hospital, which is done on the server
    this.route.data.subscribe(data => {
        this.procedures = data.procedure.result;
        this.pagination = data.procedure.pagination;
    });
    this.auth.currentUser$.subscribe((response)=>{
      let decodedToken = this.jwtHelper.decodeToken(response.token);
      console.log("The id of the current loggedin user: " + decodedToken.nameid);
      this.userService.getUserFromId(+decodedToken.nameid).subscribe((next)=>{
         console.log("The hospitalId of the loggedin user: " + next.hospital_id);
         this.hos.getHospitalNameFromId(next.hospital_id).subscribe((d)=>{this.selectedHospital = d});
      })




    });
   /*  this.hos.getHospitalNameFromId(u.hospital_id).subscribe((next)=>{
      this.selectedHospital = next
     }) */
      
       
       
  }

  pageChanged(event: any): void { this.pagination.currentPage = event.page; this.loadProcedures(); }

  loadProcedures() {
    this.procedureService.getProcedures(this.pagination.currentPage, this.pagination.itemsPerPage ).subscribe(
        (res: PaginatedResult<Procedure[]>) => {
          this.procedures = res.result;
          this.pagination = res.pagination;
        },
        error => {
          console.log('here is my error' + error);
        }
      );
    }
    loadAssistedProcedures() {
      this.procedureService.getAssistedProcedures(this.pagination.currentPage, this.pagination.itemsPerPage ).subscribe(
          (res: PaginatedResult<Procedure[]>) => {
            this.procedures = res.result;
            this.pagination = res.pagination;
          },
          error => {
            console.log('here is my error' + error);
          }
        );
      }

  addProcedure() {
     this.router.navigate(['/addProcedure']);
  }
   
  isCompleted(pd: string) { if (pd === 'Yes') { return true; } }
  isEligible(pd: string) { if (pd !== 'N/A') { return true; } }
 
  testNav(pro: Procedure){
    this.auth.setCurrentProcedure(pro);
    this.router.navigate(['/procedureDetails']);
  }

  changeSurgeonType(){
    if(!this.primarySurgeon){ this.loadProcedures();}
    else { this.loadAssistedProcedures(); }

  }



}
