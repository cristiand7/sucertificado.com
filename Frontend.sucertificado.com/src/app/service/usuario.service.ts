import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from '../modelo/usuario';
import { Tarjeta } from '../modelo/tarjeta';
import { Utils } from '../share/utils';


@Injectable()
export class UsuarioService {
  private URL_LOGIN: string = Utils.URL_BACKEND + '/api/login/authenticate';


  dataStr = new EventEmitter();
  usuario: string;
  token: string;
  rol = "";
  authenticated: boolean = false;
  constructor(
    private http: HttpClient
  ) {
  }

  // findAll(): Observable<Usuario[]>{
  //  return this.http.get<Usuario[]>('http://localhost:8080/usuario')
  // }
  findById(id: number) {

  }
  findUser() {
    return this.http.get<Usuario>('http://localhost:8080/usuario/now', {
      headers: {
        'Content-Type': 'application/json'
      },
      withCredentials: true
    }
      , );

  }
  addUsuario(usuario: Usuario) {
    return this.http.post
      ('http://localhost:8080/usuario/add', usuario, {
        headers: {
          'Content-Type': 'application/json'
        },
        withCredentials: true
      }
    , );
  }
  editUsuario(usuario: Usuario) {
    //this.usuarios[usuario.idUsuario-1]=usuario;
  }
  deleteUsuario(usuario: Usuario) {
    //this.usuarios.push(usuario);
  }


  authenticate(credentials) {
    
    return this.http.post(this.URL_LOGIN,credentials);
  }

  getUser() {
    return this.usuario;
  }

  setUser(usuario: string) {
    this.usuario = usuario;
    this.authenticated = true;
    this.dataStr.emit(this.usuario);
  }
  setToken(toke: string) {
    this.token=toke;
  }
  
  isAuthenticated(){
    return this.authenticated;
  }

  logout() {
    this.usuario = "";
    this.authenticated = false;
    this.rol = "";
  }

  addTarjeta(t: Tarjeta) {
    return this.http.post
      ('http://localhost:8080/tarjeta/add', t, {
        headers: {
          'Content-Type': 'application/json'
        },
        withCredentials: true
      }
        , );
  }

}
