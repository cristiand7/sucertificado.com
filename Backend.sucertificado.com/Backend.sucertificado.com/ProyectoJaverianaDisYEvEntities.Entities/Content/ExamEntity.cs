using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvEntities.Entities.Content
{
    public class ExamEntity
    {
        public int idexamen { get; set; }
        public string nombre { get; set; } 
        public string areaexamen { get; set; }
        public List<ResponseEntity> correctas { get; set; }
        public List<ResponseEntity> incorrectas { get; set; }


    }
}
