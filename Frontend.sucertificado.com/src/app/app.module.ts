import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExamenFormComponent } from './examen/examen-form/examen-form.component';
import { ExamenService } from './service/examen.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ExamenFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule    
  ],
  providers: [ExamenService],
  bootstrap: [AppComponent]
})
export class AppModule { }
