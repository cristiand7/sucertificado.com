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
    this.reg=new EstudianteCurso()  
    alert(curso.IdCurso);
    this.reg.nombreusuario="pp";
    this.reg.documento="1234";
    
    this.reg.nombrecurso=curso.NombreCurso;
    this.reg.areacurso=curso.AreaCurso
      
      
    this.service.pago(this.reg).subscribe(
      data => {
            console.log(data);
      },
      error => {
        console.log(error.error);
      }
    );

    this.service.registro(this.reg).subscribe(
      data => {
        console.log(data);
        alert('Compra realizada')
      },
      error => {
        console.log(error.error);
      }
    );

  }
}
