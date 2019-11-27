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

  path: string[]= ["assets/0.png",
  "assets/1.png",
  "assets/2.png",
  "assets/3.png",
  "assets/4.png",
  "assets/5.png",
  "assets/6.png",
  "assets/7.png",
  "assets/8.png",
  "assets/9.png"
]

comentarios: string[] = [
"Este curso gratuito, introducirá a los alumnos al estudio de las fracciones en matemáticas. Con el curso, podrán reforzar conocimientos al mismo tiempo que aprenden nuevos temas sobre las fracciones. Este curso, está orientado a todos aquellos que quieran aprender más acerca...",
"1.Concepto de fracción. Las fracciones en nuestra vida.      Elementos de una fracción.       Cómo se lee una fracción.El valor de una fracción.Pasar una fracción a un decimal.  2.Fracciones equivalentes.Fracciones equivalentes.Productos cruzados,Fracciones equivalentes,Fracciones equivalentes..."
,"El curso básico de inglés, está diseñado para los que están empezando. Al finalizar el curso, el estudiante tendrá una comprensión de los conceptos básicos de inglés y será capaz de formar construcciones y oraciones simples. 1.1	 	Personal Pronouns..."
,"Programa desde cero, domina Javascript, entiende HTML y aprende de algoritmos. Sí, desde cero. Entenderás la lógica del código, cómo piensan los programadores y cómo programar juegos, proyectos y hasta robots y electrónica. Aprender a programar no es fácil...",
"La biología celular se encarga de estudiar la célula, sus funciones, sus propiedades y su estructura, así como su interacción con el ambiente y su ciclo vital. En este curso gratuito, analizarás las células sin núcleo o estructuras definidas por membranas, así ..."
,"ASP.NET Corees un nuevo framework de código abierto y multiplataforma para la creación de aplicaciones modernas conectadas a Internet, como aplicaciones web y APIs Web. Se diseñó para proporcionar un framework de desarrollo optimizado para las aplicaciones que se..."
,"Microsoft Azure es conjunto en constante expansión de servicios en la nube para ayudar a su organización a satisfacer sus necesidades comerciales. Le otorga la libertad de crear, administrar e implementar aplicaciones en una red mundial enorme con sus herramientas y..."
,"",
"",
"",
"",
"",
"",
"",
"",
""
]  
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
