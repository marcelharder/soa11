import { NgModule } from '@angular/core';
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
    AddprocedureComponent,
    UserProfileComponent,
    WorkedInComponent,
    CareerComponent,
    PhotoEditorComponent,
    
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
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    ModalModule.forRoot()
  ],
  
  providers: [
   {provide: JWT_OPTIONS, useValue: JWT_OPTIONS},
   RefPhysService,
   UserService,
   JwtHelperService,
   ProcedureListResolver,
   ProfileResolver,
   {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
   {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
