using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvEntities.Entities.Content
{
   public  class EstudianteCursoEntity
    {
        public int IdCurso { get; set; }
        public int IdEstudiante { get; set; }
        public int IDCurso_estudiante { get; set; }
        public string  FechaPresentacionExamen { get; set; }
        public int PuntajeExamen { get; set; }

        public string EstadoAprovacionExamen { get; set; }



    }
}
