import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VistaComponent } from './vista/vista.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: '\home' },
  {
    path: 'home',component: VistaComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
