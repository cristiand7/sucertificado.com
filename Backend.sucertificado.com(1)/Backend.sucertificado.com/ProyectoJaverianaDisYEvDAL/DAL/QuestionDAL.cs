using ProyectoJaverianaDisYEvEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvDAL.DAL
{
 public    class QuestionDAL
    {
        public bool insertQuestion(QuestionEntity question)
        {
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("insert into Pregunta (DescripcionPregunta,TipoPregunta,AreaPregunta,PuntajeMaximo,curso) values ");
            stringquery.Append("('" + question.descripcionPregunta + "','" + question.TipoPregunta + "','" + question.AreaPregunta + "'," + question.PuntajeMaximo + ",'" + question.curso + "')");

            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

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
            public List<QuestionEntity> GetquestionWithResponses(string course, string area, int questionnumber)
            {
            List<QuestionEntity> questions = new List<QuestionEntity>();
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select top("+ questionnumber+") * from  Pregunta  ");
            stringquery.Append("where AreaPregunta= '"+area+"' and curso= '"+ course+"'");
            stringquery.Append("ORDER BY RAND()  ");



            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        QuestionEntity question = new QuestionEntity();

                        question.idPregunta = dr.GetInt32(dr.GetOrdinal("IdPregunta"));
                        question.descripcionPregunta = dr.GetString((dr.GetOrdinal("DescripcionPregunta")));
                        question.TipoPregunta = dr.GetString((dr.GetOrdinal("TipoPregunta")));
                        question.AreaPregunta = dr.GetString((dr.GetOrdinal("AreaPregunta")));
                        question.PuntajeMaximo = dr.GetInt32((dr.GetOrdinal("PuntajeMaximo")));
                        question.curso = dr.GetString((dr.GetOrdinal("curso")));

                        questions.Add(question);
                    }
                }
                con.Close();
            }
            return questions;

        }


        public QuestionEntity Getstudentquestions(string course, string area,string Description)
        {
            List<QuestionEntity> questions = new List<QuestionEntity>();
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select *  from  Pregunta  ");
            stringquery.Append("where AreaPregunta= '" + area + "' and curso= '" + course + "'"+ "and DescripcionPregunta= '"+Description+"'" );
            QuestionEntity question = new QuestionEntity();



            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        question.idPregunta = dr.GetInt32(dr.GetOrdinal("IdPregunta"));
                        question.descripcionPregunta = dr.GetString((dr.GetOrdinal("DescripcionPregunta")));
                        question.TipoPregunta = dr.GetString((dr.GetOrdinal("TipoPregunta")));
                        question.AreaPregunta = dr.GetString((dr.GetOrdinal("AreaPregunta")));
                        question.PuntajeMaximo = dr.GetInt32((dr.GetOrdinal("PuntajeMaximo")));
                        question.curso = dr.GetString((dr.GetOrdinal("curso")));

                    }
                }
                con.Close();
            }
            return question;

        }

        public List<QuestionEntity> GetQuestionsByExamID(int ExamID, int numpreguntas)
        {
            List<QuestionEntity> questions = new List<QuestionEntity>();
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select top(" + numpreguntas + ") * from  Pregunta  ");
            stringquery.Append("where ExamenId= '" + ExamID +"'" );
            stringquery.Append(" ORDER BY RAND()  ");




            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        QuestionEntity question = new QuestionEntity();

                        question.idPregunta = dr.GetInt32(dr.GetOrdinal("IdPregunta"));
                        question.descripcionPregunta = dr.GetString((dr.GetOrdinal("DescripcionPregunta")));
                        question.TipoPregunta = dr.GetString((dr.GetOrdinal("TipoPregunta")));
                        question.AreaPregunta = dr.GetString((dr.GetOrdinal("AreaPregunta")));
                       // question.PuntajeMaximo = dr.GetInt32((dr.GetOrdinal("PuntajeMaximo")));
                        question.curso = dr.GetString((dr.GetOrdinal("curso")));
                        questions.Add(question);
                    }
                }
                con.Close();
            }
            return questions;

        }

        public string MakeStringOfUsedQUestionNumbers(List<int> idquestions)
        {
            string values = "";
            
            foreach(int n in idquestions)
            {
                values+=""+n+",";

            }
            values.Substring(0, values.Length - 1);
            return values;
        }
    }
}
