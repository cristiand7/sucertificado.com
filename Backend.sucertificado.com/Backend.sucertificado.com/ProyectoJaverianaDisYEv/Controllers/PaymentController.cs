using ProyectoJaverianaDisYEvBL.BL;
using ProyectoJaverianaDisYEvEntities.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProyectoJaverianaDisYEv.Controllers
{
    [RoutePrefix("api/payment")]
    [EnableCors(origins: "http://sucertificado.centralus.cloudapp.azure.com:8080/", headers: "*", methods: "*")]
    public class PaymentController : ApiController
    {

        [HttpPost]
        [AllowCrossSiteJsonAttribute]
        [ActionName("RealizarPago")]
        [Route("RealizarPago")]
        public bool RealizarPago([FromBody] MakePaymentEntity payment)
        {
            MainLogicBL operation = new MainLogicBL();
            
            return operation.RealizarPago(payment);
        }
    }
}
