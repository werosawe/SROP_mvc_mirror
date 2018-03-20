using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SROP.Areas.OrgPolitica.Controllers
{
    public class ResolucionController : BaseController
    {
        public ActionResult Index(BE_Resolucion c)
        {
            return View(c);
        }

        public PartialViewResult ResolucionLista(BE_Resolucion c)
        {
            BL_Resolucion b = new BL_Resolucion();
            try
            {
                List<BE_Resolucion> r = new List<BE_Resolucion>();
                r = b.Listar_Resoluciones(c);
                if (ModelState.IsValid)
                {
                    return PartialView(r.Paginar<BE_Resolucion>(c.NUPAGINAACTUAL));
                }
                else
                {
                    return Mensajee();
                }
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

        public PartialViewResult Mantenimiento(BE_Resolucion c)
        {
            BL_Resolucion b = new BL_Resolucion();
            BE_Resolucion i = new BE_Resolucion();
            try
            {
                if (c.ESTADOPAGINA == enumEstadoPagina.Nuevo)
                {
                    i.ESTADOPAGINA = enumEstadoPagina.Nuevo;
                }
                else if (c.ESTADOPAGINA == enumEstadoPagina.Edicion)
                {
                    i = b.Obtener_Resolucion(c);
                    i.ESTADOPAGINA = enumEstadoPagina.Edicion;
                }
                return PartialView(i);
            }
            catch (Exception ex) { throw ex; }
            finally { b.Dispose(); b = null; i = null; }
        }

    }
}