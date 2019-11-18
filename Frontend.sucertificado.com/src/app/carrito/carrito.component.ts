import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { CursoService } from '../service/curso.service';
import { Curso } from '../modelo/curso';
import { EstudianteCurso } from '../modelo/estudiante-curso';
export interface DialogData {
  animal: 'panda' | 'unicorn' | 'lion';
}
@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css']
})
export class CarritoComponent implements OnInit {

  cursos: Curso[] = [];
  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData, private service: CursoService) { }

  ngOnInit() {
    this.loadCursos();
  }

  loadCursos() {
    this.cursos = this.service.getCarrito();
  }
  pagar() {
    for (let curso of this.cursos) {
      var reg = new EstudianteCurso()
      alert(curso.IdCurso);
      reg.nombreusuario = "1";
      reg.documento = "1234";

      reg.nombrecurso = curso.IdCurso+'';
      reg.areacurso = curso.AreaCurso


      this.service.pago(reg).subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error.error);
        }
      );

      this.service.registro(reg).subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error.error);
        }
      );
    }
    alert('Compra realizada')

  }
}
