using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SROP.Areas.OrgPolitica.Controllers
{
    public class AsientoController : BaseController
    {
        public ActionResult Index(BE_Asiento c)
        {
            return View(c);
        }

        public PartialViewResult AsientoLista(BE_Asiento c)
        {
            BL_Asiento b = new BL_Asiento();
            try
            {
                List<BE_Asiento> r = new List<BE_Asiento>();
                r = b.Gets(c);
                if (ModelState.IsValid)
                {
                    return PartialView(r.Paginar<BE_Asiento>(c.NUPAGINAACTUAL));
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

        public PartialViewResult Mantenimiento(BE_Asiento c)
        {
            BL_Asiento b = new BL_Asiento();
            BE_Asiento i = new BE_Asiento();
            try
            {
                if (c.ESTADOPAGINA == enumEstadoPagina.Nuevo)
                {
                    i.ESTADOPAGINA = enumEstadoPagina.Nuevo;
                }
                else if (c.ESTADOPAGINA == enumEstadoPagina.Edicion)
                {
                    i = b.Get(c);
                    i.ESTADOPAGINA = enumEstadoPagina.Edicion;
                }
                return PartialView(i);
            }
            catch (Exception ex) { throw ex; }
            finally { b.Dispose(); b = null; i = null; }
        }
    }
}