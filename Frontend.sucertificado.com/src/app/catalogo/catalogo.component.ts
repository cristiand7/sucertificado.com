import { Component, OnInit } from '@angular/core';
import { CursoService } from '../service/curso.service';
import { Curso } from '../modelo/curso';
import { EstudianteCurso } from '../modelo/estudiante-curso';

@Component({
  selector: 'app-catalogo',
  templateUrl: './catalogo.component.html',
  styleUrls: ['./catalogo.component.css']
})
export class CatalogoComponent implements OnInit {

  cursos: Curso[]=[];
  constructor(private service: CursoService) { }

  ngOnInit() {
    this.loadCursos();
  }

  loadCursos(){
    this.service.findAll().subscribe(
      data => {
       this.cursos=data;
        console.log(data);
      },
      error => {
        console.log(error.error);
      }
    );
  }
  reg: EstudianteCurso ;
  comprar(curso: Curso){
    this.service.add(curso);
  

  }
}
