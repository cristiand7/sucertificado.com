import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../service/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  usuario: string;
  password: string;
  credentials = {username: '', password: ''};
  constructor(public service: UsuarioService) { }

  ngOnInit() {
  }

  login() {
    this.service.authenticate(this.credentials, () => {
      alert("autenticado")
        
  });
  }

  logout() {
    this.service.logout();
  }


}
