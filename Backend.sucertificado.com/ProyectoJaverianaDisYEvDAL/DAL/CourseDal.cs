using ProyectoJaverianaDisYEvEntities.Entities.Content;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvDAL.DAL
{
   public  class CourseDal
    {
        public bool insertCourseResponse(CourseEntity course)
        {
            SqlConnection con = new SqlConnection("Server=DESKTOP-UCJJCA9"+ @"\" +"SQLEXPRESS; Database= ProyectoJaveriana; Integrated Security=True;");
            int i = 0;
            string fullquery = "";
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("insert into Curso (NombreCurso,DescripcionCurso,AreaCurso) values");
            stringquery.Append("('" + course.NombreCurso + "','" + course.DescripcionCurso + "','" + course.AreaCurso+ "' )");
            fullquery = stringquery.ToString();
            SqlCommand cmd = new SqlCommand(fullquery, con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<CourseEntity> GetAllCourses()
        {
            List<CourseEntity> Responses = new List<CourseEntity>();
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server=DESKTOP-UCJJCA9" + @"\" + "SQLEXPRESS; Database= ProyectoJaveriana; Integrated Security=True;");
            int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select * from Curso ");
        

            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CourseEntity course = new CourseEntity();

                        course.IdCurso = dr.GetInt32(dr.GetOrdinal("IdCurso"));
                        course.DescripcionCurso = dr.GetString((dr.GetOrdinal("DescripcionCurso")));
                        course.AreaCurso = dr.GetString((dr.GetOrdinal("AreaCurso")));
                        course.NombreCurso = dr.GetString((dr.GetOrdinal("NombreCurso")));
                     


                        Responses.Add(course);
                    }
                    con.Close();
                }
            }
            return Responses;

        }
        public List<CourseEntity> GetAllCoursesWithinNameAndArea(string curso)
        {
            List<CourseEntity> Responses = new List<CourseEntity>();
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= localhost; Database= ProyectoJaveriana; Integrated Security=True;");
            int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select * from Curso ");
            stringquery.Append("where NombreCurso= '"+curso+"'");
            



            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CourseEntity course = new CourseEntity();

                        course.IdCurso = dr.GetInt32(dr.GetOrdinal("IdCurso"));
                        course.DescripcionCurso = dr.GetString((dr.GetOrdinal("DescripcionCurso")));
                        course.AreaCurso = dr.GetString((dr.GetOrdinal("AreaCurso")));
                        course.NombreCurso = dr.GetString((dr.GetOrdinal("NombreCurso")));



                        Responses.Add(course);
                    }
                    con.Close();
                }
            }
            return Responses;

        }
        public CourseEntity GetCourse(string nombreCurso, string areaCurso)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= localhost; Database= ProyectoJaveriana; Integrated Security=True;");
            int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select * from Curso ");
            stringquery.Append("where NombreCurso= '"+nombreCurso+"'");
            stringquery.Append("and AreaCurso= '" + areaCurso + "'");

            CourseEntity course = new CourseEntity();



            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        course.IdCurso = dr.GetInt32(dr.GetOrdinal("IdCurso"));
                        course.DescripcionCurso = dr.GetString((dr.GetOrdinal("DescripcionCurso")));
                        course.AreaCurso = dr.GetString((dr.GetOrdinal("AreaCurso")));
                        course.NombreCurso = dr.GetString((dr.GetOrdinal("NombreCurso")));



                    }
                    con.Close();
                }
            }
            return course;

        }

        public bool RealizarPago(UserEntity user,CourseEntity courseS)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= localhost; Database= ProyectoJaveriana; Integrated Security=True;");
            int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("insert into Pago (IdPersona,IdCurso,EstadoPago) values");
            stringquery.Append("('"+user.IdPersona+"','"+ courseS.IdCurso+"',1)");



            string fullquery = stringquery.ToString();


            SqlCommand cmd = new SqlCommand(fullquery, con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           

            }
        public bool VerificaPago(UserEntity user, CourseEntity courseS)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= localhost; Database= ProyectoJaveriana; Integrated Security=True;");
            int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select * from Pago ");
            stringquery.Append("where IdPersona= " + user.IdPersona + "");
            stringquery.Append("and IdCurso= " + courseS.IdCurso + "");




            string fullquery = stringquery.ToString();


            SqlCommand cmd = new SqlCommand(fullquery, con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                       i= dr.GetInt32(dr.GetOrdinal("IdCurso"));
                      


                    }
                    con.Close();
                }

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        }
    }
