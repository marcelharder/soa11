import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';

import { BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { PaginationModule} from 'ngx-bootstrap/pagination';
import { BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import { UiSwitchModule } from 'ngx-ui-switch';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FileUploadModule } from 'ng2-file-upload';

import { HomeComponent } from './home/home.component';
import { ProceduredetailsComponent } from './procedures/proceduredetails/proceduredetails.component';
import { DetailsmainComponent } from './procedures/detailsmain/detailsmain.component';
import { EuroscoredetailsComponent } from './procedures/euroscoredetails/euroscoredetails.component'
import { ToastrModule } from 'ngx-toastr';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { UserlistComponent } from './users/userlist/userlist.component';
import { AboutComponent } from './about/about.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { ProcedureMainComponent } from './procedures/procedurelist/procedure-main.component';
import { ProcedureListResolver } from './_resolvers/procedure-list.resolver';
import { ConfigurationComponent } from './configuration/configuration.component';
import { AddEuroScoreDetailsComponent } from './procedures/addprocedure/add-euro-score-details/add-euro-score-details.component';
import { AddprocedureComponent } from './procedures/addprocedure/addprocedure.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { UserProfileComponent } from './users/userprofile/userprofile.component';
import { WorkedInComponent } from './users/userprofile/worked-in/worked-in.component';
import { CareerComponent } from './users/userprofile/career/career.component';
import { PhotoEditorComponent } from './photo-editor/photo-editor.component';
import { ProfileResolver } from './_resolvers/profile.resolver';
import { UserService } from './_services/user.service';
import { RefPhysService } from './_services/refPhys.service';
import { SelectProcedureTypeComponent } from './procedures/addprocedure/select-procedure-type/select-procedure-type.component';
import { CpbComponent } from './procedures/cpb/cpb.component';
import { CabgComponent } from './procedures/cabg/cabg.component';
import { LtxComponent } from './procedures/ltx/ltx.component';
import { AorticComponent } from './procedures/aortic/aortic.component';
import { ValveComponent } from './procedures/valve/valve.component';
import { ValverepairComponent } from './procedures/valverepair/valverepair.component';
import { PostopComponent } from './procedures/postop/postop.component';
import { MininvComponent } from './procedures/mininv/mininv.component';
import { PreviewreportComponent } from './procedures/previewreport/previewreport.component';
import { ExistingconduitComponent } from './procedures/aortic/existingconduit/existingconduit.component';
import { GamecardComponent } from './procedures/aortic/gamecard/gamecard.component';
import { Blok1Component } from './procedures/previewreport/blok1/blok1.component';
import { Blok2Component } from './procedures/previewreport/blok2/blok2.component';
import { Blok3Component } from './procedures/previewreport/blok3/blok3.component';
import { Blok6Component } from './procedures/previewreport/blok6/blok6.component';
import { BlokcabgComponent } from './procedures/previewreport/blokcabg/blokcabg.component';
import { BlokvalveComponent } from './procedures/previewreport/blokvalve/blokvalve.component';
import { EmailRefPhysComponent } from './procedures/previewreport/email-ref-phys/email-ref-phys.component';
import { ReportHeaderComponent } from './procedures/previewreport/report-header/report-header.component';
import { ValverepairdetailsComponent } from './procedures/valverepair/valverepairdetails/valverepairdetails.component';
import { ValverepairoviComponent } from './procedures/valverepair/valverepairovi/valverepairovi.component';
import { AgeComponent } from './statistics/age/age.component';
import { CasemixComponent } from './statistics/casemix/casemix.component';
import { FiveriskbandsComponent } from './statistics/fiveriskbands/fiveriskbands.component';
import { PermonthComponent } from './statistics/permonth/permonth.component';
import { PeryearComponent } from './statistics/peryear/peryear.component';
import { VladComponent } from './statistics/vlad/vlad.component';
import { EmployeesComponent } from './configuration/employees/employees.component';
import { HospitalsComponent } from './configuration/hospitals/hospitals.component';
import { OpreportComponent } from './configuration/opreport/opreport.component';
import { RefphysComponent } from './configuration/refphys/refphys.component';
import { EditComponent } from './configuration/employees/edit/edit.component';
import { EditdetailsComponent } from './configuration/employees/editdetails/editdetails.component';
import { UploadphotoComponent } from './configuration/employees/uploadphoto/uploadphoto.component';
import { GoogleChartsModule } from 'angular-google-charts';
import { ValvedetailsComponent } from './procedures/valve/valvedetails/valvedetails.component';
import { ValvesinoviComponent } from './procedures/valve/valvesinovi/valvesinovi.component';
import { GraphService } from './_services/graph.service';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    ProceduredetailsComponent,
    DetailsmainComponent,
    EuroscoredetailsComponent,
    TestErrorsComponent,
    ProcedureMainComponent,
    StatisticsComponent,
    UserlistComponent,
    AboutComponent,
    NotFoundComponent,
    ServerErrorComponent,
    ConfigurationComponent,
    AddEuroScoreDetailsComponent,
    SelectProcedureTypeComponent,
    AddprocedureComponent,
    UserProfileComponent,
    WorkedInComponent,
    CareerComponent,
    PhotoEditorComponent,
    CpbComponent,
    CabgComponent,
    LtxComponent,
    AorticComponent,
    ValveComponent,
    ValverepairComponent,
    PostopComponent,
    MininvComponent,
    PreviewreportComponent,
    ExistingconduitComponent,
    GamecardComponent,
    Blok1Component,
    Blok2Component,
    Blok3Component,
    Blok6Component,
    BlokcabgComponent,
    BlokvalveComponent,
    EmailRefPhysComponent,
    ReportHeaderComponent,
    ValverepairdetailsComponent,
    ValverepairoviComponent,
    AgeComponent,
    CasemixComponent,
    FiveriskbandsComponent,
    PermonthComponent,
    PeryearComponent,
    VladComponent,
    EmployeesComponent,
    HospitalsComponent,
    OpreportComponent,
    RefphysComponent,
    EditComponent,
    EditdetailsComponent,
    UploadphotoComponent,
    ValvedetailsComponent,
    ValvesinoviComponent,
    
  ],
  imports: [
    FileUploadModule,
    TabsModule.forRoot(),
    UiSwitchModule,
    PaginationModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    ModalModule.forRoot(),
    GoogleChartsModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [
   {provide: JWT_OPTIONS, useValue: JWT_OPTIONS},
   RefPhysService,
   UserService,
   GraphService,
   JwtHelperService,
   ProcedureListResolver,
   ProfileResolver,
   {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
   {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
