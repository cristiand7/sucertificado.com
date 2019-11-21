import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { CursoService } from '../service/curso.service';
import { Curso } from '../modelo/curso';
import { EstudianteCurso } from '../modelo/estudiante-curso';
import { UsuarioService } from '../service/usuario.service';
import { Usuario } from '../modelo/usuario';
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
  user: Usuario;
  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData, private service: CursoService, private usuarioService: UsuarioService,
  public dialogRef: MatDialogRef<CarritoComponent>) { }

  ngOnInit() {
    this.loadCursos();
    this.user=this.usuarioService.getCurrentUser();
  }

  loadCursos() {
    this.cursos = this.service.getCarrito();
  }
  pagar() {
    
    for (let curso of this.cursos) {
      var reg = new EstudianteCurso()
   
      reg.nombreusuario = this.user.IdPersona+'';
      reg.documento = this.user.documento+'';

      reg.nombrecurso = curso.IdCurso+'';
      reg.areacurso = curso.AreaCurso


      this.service.pago(reg).subscribe(
        data => {
          console.log(data);
        },
        error => {
          if (error.reponse == 401){

            this.usuarioService.refreshToken();
            this.pagar();
          }
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
    this.cursos=[];
    this.service.cleanCarrito();
    alert('Compra realizada')
    this.dialogRef.close();
  }
}
