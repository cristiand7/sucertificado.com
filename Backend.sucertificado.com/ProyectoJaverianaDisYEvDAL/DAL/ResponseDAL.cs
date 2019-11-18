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
   public class ResponseDAL
    {

        public bool insertQuestionResponse(ResponseEntity question)
        {
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            string fullquery = "";
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("insert into Respuesta (DescripcionRespuesta,PuntajeRespuesta,IdPregunta,RespuestaCorrecta,AreaRespuesta,TipoRespuesta,curso) values");
            stringquery.Append("('" + question.DescripcionRespuesta + "','" + question.PuntajeRespuesta + "','" + question.IdPregunta + "'," + question.RespuestaCorrecta + ",'" + question.AreaRespuesta + "','" + question.TipoRespuesta + "','" + question.curso + "' )");
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
       public List<ResponseEntity> GetResponsesFromQuestion(QuestionEntity questionResponse)
        {
            List<ResponseEntity> Responses = new List<ResponseEntity>();
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select * from REspuesta ");
            stringquery.Append("where IdPregunta= "+questionResponse.idPregunta);
            stringquery.Append("and curso= "+"'"+ questionResponse.curso + "'");
            stringquery.Append("and AreaRespuesta= " +"'"+ questionResponse.AreaPregunta+"'");

            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ResponseEntity Response = new ResponseEntity();

                        Response.IdRespuesta = dr.GetInt32(dr.GetOrdinal("IdRespuesta"));
                        Response.DescripcionRespuesta = dr.GetString((dr.GetOrdinal("DescripcionRespuesta")));
                        Response.PuntajeRespuesta = dr.GetInt32((dr.GetOrdinal("PuntajeRespuesta")));
                        Response.IdPregunta = dr.GetInt32((dr.GetOrdinal("IdPregunta")));
                        Response.RespuestaCorrecta = Convert.ToInt32(dr.GetBoolean((dr.GetOrdinal("RespuestaCorrecta"))));
                        Response.AreaRespuesta = dr.GetString((dr.GetOrdinal("AreaRespuesta")));
                        Response.TipoRespuesta = dr.GetString((dr.GetOrdinal("TipoRespuesta")));
                        Response.curso = dr.GetString((dr.GetOrdinal("curso")));


                        Responses.Add(Response);
                    }
                    con.Close();
                }
            }
            return Responses;

        }
        public List<ResponseEntity> GetResponseFromQuestionID(int questionid)
        {
            List<ResponseEntity> Responses = new List<ResponseEntity>();
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select * from REspuesta ");
            stringquery.Append("where IdPregunta= " + questionid);

            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ResponseEntity Response = new ResponseEntity();

                        Response.IdRespuesta = dr.GetInt32(dr.GetOrdinal("IdRespuesta"));
                        Response.DescripcionRespuesta = dr.GetString((dr.GetOrdinal("DescripcionRespuesta")));
                      //  Response.PuntajeRespuesta = dr.GetInt32((dr.GetOrdinal("PuntajeRespuesta")));
                        Response.IdPregunta = dr.GetInt32((dr.GetOrdinal("IdPregunta")));
                        Response.RespuestaCorrecta = Convert.ToInt32(dr.GetBoolean((dr.GetOrdinal("RespuestaCorrecta"))));
                        Response.AreaRespuesta = dr.GetString((dr.GetOrdinal("AreaRespuesta")));
                        Response.TipoRespuesta = dr.GetString((dr.GetOrdinal("TipoRespuesta")));
                        Response.curso = dr.GetString((dr.GetOrdinal("curso")));


                        Responses.Add(Response);
                    }
                    con.Close();
                }
            }
            return Responses;

        }
        public ResponseEntity GetCorrectResponseFromQuestion(QuestionEntity questionResponse)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select * from REspuesta ");
            stringquery.Append("where IdPregunta= " + questionResponse.idPregunta);
            stringquery.Append("and curso= " + "'" + questionResponse.curso + "'");
            stringquery.Append("and AreaRespuesta= " + "'" + questionResponse.AreaPregunta + "'");
            stringquery.Append("and RespuestaCorrecta= 1" );

            ResponseEntity Response = new ResponseEntity();

            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Response.IdRespuesta = dr.GetInt32(dr.GetOrdinal("IdRespuesta"));
                        Response.DescripcionRespuesta = dr.GetString((dr.GetOrdinal("DescripcionRespuesta")));
                        Response.PuntajeRespuesta = dr.GetInt32((dr.GetOrdinal("PuntajeRespuesta")));
                        Response.IdPregunta = dr.GetInt32((dr.GetOrdinal("IdPregunta")));
                        Response.RespuestaCorrecta = Convert.ToInt32(dr.GetBoolean((dr.GetOrdinal("RespuestaCorrecta"))));
                        Response.AreaRespuesta = dr.GetString((dr.GetOrdinal("AreaRespuesta")));
                        Response.TipoRespuesta = dr.GetString((dr.GetOrdinal("TipoRespuesta")));
                        Response.curso = dr.GetString((dr.GetOrdinal("curso")));


                    }
                    con.Close();
                }
            }
            return Response;

        }
    }
}
