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
     public class ExamDAL
    {
        public ExamEntity getexambyname(string name, int numPreguntas)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select  * from Examen ");
            stringquery.Append("where NombreExamen= '" + name + "'");


            ExamEntity Exam = new ExamEntity();


            string query = stringquery.ToString();
            SqlCommand cmd = new SqlCommand(query, con);

          
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Exam.idexamen=dr.GetInt32(dr.GetOrdinal("IdExamen"));
                        Exam.nombre = dr.GetString((dr.GetOrdinal("NombreExamen")));
                        Exam.areaexamen = dr.GetString((dr.GetOrdinal("AreaExamen")));



                    }
                    con.Close();
                
            }
            return Exam;
        }
    }
}
