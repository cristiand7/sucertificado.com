import { Component } from '@angular/core';
import { UsuarioService } from './service/usuario.service';
import { MatDialogRef, MatDialog } from '@angular/material';
import { CarritoComponent } from './carrito/carrito.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {


  title = 'SuCertificado';
  usuario: String;
  authenticated: boolean = false;
  dialogRef: MatDialogRef<CarritoComponent>;


  constructor(private _eventEmiter: UsuarioService, public dialog: MatDialog) { }

  ngOnInit() {
    this.userLogged();
  }


  userLogged() {

    this._eventEmiter.dataStr.subscribe(data => {
      this.usuario = data;
      this.authenticated=true;
    });
  }

  logout() {
    this.usuario = "";
    this.authenticated = false;
    this._eventEmiter.logout();
  }

  verCarrito(){
    this.dialogRef = this.dialog.open(CarritoComponent);
  }
}
