using ProyectoJaverianaDisYEvBL.BL;
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
    [AllowAnonymous]
    [RoutePrefix("api/Courses")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CoursesController : ApiController
    {
        #region Anonymous

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
        [ActionName("GetCourse")]
        [Route("GetCourse")]
        public CourseEntity GetCourse(string NombreCurso, string AreaCurso)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.GetCourse(NombreCurso, AreaCurso);
        }
        #endregion

        #region Registered
        [Authorize]
        [HttpPost]
        [ActionName("CreateCourse")]
        [Route("CreateCourse")]
        public bool CreateCourse([FromBody] CourseEntity curso)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.CreateCourse(curso);
        }
        [Authorize]
        [HttpPost]
        [AllowCrossSiteJsonAttribute]
        [ActionName("AfiliarEstudianteAcurso")]
        [Route("AfiliarEstudianteAcurso")]
        public bool AfiliarEstudianteAcurso(AfiliateStudentCourseEntity estudiantecurso)
        {
            MainLogicBL operation = new MainLogicBL();
            return operation.AfiliarEstudianteAcurso(estudiantecurso);
        }
        #endregion
    }
}
