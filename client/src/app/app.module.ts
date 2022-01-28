import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';

import { BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { PaginationModule} from 'ngx-bootstrap/pagination';
import { HomeComponent } from './home/home.component';
import { ProceduredetailsComponent } from './procedures/proceduredetails/proceduredetails.component';
import { DetailsmainComponent } from './procedures/detailsmain/detailsmain.component';
import { EuroscoredetailsComponent } from './procedures/euroscoredetails/euroscoredetails.component'
import { ToastrModule } from 'ngx-toastr';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { UserlistComponent } from './userlist/userlist.component';
import { AboutComponent } from './about/about.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { ConfigurationComponent } from './_config/configuration/configuration.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { ProcedureMainComponent } from './procedures/procedurelist/procedure-main.component';
import { ProcedureListResolver } from './_resolvers/procedure-list.resolver';

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
    
  ],
  imports: [
    PaginationModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [
    ProcedureListResolver,
   {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
   {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
