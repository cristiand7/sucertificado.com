import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UsuarioService } from '../service/usuario.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  usuario: string;
  password: string;
  sub: Subscription;

  credentials = { username: '', password: '' };
  constructor(public service: UsuarioService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.service.authenticate(this.credentials)
      .subscribe(response => {

        console.log(response);
        this.service.setUser(this.credentials.username);
        this.service.setToken(response+'');
        this.router.navigate(['/catalogo'])

      }, error => {
        console.log(error);
        alert('Usuario o contraseña invalido');
      });

  }

  logout() {
    this.service.logout();
  }


}
