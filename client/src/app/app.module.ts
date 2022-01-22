import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';

import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { ProceduredetailsComponent } from './procedures/proceduredetails/proceduredetails.component';
import { DetailsmainComponent } from './procedures/detailsmain/detailsmain.component';
import { EuroscoredetailsComponent } from './procedures/euroscoredetails/euroscoredetails.component'
import { ToastrModule } from 'ngx-toastr';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ProcedurelistComponent } from './procedures/procedurelist/procedurelist.component';
import { StatisticsComponent } from './procedures/statistics/statistics.component';
import { UserlistComponent } from './procedures/userlist/userlist.component';
import { AboutComponent } from './procedures/about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    ProceduredetailsComponent,
    DetailsmainComponent,
    EuroscoredetailsComponent,
    TestErrorsComponent,
    ProcedurelistComponent,
    StatisticsComponent,
    UserlistComponent,
    AboutComponent,
    
  ],
  imports: [
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
   
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
