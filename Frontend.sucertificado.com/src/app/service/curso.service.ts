import { Injectable } from '@angular/core';
import { Curso } from '../modelo/curso';
import { Observable } from 'rxjs';
import { Utils } from '../share/utils';
import { HttpClient } from '@angular/common/http';
import { EstudianteCurso } from '../modelo/estudiante-curso';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  private URL_EXAMEN: string=Utils.URL_BACKEND+'/api/Courses/GetAllCouses';

 

  private URL_REGISTRO: string=Utils.URL_BACKEND+'/api/exam/AfiliateStudentToExam';

  private URL_PAGO: string=Utils.URL_BACKEND+'/api/exam/RealizarPago';



  carrito: Curso[]=[];

  constructor(private http: HttpClient) { }

  findAll(): Observable<Curso[]> {
    return this.http.get<Curso[]>(this.URL_EXAMEN);
  }

  registro(reg: EstudianteCurso){
  
    return this.http.post(this.URL_REGISTRO+'/'+reg.nombreusuario+'/'+reg.nombrecurso,reg);
  }
  pago(reg: EstudianteCurso){
  
    return this.http.post(this.URL_PAGO+'/'+reg.nombreusuario+'/'+reg.nombrecurso,reg);
  }

  add (curso: Curso){
    this.carrito.push(curso);
}

getCarrito (){
  return this.carrito;
}


}