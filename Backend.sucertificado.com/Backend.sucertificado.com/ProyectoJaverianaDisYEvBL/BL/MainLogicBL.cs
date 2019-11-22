using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoJaverianaDisYEvEntities.Entities;
using ProyectoJaverianaDisYEvEntities.Entities.Content;

namespace ProyectoJaverianaDisYEvBL.BL
{
    public class MainLogicBL
    {
        public bool insertQuestion(QuestionEntity question)
        {
            QuestionBL questionBL = new QuestionBL();
            return questionBL.insertQuestion(question);
        }
        public bool insertQuestionResponses(QuestionListResponsesEntity questionResponses)
        {
            bool inserto = false;
            int counttrue = 0;
            ResponseBL questionResponseBL = new ResponseBL();
            foreach (ResponseEntity questionResponse in questionResponses.questionresponses)
            {
                inserto = false;
                inserto = questionResponseBL.insertQuestionResponses(questionResponse);
                if (inserto == true)
                {
                    counttrue++;
                }
            }
            if (counttrue > 0)
            {
                return true;
            }
            else return false;
        }
        public List<QuestionEntity> GetquestionWithResponses(string course, string area, int questionnumber)
        {
            QuestionBL questionBL = new QuestionBL();
            ResponseBL responseBL = new ResponseBL();
            List<QuestionEntity> questions = questionBL.GetquestionWithResponses(course, area, questionnumber);
            foreach (QuestionEntity que in questions)
            {

                que.responses = responseBL.GetResponsesFromQuestion(que);
            }
            return questions;
        }
        public ResultExamStudentEntity CalificateQuestions(List<QuestionEntity> questions, string curso, string area,string nombreusuario,string documento)
        {
            List<QuestionEntity> questionsInDB = new List<QuestionEntity>();
            QuestionBL questionBL = new QuestionBL();
            int totalPregunta = questions.Count;
            int totalcorrecto = 0;
            double totalcorrectasporexamen = 0;

            ResultExamStudentEntity resultExam = new ResultExamStudentEntity();
            resultExam.questionsStudent = questions;
            ResponseBL responseBL = new ResponseBL();
            foreach (QuestionEntity que in questions)
            {
                ResponseEntity response = new ResponseEntity();
                QuestionEntity question = new QuestionEntity();
                question = questionBL.Getstudentquestions(curso, area, que.descripcionPregunta);
                response = responseBL.GetCorrectResponseFromQuestion(question);
                question.respuestaDBCorrecta = response;
                if (question.respuestaDBCorrecta.DescripcionRespuesta == que.RespuestaUsuario.DescripcionRespuesta)
                {
                    totalcorrecto++;
                }
                questionsInDB.Add(question);


            }
            resultExam.QuestionDB = questionsInDB;
            totalcorrectasporexamen = (totalcorrecto*5) / totalPregunta;
            resultExam.puntaje = totalcorrectasporexamen;
            UserBL userbl = new UserBL();
            CourseBL courseBL = new CourseBL();
            UserEntity user = userbl.GetUser(nombreusuario,documento);
            CourseEntity course = courseBL.GetCourse(curso, area);

            EstudianteCursoBL estudianteCursoBL = new EstudianteCursoBL();
            estudianteCursoBL.GuardarCalificacion(user, course, totalcorrectasporexamen);

            return resultExam;
        }
        public UserEntity LoginUser(string nameuser, string password)
        {
            UserBL userBL = new UserBL();
            return userBL.LoginUser(nameuser, password);
        }
        public bool CreateCourse(CourseEntity curso)
        {
            CourseBL course = new CourseBL();
            return course.insertCourseResponse(curso);
        }
        public List<CourseEntity> GetAllCourses()
        {
            CourseBL course = new CourseBL();
            return course.GetAllCourses();
        }
        public List<CourseEntity> GetAllCoursesWithinNameAndArea(string curso)
        {
            CourseBL course = new CourseBL();
            return course.GetAllCoursesWithinNameAndArea(curso);
        }
        public UserEntity GetUser(string username, string Documento)
        {
            UserBL userbl = new UserBL();
            return userbl.GetUser(username, Documento);
        }
        public CourseEntity GetCourse(string username,string area)
        {
            CourseBL courseBL = new CourseBL();
            return courseBL.GetCourse(username, area);
        }
        public bool RealizarPago(MakePaymentEntity payment)
        {
            CourseBL courseBL = new CourseBL();
            UserBL userbl = new UserBL();
            CourseEntity courseEntity = courseBL.GetCourse(payment.nombrecurso, payment.areacurso);
            UserEntity user = userbl.GetUser(payment.nombreusuario, payment.documento);


            return courseBL.RealizarPago(user, courseEntity);
        }
        

