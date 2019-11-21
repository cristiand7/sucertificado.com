using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvEntities.Entities.Content
{
   public class UserEntity
    {

       public int IdPersona { get; set; }
            public string nombre { get; set; }
        public string apellido { get; set; }
        public string rol { get; set; }
        public int PuntajeGlobal { get; set; }
        public string grupo { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string documento { get; set; }
   
    }
}
