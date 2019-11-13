using ProyectoJaverianaDisYEvEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoJaverianaDisYEvDAL.DAL;

namespace ProyectoJaverianaDisYEvBL.BL
{
 public  class QuestionBL
    {
        public bool insertQuestion(QuestionEntity question)
        {
            QuestionDAL questionDAL = new QuestionDAL();
            return questionDAL.insertQuestion(question);

        }
        public List<QuestionEntity> GetquestionWithResponses(string course, string area, int questionnumber)
        {
            QuestionDAL questionDAL = new QuestionDAL();
            return questionDAL.GetquestionWithResponses( course,  area,  questionnumber);

        }
        public QuestionEntity Getstudentquestions(string course, string area, string Description)
        {
            QuestionDAL questionDAL = new QuestionDAL();
            return questionDAL.Getstudentquestions(course, area,Description);

        }

    }
}
