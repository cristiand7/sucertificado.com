using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvEntities.Entities.Content
{
    public class StudentExamEntity
    {
        public int StudentExamID { get; set; }
        public int ExamID { get; set; }
        public int Idstudent{ get; set; }
        public double PuntajeExamen { get; set; }
        public string FechaExamen { get; set; }
        public string aprobacionexamen { get; set; }

    }
}
