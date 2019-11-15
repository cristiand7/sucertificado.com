import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExamenFormComponent } from './examen/examen-form/examen-form.component';
import { ExamenService } from './service/examen.service';
import { HttpClientModule } from '@angular/common/http';
import { CatalogoComponent } from './catalogo/catalogo.component';
import { ComprasComponent } from './compras/compras.component';
import { MatButtonModule } from '@angular/material/button';

import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import { LoginComponent } from './login/login.component';
import { UsuarioService } from './service/usuario.service';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    ExamenFormComponent,
    CatalogoComponent,
    ComprasComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule  ,
    MatCardModule,
    MatGridListModule,
    MatButtonModule,
    FormsModule
    
  ],
  providers: [ExamenService, UsuarioService],  
  bootstrap: [AppComponent]
})
export class AppModule { }
