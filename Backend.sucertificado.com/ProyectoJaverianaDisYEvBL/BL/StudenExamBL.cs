using ProyectoJaverianaDisYEvDAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvBL.BL
{
 public    class StudenExamBL
    {

        public bool AfiliarEstudianteaExamen(int userid, int examid)
        {
            StudenExamDAL studentExamDAL = new StudenExamDAL();
            return studentExamDAL.AfiliarEstudianteaExamen(userid, examid);
        }
        public bool PagarCurso(int userid, int examid)
        {
            StudenExamDAL studentExamDAL = new StudenExamDAL();
            return studentExamDAL.PagarCurso(userid, examid);
        }
        public bool HacerCitaExamen(int studentid, int examenid,string fecha)
        {
            StudenExamDAL studentExamDAL = new StudenExamDAL();
            return studentExamDAL.HacerCitaExamen(studentid, examenid,fecha);
        }
        public bool GuardarCalificacion(int user, int examn, double Puntaje)
        {
            StudenExamDAL studentExamDAL = new StudenExamDAL();
            return studentExamDAL.GuardarCalificacion(user, examn, Puntaje);
        }


    }
}
