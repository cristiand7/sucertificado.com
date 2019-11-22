using ProyectoJaverianaDisYEv.Models;
using ProyectoJaverianaDisYEvBL.BL;
using ProyectoJaverianaDisYEvEntities.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoJaverianaDisYEv.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    [EnableCors(origins: "http://sucertificado.centralus.cloudapp.azure.com:8080/", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            MainLogicBL mainLogicBL = new MainLogicBL();
            UserEntity user = mainLogicBL.LoginUser(login.username, login.password);
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            bool isCredentialValid = (login.password == user.Contrasenia);
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.username);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    
}
}