     public bool HacerCita(MakeAppointmentEntity appointmentEntity)
        {
            bool pago = false;
            EstudianteCursoBL estudianteCursoBL = new EstudianteCursoBL();
            CourseBL courseBL = new CourseBL();
            UserBL userbl = new UserBL();
            CourseEntity courseEntity = courseBL.GetCourse(appointmentEntity.nombrecurso, appointmentEntity.areacurso);
            UserEntity user = userbl.GetUser(appointmentEntity.nombreusuario, appointmentEntity.documento);
            pago = courseBL.VerificaPago(user, courseEntity);
            if (pago == true)
            {
             return   estudianteCursoBL.HacerCita(user,courseEntity,appointmentEntity.fechadeappointment);
            }

            return false;
        }

        public bool AfiliarEstudianteAcurso(AfiliateStudentCourseEntity estudiantecurso)
        {
            EstudianteCursoBL estudianteCursoBL = new EstudianteCursoBL();
            CourseBL courseBL = new CourseBL();
            UserBL userbl = new UserBL();
            CourseEntity courseEntity = courseBL.GetCourse(estudiantecurso.nombrecurso, estudiantecurso.areacurso);
            UserEntity user = userbl.GetUser(estudiantecurso.nombreusuario, estudiantecurso.documento);
           
                return estudianteCursoBL.AfiliarEstudianteacurso(user, courseEntity);
            

        }
        public ExamEntity getExambyname(string nombreexamen,int numPreguntas)
        {
            ExamBL exambl = new ExamBL();
            List<ResponseEntity> correctas = new List<ResponseEntity>();
            List<ResponseEntity> incorrectas = new List<ResponseEntity>();

            QuestionBL questionbl = new QuestionBL();
            ResponseBL responsebl = new ResponseBL();
            ExamEntity exam = exambl.getexambyname(nombreexamen,numPreguntas);
            List<QuestionEntity> questions=questionbl.GetQuestionsByExamID(exam.idexamen,numPreguntas);
            foreach(QuestionEntity question in questions)
            {
                List<ResponseEntity> responses = responsebl.GetResponseFromQuestionID(question.idPregunta);
                foreach(ResponseEntity res in responses)
                {
                    if (res.RespuestaCorrecta > 0)
                    {
                        correctas.Add(res);
                    }
                    else if (res.RespuestaCorrecta < 1)
                    {
                        incorrectas.Add(res);
                    }
                }
                exam.correctas = correctas;
                exam.incorrectas = incorrectas;
            }

            return exam;


        }
        //paso 1 para presentar el examen
        public bool AfiliarEstudianteaExamen(int estudianteID,int ExamenID)
        {
            EstudianteCursoBL estudianteCursoBL = new EstudianteCursoBL();
            CourseBL courseBL = new CourseBL();
            UserBL userbl = new UserBL();
            StudenExamBL student = new StudenExamBL();
            return student.AfiliarEstudianteaExamen(estudianteID, ExamenID);
        }
        public bool RealizarPago(int studentid, int examenid)
        {
            EstudianteCursoBL estudianteCursoBL = new EstudianteCursoBL();
            CourseBL courseBL = new CourseBL();
            UserBL userbl = new UserBL();
            StudenExamBL student = new StudenExamBL();

            return student.PagarCurso(studentid, examenid);

        }
        public bool HacerCitaExamen(int userid,int examid,string fecha)
        {
            bool pago = false;
            EstudianteCursoBL estudianteCursoBL = new EstudianteCursoBL();
            CourseBL courseBL = new CourseBL();
            UserBL userbl = new UserBL();
            StudenExamBL student = new StudenExamBL();
            return student.HacerCitaExamen(userid, examid, fecha);
         
 
        }

        public bool GuardarCalificacion(int user, int examn, double Puntaje)
        {
            EstudianteCursoBL estudianteCursoBL = new EstudianteCursoBL();
            CourseBL courseBL = new CourseBL();
            UserBL userbl = new UserBL();
            StudenExamBL student = new StudenExamBL();
            return student.GuardarCalificacion(user, examn, Puntaje);


        }





    }
}
