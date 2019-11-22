using ProyectoJaverianaDisYEvDAL.DAL;
using ProyectoJaverianaDisYEvEntities.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvBL.BL
{
    public class UserBL
    {

        public UserEntity LoginUser(string username, string password)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.LoginUser(username, password);

        }
        public UserEntity GetUser(string username, string Documento)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.GetUser(username, Documento);
        }


    }
}
