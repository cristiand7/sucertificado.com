using ProyectoJaverianaDisYEvDAL.DAL;
using ProyectoJaverianaDisYEvEntities.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvBL.BL
{
   public  class CourseBL
    {
        public bool insertCourseResponse(CourseEntity course)
        {
            CourseDal coursedal = new CourseDal();
            return coursedal.insertCourseResponse(course);

        }
        public List<CourseEntity> GetAllCourses()
        {
            CourseDal courseDal = new CourseDal();
            return courseDal.GetAllCourses();
        }
         public List<CourseEntity> GetAllCoursesWithinNameAndArea(string curso)
        {
            CourseDal courseDal = new CourseDal();
            return courseDal.GetAllCoursesWithinNameAndArea(curso);
        }
        public CourseEntity GetCourse(string curso,string area)
        {
            CourseDal courseDal = new CourseDal();
            return courseDal.GetCourse(curso,area);
        }
        public bool RealizarPago(UserEntity user, CourseEntity course)
        {
            CourseDal courseDal = new CourseDal();
            return courseDal.RealizarPago(user, course);
        }
        public bool VerificaPago(UserEntity user, CourseEntity course)
        {
            CourseDal courseDal = new CourseDal();
            return courseDal.VerificaPago(user, course);
        }
    


    }
}
