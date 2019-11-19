import { Component, OnInit } from '@angular/core';
import { CursoService } from '../service/curso.service';
import { Curso } from '../modelo/curso';
import { EstudianteCurso } from '../modelo/estudiante-curso';
import { UsuarioService } from '../service/usuario.service';

@Component({
  selector: 'app-catalogo',
  templateUrl: './catalogo.component.html',
  styleUrls: ['./catalogo.component.css']
})
export class CatalogoComponent implements OnInit {

  path: string[]= ["assets/0.png"]
  
  cursos: Curso[] = [];
  constructor(private service: CursoService, private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.loadCursos();
  }

  loadCursos() {
    this.service.findAll().subscribe(
      data => {
        this.cursos = data;
        console.log(data);
      },
      error => {
        console.log(error.error);
      }
    );
  }
  reg: EstudianteCurso;
  comprar(curso: Curso) {
    if (this.usuarioService.isAuthenticated()) {
      this.service.add(curso);
      alert('Curso ' + curso.NombreCurso + ' ha sido agreado a tu carrito');
    }
    else {
      alert('Debes iniciar sesión para continuar ');
    }
  }
}
