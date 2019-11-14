using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using ProyectoJaverianaDisYEvBL.BL;
using ProyectoJaverianaDisYEvEntities.Entities;
using ProyectoJaverianaDisYEvEntities.Entities.Content;

namespace ProyectoJaverianaDisYEv.Controllers
{
    [AllowCrossSiteJsonAttribute]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
       
   
        [HttpPost]
        [ActionName("insertQuestion")]
        [Route("insertQuestion")]
        public bool insertQuestion([FromBody] QuestionEntity value)
        {
           MainLogicBL operation = new MainLogicBL();
           return  operation.insertQuestion(value);
        }

        [HttpPost]
        [ActionName("insertQuestionResponses")]
        [Route("insertQuestionResponses")]
        public bool insertQuestionResponses([FromBody] QuestionListResponsesEntity questionresponses)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.insertQuestionResponses(questionresponses);
        }


        [HttpGet]
        [ActionName("GetQuestionWithResponses")]
        [Route("GetQuestionWithResponses")]
        public List<QuestionEntity> GetQuestionWithResponses(string course,string area,int questionnumber)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.GetquestionWithResponses(course,area,questionnumber);
        }
        [HttpPost]
        [ActionName("CalificateQuestions")]
        [Route("CalificateQuestions")]
        public ResultExamStudentEntity CalificateQuestions([FromBody] ResultExamPostRequest questionresponses)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.CalificateQuestions(questionresponses.questions, questionresponses.curso,questionresponses.area,questionresponses.nombreusuario,questionresponses.documento);
        }
        [HttpGet]
        [ActionName("LoginUser")]
        [Route("LoginUser")]
        public UserEntity LoginUser(string username, string password )
        {
            // Guid value1 = new Guid( course, string area, int questionnumber);
            MainLogicBL operation = new MainLogicBL();
            return operation.LoginUser(username,password);
        }
        [HttpPost]
        [ActionName("CreateCourse")]
        [Route("CreateCourse")]
        public bool CreateCourse([FromBody] CourseEntity curso)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.CreateCourse(curso);
        }
        [HttpPost]
        [ActionName("RealizarPago")]
        [Route("RealizarPago")]
        public bool RealizarPago([FromBody] MakePaymentEntity payment)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.RealizarPago(payment);
        }
        [HttpPost]
        [ActionName("AgendarExamen")]
        [Route("AgendarExamen")]
        public bool HacerCita([FromBody] MakeAppointmentEntity appointment)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.HacerCita(appointment);
        }

        [HttpGet]
        [ActionName("GetAllCouses")]
        [Route("GetAllCouses")]
        public List<CourseEntity> GetAllCourses()
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.GetAllCourses();
        }
        [HttpGet]
        [ActionName("GetAllCoursesWithinNameAndArea")]
        [Route("GetAllCoursesWithinNameAndArea")]
        public List<CourseEntity> GetAllCoursesWithinNameAndArea(string course)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.GetAllCoursesWithinNameAndArea(course);
        }

        [HttpGet]
        [ActionName("GetUser")]
        [Route("GetUser")]
        public UserEntity GetUser(string username, string Documento)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.GetUser(username, Documento);
        }

        [HttpGet]
        [ActionName("GetCourse")]
        [Route("GetCourse")]
        public CourseEntity GetCourse(string NombreCurso, string AreaCurso)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.GetCourse(NombreCurso, AreaCurso);
        }

        [HttpPost]
        [ActionName("AfiliarEstudianteAcurso")]
        [Route("AfiliarEstudianteAcurso")]
        public bool AfiliarEstudianteAcurso(AfiliateStudentCourseEntity estudiantecurso)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.AfiliarEstudianteAcurso(estudiantecurso);
        }
        

    }
}
