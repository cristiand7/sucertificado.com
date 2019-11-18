using ProyectoJaverianaDisYEvDAL.DAL;
using ProyectoJaverianaDisYEvEntities.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvBL.BL
{
   public class ExamBL
    {
        public ExamEntity getexambyname(string name,int numPreguntas)
        {
            ExamDAL examDAL = new ExamDAL();
            return examDAL.getexambyname(name, numPreguntas);
        }
    }
}
