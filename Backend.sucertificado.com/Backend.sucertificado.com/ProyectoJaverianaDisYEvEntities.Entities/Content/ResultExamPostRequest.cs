using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvEntities.Entities.Content
{
   public class ResultExamPostRequest
    {
      public  List<QuestionEntity> questions;
        public string curso { get; set; }
        public string area { get; set; }
        public string nombreusuario { get; set; }
        public string documento { get; set; }
    }
}
