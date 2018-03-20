using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace SROP.Areas.OrgPolitica.Controllers
{
    public class EstatutoController : BaseController
    {
        public ActionResult Index(BE_Estatuto c)
        {
            return View(c);
        }

        public PartialViewResult EstatutoLista(BE_Estatuto c)
        {
            BL_Estatuto b = new BL_Estatuto();
            try
            {
                List<BE_Estatuto> r = new List<BE_Estatuto>();
                r = b.Gets(c);
                if (ModelState.IsValid)
                {
                    return PartialView(r.Paginar<BE_Estatuto>(c.NUPAGINAACTUAL));
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

        public PartialViewResult Mantenimiento(BE_Estatuto c)
        {
            BL_Estatuto b = new BL_Estatuto();
            BE_Estatuto i = new BE_Estatuto();
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