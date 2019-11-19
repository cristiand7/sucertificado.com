import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExamenFormComponent } from './examen/examen-form/examen-form.component';
import { CatalogoComponent } from './catalogo/catalogo.component';
import { LoginComponent } from './login/login.component';
import { PerfilComponent } from './perfil/perfil.component';


const routes: Routes = [
  { path: 'examen', component: ExamenFormComponent },
  { path: 'catalogo', component: CatalogoComponent },
  { path: 'login', component: LoginComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: '', pathMatch: 'full', redirectTo: 'catalogo' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
