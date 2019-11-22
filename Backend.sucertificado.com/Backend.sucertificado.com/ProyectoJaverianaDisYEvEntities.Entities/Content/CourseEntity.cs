using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvEntities.Entities.Content
{
 public    class CourseEntity
    {
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string DescripcionCurso { get; set; }
        public string AreaCurso { get; set; }
        public List<QuestionEntity> preguntascurso;
    }
}
