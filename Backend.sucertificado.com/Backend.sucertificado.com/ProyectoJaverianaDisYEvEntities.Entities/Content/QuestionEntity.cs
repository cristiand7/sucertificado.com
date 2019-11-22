using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvEntities.Entities
{
public class QuestionEntity
    {
        public int idPregunta { get; set; }
        public string descripcionPregunta { get; set; }
        public string TipoPregunta { get; set; }
        public string AreaPregunta { get; set; }
        public int PuntajeMaximo { get;set; }
        public string curso { get; set; }
        public List<ResponseEntity> responses { get; set; }
        public ResponseEntity respuestaDBCorrecta { get; set; }
        public ResponseEntity RespuestaUsuario { get; set; }

    }
}
