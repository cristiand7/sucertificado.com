import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from '../modelo/usuario';
import { Tarjeta } from '../modelo/tarjeta';
import { Utils } from '../share/utils';

@Injectable()
export class UsuarioService {
  private URL_LOGIN: string=Utils.URL_BACKEND+'/api/values/LoginUser';

  usuario:string;
  rol="";
  authenticated: boolean;
  constructor(
    private http: HttpClient
  ) {
   }

  // findAll(): Observable<Usuario[]>{
    //  return this.http.get<Usuario[]>('http://localhost:8080/usuario')
  // }
   findById(id:number){

  }
  findUser(){
      return this.http.get<Usuario>('http://localhost:8080/usuario/now',{ 
        headers: {
          'Content-Type': 'application/json'
      },
        withCredentials: true}
      , );
    
  }
   addUsuario(usuario: Usuario){
    return this.http.post
    ('http://localhost:8080/usuario/add',usuario,{ 
      headers: {
        'Content-Type': 'application/json'
    },
      withCredentials: true}
    , );
   }
   editUsuario(usuario: Usuario){
    //this.usuarios[usuario.idUsuario-1]=usuario;
   }
   deleteUsuario(usuario: Usuario){
    //this.usuarios.push(usuario);
   }
 
   
   authenticate(credentials, callback) {
    
    const headers = new HttpHeaders(credentials ? {
              authorization : 'Basic ' + btoa(credentials.username + ':' + credentials.password)
          } : {});
  
          this.http.get(this.URL_LOGIN+'?username='+credentials.username+'&password='+credentials.password).subscribe(response => {
              if (response['name']) {
                this.usuario=response['nombre']+'aquiui';
                this.authenticated = true;
                
              } else {
                  this.authenticated = false;
              }
              return callback && callback();
          },error=>{alert('Usuario o contraseña invalidos')});
  
      }

      getUser(){
        return this.usuario;
      }

    logout(){
      this.usuario="";
        this.authenticated = false;
        this.rol="";
        
      }
      addTarjeta(t:Tarjeta){
        return this.http.post
        ('http://localhost:8080/tarjeta/add',t,{ 
          headers: {
            'Content-Type': 'application/json'
        },
          withCredentials: true}
        , );
       }

}
