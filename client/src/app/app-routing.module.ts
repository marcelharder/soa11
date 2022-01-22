import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './procedures/about/about.component';
import { DetailsmainComponent } from './procedures/detailsmain/detailsmain.component';
import { EuroscoredetailsComponent } from './procedures/euroscoredetails/euroscoredetails.component';
import { ProceduredetailsComponent } from './procedures/proceduredetails/proceduredetails.component';
import { ProcedurelistComponent } from './procedures/procedurelist/procedurelist.component';
import { StatisticsComponent } from './procedures/statistics/statistics.component';
import { UserlistComponent } from './procedures/userlist/userlist.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'errors', component: TestErrorsComponent},
  { path: 'users', component: UserlistComponent},
  { path: 'statistics', component: StatisticsComponent },
  { path: 'procedures', component: ProcedurelistComponent},
  { path: 'about', component: AboutComponent},



  {
    path: 'procedureDetails',
    component: ProceduredetailsComponent,
    runGuardsAndResolvers: 'always',
    children: [
      {  path: 'detailsMain/:id', outlet: 'details', component: DetailsmainComponent  },
      {  path: 'euroscore/:id', outlet: 'details', component: EuroscoredetailsComponent  }

    ]
  },
 
  {path: '**', component: HomeComponent, pathMatch: 'full'}

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
