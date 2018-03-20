using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
namespace SROP.Controllers.api
{
    public class RequisitoApiController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Gets([FromUri] BE_ReqTipoOP c)
        {
            BL_ReqTipoOP b = new BL_ReqTipoOP();
            List<BE_ReqTipoOP> r = b.Listar_RequisitoTipo_OP(c);
            try
            {
                if (c.Cod_Tipo_OP == "01")
                {
                    c.Tipo_Libro = "1";
                    c.Cod_Ambito = "01";
                }
                else if (c.Cod_Tipo_OP == "02")
                {
                    c.Tipo_Libro = "2";
                    c.Cod_Ambito = "02";
                }
                else if (c.Cod_Tipo_OP == "03" || c.Cod_Tipo_OP == "04")
                {
                    c.Tipo_Libro = "3";
                    c.Cod_Ambito = "03";
                }
                else if (c.Cod_Tipo_OP == "05")
                {
                    c.Tipo_Libro = "4";
                    c.Cod_Ambito = "04";
                }
                return Json(new
                {
                    data = r,
                    data2 = c,
                    total = r.Count,
                    success = true,
                    TXMENSAJE = CO_Constante.menMuestranRegistros
                });
            }
            finally
            {
                b.Dispose(); b = null;
            }
        }

    }
}
