using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvEntities.Entities.Content
{
    public class ResultExamStudentEntity
    {
        public List<QuestionEntity> QuestionDB { get; set; }

        public List<QuestionEntity> questionsStudent { get; set; }
        public double puntaje { get; set; }
    }
}
