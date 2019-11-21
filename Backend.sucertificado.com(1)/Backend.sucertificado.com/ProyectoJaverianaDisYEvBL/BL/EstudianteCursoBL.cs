using ProyectoJaverianaDisYEvDAL.DAL;
using ProyectoJaverianaDisYEvEntities.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvBL.BL
{
   public  class EstudianteCursoBL
    {
        public bool HacerCita(UserEntity user, CourseEntity courseS, string fechapresentacion)
        {

            EstudianteCursoDAL estudiantecursoDAL = new EstudianteCursoDAL();
            return estudiantecursoDAL.HacerCita(user, courseS, fechapresentacion);
        }
        public bool GuardarCalificacion(UserEntity user, CourseEntity courseS, double  calificacion)
        {

            EstudianteCursoDAL estudiantecursoDAL = new EstudianteCursoDAL();
            return estudiantecursoDAL.GuardarCalificacion(user, courseS, calificacion);
        }
        public bool AfiliarEstudianteacurso(UserEntity user, CourseEntity courseS)
        {
            EstudianteCursoDAL estudiantecursoDAL = new EstudianteCursoDAL();
            return estudiantecursoDAL.AfiliarEstudianteacurso(user, courseS);
        }

    }
}
