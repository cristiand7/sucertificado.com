import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExamenFormComponent } from './examen/examen-form/examen-form.component';


const routes: Routes = [
  { path: 'examen', component: ExamenFormComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
