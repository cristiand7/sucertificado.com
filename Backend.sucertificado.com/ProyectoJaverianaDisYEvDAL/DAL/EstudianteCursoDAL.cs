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
   public class EstudianteCursoDAL
    {
        public bool HacerCita(UserEntity user, CourseEntity courseS,string fechapresentacion)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("UPDATE  CursoEstudiante ");
            stringquery.Append("set FechaPresentacionExamen= '" + fechapresentacion + "'");

            stringquery.Append("where IdEstudiante= '" + user.IdPersona + "'");
            stringquery.Append("and IdCurso= '" + courseS.IdCurso + "'");




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
        public bool GuardarCalificacion(UserEntity user, CourseEntity courseS, double Puntaje)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("UPDATE  CursoEstudiante ");
            stringquery.Append("set PuntajeExamen= " + Puntaje + "");
         

            stringquery.Append("where IdEstudiante= '" + user.IdPersona + "'");
            stringquery.Append("and IdCurso= '" + courseS.IdCurso + "';");





            stringquery.Append("UPDATE  CursoEstudiante ");

            if (Puntaje > 3.5)
            {
                stringquery.Append("set EstadoAprovacionExamen= '" + "Aprobo" + "'");


            }
            else if (Puntaje < 3.5)
            {
                stringquery.Append("set EstadoAprovacionExamen= '" + "No Aprobo" + "'");

            }
            stringquery.Append("where IdEstudiante= '" + user.IdPersona + "'");
            stringquery.Append("and IdCurso= '" + courseS.IdCurso + "';");


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

        public bool AfiliarEstudianteacurso(UserEntity user, CourseEntity courseS)
        {
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            string fullquery = "";
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("insert into CursoEstudiante (IdCurso,IdEstudiante) values");
            stringquery.Append("('" + courseS.IdCurso + "','" + user.IdPersona+ "' )");
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

    }

}
