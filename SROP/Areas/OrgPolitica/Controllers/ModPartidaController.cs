using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SROP.Areas.OrgPolitica.Controllers
{
    public class ModPartidaController : BaseController
    {

        public ActionResult Index(BE_Partida c)
        {
            return View(c);
        }

        public PartialViewResult Gets(BE_Partida c)
        {
            BL_Partida b = new BL_Partida();
            try
            {
                List<BE_Partida> r = new List<BE_Partida>();
                r = b.Gets(c);
                if (ModelState.IsValid)
                {
                    return PartialView(r.Paginar<BE_Partida>(c.NUPAGINAACTUAL));
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

        public PartialViewResult Get(BE_Partida c)
        {
            BL_Partida b = new BL_Partida();          
            try
            {
                BE_Partida i = b.Get(c);
                i.ESTADOPAGINA = c.ESTADOPAGINA;
                return PartialView(i);
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