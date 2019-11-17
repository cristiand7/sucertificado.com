import { Component } from '@angular/core';
import { UsuarioService } from './service/usuario.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {


  title = 'SuCertificado';
  usuario: String;
  authenticated: boolean = false;

  constructor(private _eventEmiter: UsuarioService) { }

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
}
