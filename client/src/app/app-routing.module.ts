import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { DetailsmainComponent } from './procedures/detailsmain/detailsmain.component';
import { EuroscoredetailsComponent } from './procedures/euroscoredetails/euroscoredetails.component';
import { ProceduredetailsComponent } from './procedures/proceduredetails/proceduredetails.component';
import { ProcedurelistComponent } from './procedures/procedurelist/procedurelist.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { UserlistComponent } from './userlist/userlist.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'errors', component: TestErrorsComponent},
  { path: 'users', component: UserlistComponent},
  { path: 'statistics', component: StatisticsComponent },
  { path: 'procedures', component: ProcedurelistComponent},
  { path: 'about', component: AboutComponent},
  { path: 'not-found', component: NotFoundComponent},
  { path: 'server-error', component: ServerErrorComponent},



  {
    path: 'procedureDetails',
    component: ProceduredetailsComponent,
    runGuardsAndResolvers: 'always',
    children: [
      {  path: 'detailsMain/:id', outlet: 'details', component: DetailsmainComponent  },
      {  path: 'euroscore/:id', outlet: 'details', component: EuroscoredetailsComponent  }

    ]
  },
 
  {path: '**', component: NotFoundComponent, pathMatch: 'full'}

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
