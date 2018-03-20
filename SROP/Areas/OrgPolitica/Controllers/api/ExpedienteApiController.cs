using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SROP.Areas.OrgPolitica.Controllers.api
{
    public class ExpedienteApiController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Bloqueo([FromBody] BE_OP c)
        {
            BL_OP b = new BL_OP();
            try
            {
                if ((int) c.FLCANDADO == 1) { c.FLCANDADO = 0; } else { c.FLCANDADO = 1; }
                int r = b.Bloquear_OP(c);
                if (r == 1)
                {
                    return Json(new
                    {
                        data = c,
                        success = true,
                        Message = CO_Constante.msgExito()
                    });
                }
                else
                {
                    return Json(new
                    {
                        data = c,   
                        success = false,
                        Message = CO_Constante.msgAdvertencia("Hubo problemas al actualizar el bloqueo")
                    });
                }
            }catch (Exception ex) {
                throw ex;
            }
            finally {
                b.Dispose();b = null;
            }
        }

    }

    
}
