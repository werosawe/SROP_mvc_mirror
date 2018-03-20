using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SROP.Areas.OrgPolitica.Controllers.api
{

    public class SintesisApiController : BaseApiController
    {

        [HttpPost]
        public IHttpActionResult Graba([FromBody] BE_Sintesis c)
        {
            BL_Sintesis bSintesis = new BL_Sintesis();
            BL_OP bOP = new BL_OP();
            try
            {
                if (ModeloValido)
                {
                    int fl = bSintesis.Modificar(c);
                    BE_OP OP = bOP.GetDatosTipo(new BE_OP(c.Cod_OP));
                    if (OP != null && fl==1)
                    {
                        if ((int)OP.FLSIMBOLO == 1)
                        {
                            OP = bOP.GetSimbolo(new BE_OP(c.Cod_OP));
                            if (OP != null)
                            {
                                c.BLARCHIVO = OP.Img_Simbolo_Op;
                                bSintesis.GuardarSimbolo(c);
                            }
                        }
                    }
                    return Json(new
                    {
                        data = c,
                        success = fl == 1 ? true : false,
                        Message = fl == 1 ? CO_Constante.msgExito("Se guardo la Sintesis") : CO_Constante.msgAdvertencia("Hubo un problema al registrar la Sintesis")
                    });
                }
                else
                {
                    return Json(new
                    {
                        data = c,
                        success = false,
                        Message = Mensajee()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bSintesis.Dispose(); bSintesis = null;
                bOP.Dispose(); bOP = null;
            }
        }    

        [HttpPost]
        public IHttpActionResult Elimina([FromBody] BE_Sintesis c)
        {
            BL_Sintesis b = new BL_Sintesis();
            try
            {
                b.Eliminar(c);
                return Json(new
                {
                    data = c,
                    success = true,
                    Message = CO_Constante.msgExito("Se elimino la sintesis")
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b.Dispose(); b = null;
            }
        }

        [HttpGet]
        public IHttpActionResult GetDato([FromUri] BE_Sintesis c)
        {
            BL_Sintesis b = new BL_Sintesis();
            try
            {
                BE_Sintesis i = b.ObtenerDatos_Para_Sintesis(c);
                return Json(new
                {
                    data = i,
                    success = i != null ? true : false,                 
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b.Dispose(); b = null;
            }
        }

    }

}
