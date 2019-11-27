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
"Este curso gratuito, introducirá a los alumnos al estudio de las fracciones en matemáticas. Con el curso, podrán reforzar conocimientos al mismo tiempo que aprenden nuevos temas sobre las fracciones. Este curso, está orientado a todos aquellos que quieran aprender más acerca de las fracciones matemáticas. Para participar en el curso, no es necesario disponer de conocimientos previos sobre los temas a tratar, lo que sí que necesitarás es un ordenador con conexión estable a internet para poder acceder a todo el contenido del curso.",
"1.Concepto de fracción. Las fracciones en nuestra vida.      Elementos de una fracción.       Cómo se lee una fracción.El valor de una fracción.Pasar una fracción a un decimal.  2.Fracciones equivalentes.Fracciones equivalentes.Productos cruzados.    Simplificar una fracción.3.Operaciones con fracciones.Paso a común denominador.Suma de fracciones. Suma y resta de fracciones.Multiplicación de fracciones.Fracción inversa de una fracción.División de fracciones.Operaciones combinadas4.AplicacionesProblemas con fracciones"
,"El curso básico de inglés, está diseñado para los que están empezando. Al finalizar el curso, el estudiante tendrá una comprensión de los conceptos básicos de inglés y será capaz de formar construcciones y oraciones simples. 1.1	 	Personal Pronouns (Los pronombres personales)Eercise 1Exercise 2.2	 	Possessives (Los posesivos)Exercise 1Exercise 21.3	 	Demonstrative Pronouns (Los pronombres demostrativos)xercise 1Exercise 21.4	 	Reflexive Pronouns (Los pronombres reflexivos)Exercise 1Exercise 2"
,"Programa desde cero, domina Javascript, entiende HTML y aprende de algoritmos. Sí, desde cero. Entenderás la lógica del código, cómo piensan los programadores y cómo programar juegos, proyectos y hasta robots y electrónica. Aprender a programar no es fácil, pero Platzi lo hace efectivo.¿Qué es HTML/CSS/JS?JavaScript no es JavaPrimeros pasos en el navegador con alertHTML, CSS, JavaScript de verdadLos apuntes de Freddy en PDFPrimer proyecto: Peso en otro planetaPeso en otro planetaObteniendo datos del usuarioFlujo y condicionales",
"La biología celular se encarga de estudiar la célula, sus funciones, sus propiedades y su estructura, así como su interacción con el ambiente y su ciclo vital. En este curso gratuito, analizarás las células sin núcleo o estructuras definidas por membranas, así como las que tienen presencia de éste.En el curso, creado e impartido por la Universidad Autónoma de Baja California Sur, el alumno reconocerá las células procariotas y eucariotas y su importancia en el ciclo celular, a través del analisis de su estructura y función."
,"ASP.NET Corees un nuevo framework de código abierto y multiplataforma para la creación de aplicaciones modernas conectadas a Internet, como aplicaciones web y APIs Web. Se diseñó para proporcionar un framework de desarrollo optimizado para las aplicaciones que se implementan tanto en la nube como en servidores dedicados en las instalaciones del cliente. Se pueden desarrollar y ejecutar aplicaciones ASP.NET Core en Windows, Mac y Linux. ASP.NET Core puede ejecutarse sobre el framework .NET completo o sobre .NET Core. ","Microsoft Azure es conjunto en constante expansión de servicios en la nube para ayudar a su organización a satisfacer sus necesidades comerciales. Le otorga la libertad de crear, administrar e implementar aplicaciones en una red mundial enorme con sus herramientas y marcos favoritos.Prepárese para el futuroLa innovación continua de Microsoft sustenta el trabajo de desarrollo que realiza hoy y sus ideas de productos futuros.Cree soluciones como prefieraDentro de nuestro compromiso de contribuir al código abierto y de admitir todos los lenguajes y marcos, le ofrecemos la posibilidad de crear soluciones de la manera que prefiera y de implementarlas donde quiera."
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
