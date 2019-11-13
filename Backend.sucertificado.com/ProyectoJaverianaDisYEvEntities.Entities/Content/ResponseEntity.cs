using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvEntities.Entities
{
    public class ResponseEntity
    {
        public int IdRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public int PuntajeRespuesta { get; set; }
        public int IdPregunta { get; set; }
        public int RespuestaCorrecta {get;set;}
        public string AreaRespuesta { get; set; }
        public string TipoRespuesta { get; set; }
        public string curso { get; set; }

    }
}
