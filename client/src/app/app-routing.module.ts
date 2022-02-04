import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { DetailsmainComponent } from './procedures/detailsmain/detailsmain.component';
import { EuroscoredetailsComponent } from './procedures/euroscoredetails/euroscoredetails.component';
import { ProceduredetailsComponent } from './procedures/proceduredetails/proceduredetails.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { UserlistComponent } from './users/userlist/userlist.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { ConfigurationComponent } from './configuration/configuration.component';
import { ProcedureMainComponent } from './procedures/procedurelist/procedure-main.component';
import { ProcedureListResolver } from './_resolvers/procedure-list.resolver';
import { AuthGuard } from './_guards/auth.guard';
import { AddprocedureComponent } from './procedures/addprocedure/addprocedure.component';
import { UserProfileComponent } from './users/userprofile/userprofile.component';
import { ProfileResolver } from './_resolvers/profile.resolver';
import { ChangesProcedureDetails } from './_guards/changes-procedureDetails.guard';
import { changesAorticDetails } from './_guards/changes-aorticDetails.guard';
import { changesCABGDetails } from './_guards/changes-cabgDetails.guard';
import { changesCPBDetails } from './_guards/changes-cpbDetails.guard';
import { changesEuroscoreDetails } from './_guards/changes-euroscoreDetails.guard';
import { changesLtxDetails } from './_guards/changes-ltxDetails.guard';
import { changesMinInv } from './_guards/changes-minInvDetails.guard';
import { changesPOSTOPDetails } from './_guards/changes-postopDetails.guard';
import { changesPreViewReport } from './_guards/changes-previewReport.guard';
import { changesValveDetails } from './_guards/changes-valveDetails.guard';
import { changesValveRepairDetails } from './_guards/changes-valveRepair.guard';
import { AorticSurgeryResolver } from './_resolvers/aorticSurgery.resolver';
import { CabgResolver } from './_resolvers/CABG-details.resolver';
import { CPBDetailsResolver } from './_resolvers/CPB-details.resolver';
import { EuroScoreDetailsResolver } from './_resolvers/euroScoreDetails.resolver';
import { LtxResolver } from './_resolvers/Ltx.resolver';
import { MinInvResolver } from './_resolvers/MinInv.resolver';
import { PostResolver } from './_resolvers/PostOp-details.resolver';
import { PreviewReportResolver } from './_resolvers/PreviewReport.resolver';
import { ProcedureDetailsResolver } from './_resolvers/procedure-details.resolver';
import { ValveResolver } from './_resolvers/Valve.resolver';
import { ValveRepairResolver } from './_resolvers/ValveRepair.resolver';
import { CpbComponent } from './procedures/cpb/cpb.component';
import { CabgComponent } from './procedures/cabg/cabg.component';
import { LtxComponent } from './procedures/ltx/ltx.component';
import { AorticComponent } from './procedures/aortic/aortic.component';
import { ValveComponent } from './procedures/valve/valve.component';
import { MininvComponent } from './procedures/mininv/mininv.component';
import { ValverepairComponent } from './procedures/valverepair/valverepair.component';
import { PostopComponent } from './procedures/postop/postop.component';
import { PreviewreportComponent } from './procedures/previewreport/previewreport.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'errors', component: TestErrorsComponent },
  { path: 'about', component: AboutComponent },
  {
    path: 'procedureDetails',component: ProceduredetailsComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'detailsMain/:id', outlet: 'details', component: DetailsmainComponent, resolve: { procedureDetails: ProcedureDetailsResolver },canDeactivate: [ChangesProcedureDetails] },
      {path: 'euroscore/:id', outlet: 'details', component: EuroscoredetailsComponent,resolve: { patient: EuroScoreDetailsResolver },canDeactivate: [changesEuroscoreDetails] },
      {path: 'cpb/:id', outlet: 'details', component: CpbComponent,resolve: { cpb: CPBDetailsResolver },canDeactivate: [changesCPBDetails]},
      {path: 'cabg/:id', outlet: 'details', component: CabgComponent,resolve: { cabg: CabgResolver },canDeactivate: [changesCABGDetails]},
      {path: 'ltx/:id', outlet: 'details', component: LtxComponent,resolve: { ltx: LtxResolver },canDeactivate: [changesLtxDetails]},
      {path: 'aortic/:id', outlet: 'details', component: AorticComponent,resolve: { aortic: AorticSurgeryResolver }, canDeactivate: [changesAorticDetails]},
      {path: 'valve/:id', outlet: 'details', component: ValveComponent,resolve: { valve: ValveResolver },canDeactivate: [changesValveDetails]},
      {path: 'valverepair/:id', outlet: 'details', component: ValverepairComponent,resolve: { valve: ValveRepairResolver },canDeactivate: [changesValveRepairDetails]},
      {path: 'postop/:id', outlet: 'details', component: PostopComponent,resolve: { postop: PostResolver },canDeactivate: [changesPOSTOPDetails]},
      {path: 'mininv/:id', outlet: 'details', component: MininvComponent,resolve: { min: MinInvResolver },canDeactivate: [changesMinInv]},
      {path: 'previewReport/:id', outlet: 'details', component: PreviewreportComponent,resolve: { preView: PreviewReportResolver },canDeactivate: [changesPreViewReport]},
    ]
  },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children:[{ path: 'users', component: UserlistComponent },
    { path: 'profile', component: UserProfileComponent, resolve: { user: ProfileResolver } },
    { path: 'statistics', component: StatisticsComponent },
    { path: 'procedures', component: ProcedureMainComponent, resolve: { procedure: ProcedureListResolver } },
    { path: 'addProcedure', component: AddprocedureComponent},
    { path: 'about', component: AboutComponent },
    { path: 'config', component: ConfigurationComponent },
    { path: 'not-found', component: NotFoundComponent },
    { path: 'server-error', component: ServerErrorComponent },]
  },
  
 

  { path: '**', component: NotFoundComponent, pathMatch: 'full' }

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
