using ProyectoJaverianaDisYEvBL.BL;
using ProyectoJaverianaDisYEvEntities.Entities;
using ProyectoJaverianaDisYEvEntities.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoJaverianaDisYEv.Controllers
{
    [RoutePrefix("api/exam")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExamController : ApiController
    {
        #region Registered
        [Authorize]
        [HttpPost]
        [ActionName("insertQuestion")]
        [Route("insertQuestion")]
        public bool insertQuestion([FromBody] QuestionEntity value)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.insertQuestion(value);
        }
        [Authorize]
        [HttpPost]
        [ActionName("insertQuestionResponses")]
        [Route("insertQuestionResponses")]
        public bool insertQuestionResponses([FromBody] QuestionListResponsesEntity questionresponses)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.insertQuestionResponses(questionresponses);
        }
        [Authorize]
        [HttpGet]
        [ActionName("GetQuestionWithResponses")]
        [Route("GetQuestionWithResponses/{course}/{area}/{questionnumber}")]
        public List<QuestionEntity> GetQuestionWithResponses(string course, string area, int questionnumber)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.GetquestionWithResponses(course, area, questionnumber);
        }

        [Authorize]
        [HttpPost]
        [ActionName("CalificateQuestions")]
        [Route("CalificateQuestions")]
        public ResultExamStudentEntity CalificateQuestions([FromBody] ResultExamPostRequest questionresponses)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.CalificateQuestions(questionresponses.questions, questionresponses.curso, questionresponses.area, questionresponses.nombreusuario, questionresponses.documento);
        }
        [Authorize]
        [HttpPost]
        [ActionName("ScheduleExam")]
        [Route("ScheduleExam")]
        public bool BookAppoinment([FromBody] MakeAppointmentEntity appointment)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.HacerCita(appointment);
        }

      //  [Authorize]
        [HttpGet]
        [ActionName("GetExamByName")]
        [Route("GetExamByName/{nombreexamen}/{numPreguntas}")]
        public ExamEntity getExambynameAndNumber(string nombreexamen, int numPreguntas)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.getExambyname(nombreexamen, numPreguntas);
        }
     //   [Authorize]
        [HttpPost]
        [ActionName("AfiliateStudentToExam")]
        [Route("AfiliateStudentToExam/{StudentID}/{ExamID}")]
        public bool getExambynameAndNumber(int StudentID, int ExamID)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.AfiliarEstudianteaExamen(StudentID, ExamID);
        }
    //    [Authorize]
        [HttpPost]
        [ActionName("RealizarPago")]
        [Route("RealizarPago/{StudentID}/{ExamID}")]
        public bool RealizarPago(int StudentID, int ExamID)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.RealizarPago(StudentID, ExamID);
        }
      //  [Authorize]
        [HttpPost]
        [ActionName("HacerCitaExamen")]
        [Route("HacerCitaExamen/{StudentID}/{examid}/{fecha}")]
        public bool HacerCitaExamen(int StudentID, int examid, string fecha)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.HacerCitaExamen(StudentID, examid, fecha);

        }

//[Authorize]
        [HttpPost]
        [ActionName("GuardarCalificacion")]
        [Route("GuardarCalificacion/{StudentID}/{examid}/{puntaje}")]

        public bool GuardarCalificacion(int StudentID, int examid, double puntaje)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.GuardarCalificacion(StudentID, examid, puntaje);

        }


        #endregion
    }
}
