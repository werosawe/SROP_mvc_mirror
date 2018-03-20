using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SROP.Areas.OrgPolitica.Controllers
{
    public partial class  EtapaController : BaseController
    {       
        public ActionResult Index(BE_Etapa c)
        {
            return View(c);
        }

        public PartialViewResult EtapasLista(BE_Etapa c)
        {
            BL_Etapa b = new BL_Etapa();
            try
            {
                List<BE_Etapa> r = new List<BE_Etapa>();
                r = b.Gets(c);
                if (ModelState.IsValid)
                {
                    return PartialView(r.Paginar<BE_Etapa>(c.NUPAGINAACTUAL));
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

        public PartialViewResult Mantenimiento(BE_Etapa c)
        {
            BL_Etapa b = new BL_Etapa();
            BE_Etapa i = new BE_Etapa();
            try
            {               
                i = b.GetQTEtapa(c);
                if (c.ESTADOPAGINA == enumEstadoPagina.Nuevo)
                {
                    i.Cod_Ente = Yoo.CodEnte;
                    i.Cod_Est_Insc = CO_Constante.EstadoInscripcionOPInscrito;
                    i.Cod_Correlativo = i.Cod_Correlativo + 1;
                    i.MTDEXPNUANNO = DateTime.Now.Year;
                    //Primera etapa
                    if (i.QTEtapa == 0) { i.Cod_Tipo_Etapa = "02"; }
                    i.ESTADOPAGINA = enumEstadoPagina.Nuevo;
                }
                else if (c.ESTADOPAGINA == enumEstadoPagina.Edicion)
                {
                    i = b.Get(c); 
                    i.ESTADOPAGINA = enumEstadoPagina.Edicion;
                }
                else if (c.ESTADOPAGINA == enumEstadoPagina.Insertar)
                {

                    i = b.Get(c);
                    i.Cod_Correlativo = i.Cod_Correlativo ;
                    i.MTDEXPNUANNO = DateTime.Now.Year;

                    //i.Cod_Ente = Yoo.CodEnte;
                    //i.Cod_Est_Insc = CO_Constante.EstadoInscripcionOPInscrito;
                    //i.Cod_Correlativo = i.Cod_Correlativo + 1;
                    //i.MTDEXPNUANNO = DateTime.Now.Year;

                    i.ESTADOPAGINA = enumEstadoPagina.Insertar;
                }
                return PartialView(i);
            }
            catch (Exception ex) { throw ex; }
            finally { b.Dispose(); b = null; i = null; }
        }




    }
}