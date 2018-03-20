using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SROP.Controllers.api
{
    public class FuncionesApiController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetFecha([FromUri] BE_PARAMETRO_FORMATOFECHA c)//(int CO_GRUPO)
        {
            string f = c.TXFECHAENTRADA;
            try {
                return Json(new
                {
                    data = f.fecha(c),
                    success = true,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
