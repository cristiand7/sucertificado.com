import { Injectable } from '@angular/core';
import { Curso } from '../modelo/curso';
import { Observable } from 'rxjs';
import { Utils } from '../share/utils';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  private URL_EXAMEN: string=Utils.URL_BACKEND+'/api/values/GetAllCouses';

  constructor(private http: HttpClient) { }

  findAll(): Observable<Curso[]> {
    return this.http.get<Curso[]>(this.URL_EXAMEN);
  }
}