using ProyectoJaverianaDisYEvEntities.Entities;
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
    public class UserDAL
    {
        public UserEntity LoginUser(string username,string password)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select * from Persona ");
            stringquery.Append("where Usuario= '" + username+"'");
            stringquery.Append("and Contrasenia= " + "'" + password + "'");

            bool login = false;
            UserEntity User = new UserEntity();

            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        User.IdPersona = dr.GetInt32(dr.GetOrdinal("IdPersona"));
                        User.nombre = dr.GetString((dr.GetOrdinal("Nombre")));
                        User.apellido = dr.GetString((dr.GetOrdinal("Apellido")));
                        User.rol = dr.GetString((dr.GetOrdinal("Rol")));
                        User.PuntajeGlobal = dr.GetInt32((dr.GetOrdinal("PuntajeGlobal")));
                        User.grupo = dr.GetString((dr.GetOrdinal("Grupo")));
                        User.Usuario = dr.GetString((dr.GetOrdinal("Usuario")));
                        User.documento = dr.GetString((dr.GetOrdinal("Documento")));

                        User.Contrasenia = dr.GetString((dr.GetOrdinal("Contrasenia")));
                        login = true;



                    }
                    con.Close();
                }
            }
            return User;

        }
        public UserEntity GetUser(string username, string Documento)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection("Server= arquisqlserver.database.windows.net; Database= arquitectura;User Id=arquisqlserver;Password = arquitectura2019!;"); int i = 0;
            //insert the information to the database
            StringBuilder stringquery = new StringBuilder();
            stringquery.Append("select * from Persona ");
            stringquery.Append("where Usuario= '" + username + "'");
            stringquery.Append("and Documento= " + "'" + Documento + "'");

            bool login = false;
            UserEntity User = new UserEntity();

            SqlCommand cmd = new SqlCommand(stringquery.ToString(), con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        User.IdPersona = dr.GetInt32(dr.GetOrdinal("IdPersona"));
                        User.nombre = dr.GetString((dr.GetOrdinal("Nombre")));
                        User.apellido = dr.GetString((dr.GetOrdinal("Apellido")));
                        User.rol = dr.GetString((dr.GetOrdinal("Rol")));
                        User.PuntajeGlobal = dr.GetInt32((dr.GetOrdinal("PuntajeGlobal")));
                        User.grupo = dr.GetString((dr.GetOrdinal("Grupo")));
                        User.Usuario = dr.GetString((dr.GetOrdinal("Usuario")));
                        User.documento = dr.GetString((dr.GetOrdinal("Documento")));

                        User.Contrasenia = dr.GetString((dr.GetOrdinal("Contrasenia")));
                        login = true;



                    }
                    con.Close();
                }
            }
            return User;

        }
    }
}
