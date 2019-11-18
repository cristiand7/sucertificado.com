using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvDAL.DAL
{
   public  class StudenExamDAL
    {

        public bool AfiliarEstudianteaExamen(int  userid, int examid)
        {
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            
            string fullquery = "";
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("insert into EstudianteExamen (IdEstudiante,IdExamen) values");
            stringquery.Append("('" + userid + "','" + examid + "' )");
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
       public bool PagarCurso(int userid, int examid)
        {

            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
           
            string fullquery = "";
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("UPDATE  EstudianteExamen ");
            stringquery.Append("set Pago= 1" );


            stringquery.Append("where IdEstudiante= '" + userid + "'");
            stringquery.Append("and idexamen= '" + examid + "';");
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
        public bool HacerCitaExamen(int userid, int examid,string fecha)
        {
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
           
            string fullquery = "";
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("UPDATE  EstudianteExamen ");
            stringquery.Append("set FechaExamen= '" + fecha + "'");



            stringquery.Append(" where IdEstudiante= '" + userid + "'");
            stringquery.Append(" and Pago= 1 ");

            stringquery.Append(" and IdExamen= '" + examid + "';");
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
        public bool GuardarCalificacion(int user, int examn, double Puntaje)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("UPDATE  estudianteexamen ");
            stringquery.Append("set PuntajeExamen= " + Puntaje + "");


            stringquery.Append("where IdEstudiante= '" + user + "'");
            stringquery.Append("and IdExamen= '" + examn + "';");





            stringquery.Append("UPDATE  [EstudianteExamen] ");

            if (Puntaje > 3.5)
            {
                stringquery.Append("set AprobacionExamen= '" + "Aprobo" + "'");


            }
            else if (Puntaje < 3.5)
            {
                stringquery.Append("set AprobacionExamen= '" + "No Aprobo" + "'");

            }
            stringquery.Append("where IdEstudiante= '" + user + "'");
            stringquery.Append("and IdExamen= '" + examn + "';");


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
    }
}
