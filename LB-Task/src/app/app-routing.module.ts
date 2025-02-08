import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClinicComponent } from './pages/clinic/clinic/clinic.component';

const routes: Routes = [
  { path: '', redirectTo: '/clinics', pathMatch: 'full' }, 
  { path: 'clinics', component: ClinicComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
