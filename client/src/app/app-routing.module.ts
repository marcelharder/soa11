import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DetailsmainComponent } from './procedures/detailsmain/detailsmain.component';
import { EuroscoredetailsComponent } from './procedures/euroscoredetails/euroscoredetails.component';
import { ProceduredetailsComponent } from './procedures/proceduredetails/proceduredetails.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'procedureDetails',
    component: ProceduredetailsComponent,
    runGuardsAndResolvers: 'always',
    children: [
      {
        path: 'detailsMain/:id', outlet: 'details', component: DetailsmainComponent
      },
      {
        path: 'euroscore/:id', outlet: 'details', component: EuroscoredetailsComponent
      }

    ]}]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
