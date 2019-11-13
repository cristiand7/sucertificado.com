import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Utils } from '../share/utils';
import { Examen } from '../modelo/examen';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExamenService {
  private URL_EXAMEN: string=Utils.URL_BACKEND+'/examen';

  constructor(private http: HttpClient) { }

  findAll(): Observable<Examen[]> {
    return this.http.get<Examen[]>(this.URL_EXAMEN);
}
}
