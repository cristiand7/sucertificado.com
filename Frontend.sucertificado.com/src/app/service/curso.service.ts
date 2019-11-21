import { Injectable } from '@angular/core';
import { Curso } from '../modelo/curso';
import { Observable } from 'rxjs';
import { Utils } from '../share/utils';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EstudianteCurso } from '../modelo/estudiante-curso';
import { UsuarioService } from './usuario.service';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  private URL_EXAMEN: string=Utils.URL_BACKEND+'/api/Courses/GetAllCouses';

 

  private URL_REGISTRO: string=Utils.URL_BACKEND+'/api/exam/AfiliateStudentToExam';

  private URL_PAGO: string=Utils.URL_BACKEND+'/api/exam/RealizarPago';

  private token:string;
  carrito: Curso[]=[];

  constructor(private http: HttpClient,public service: UsuarioService) {
   
   }

  findAll(): Observable<Curso[]> {
    return this.http.get<Curso[]>(this.URL_EXAMEN);
  }

  

  registro(reg: EstudianteCurso){
     this.token=this.service.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': 'Bearer '+this.token
      })};
    return this.http.post(this.URL_REGISTRO+'/'+reg.nombreusuario+'/'+reg.nombrecurso,reg,httpOptions);
  }
  pago(reg: EstudianteCurso){
    this.token=this.service.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': 'Bearer '+this.token
      })};
    
    return this.http.post(this.URL_PAGO+'/'+reg.nombreusuario+'/'+reg.nombrecurso,reg,httpOptions);
  }

  add (curso: Curso){
    this.carrito.push(curso);
}

getCarrito (){
  return this.carrito;
}

cleanCarrito (){
  this.carrito=[];
}



}