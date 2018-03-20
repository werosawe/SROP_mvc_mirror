using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace SROP.Areas.OrgPolitica
{
    public class InscripcionController :  BaseController
    {
       
        public ActionResult Nuevo(BE_OP c)
        {
            return View();
        }

        public ActionResult Expediente(BE_OP c)
        {
            BL_OP b = new BL_OP();
            BE_OP i = null;
            try
            {
                if (c.ESTADOPAGINA== enumEstadoPagina.Edicion) {
                    i = b.Obtener_OP_Completa(c);
                    i.ESTADOPAGINA = c.ESTADOPAGINA;                    
                }
                else if (c.ESTADOPAGINA == enumEstadoPagina.Nuevo)
                {
                    i = c;
                }
                return View(i);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b.Dispose(); b = null;
                //i.Dispose(); i = null;
            }
        }


        private void pGrabarPrimeraEtapa(BE_OP c)
        {
            BL_Etapa b = new BL_Etapa();
            BE_Etapa i = new BE_Etapa();
            try
            {
                i.Cod_OP = c.Cod_OP;
                i.Cod_Correlativo = 0;
                i.Cod_Tipo_Etapa = "02";
                i.Fec_Estado_Insc = DateTime.Now;
                i.Cod_Est_Insc = "02";
                i.Cod_Ente = Yoo.CodEnte;
                i.Des_Observ = c.Observaciones;
                b.Agregar(i);
            }
            finally
            {
                b.Dispose(); b = null;
            }
        }


        public ActionResult ExpedienteGraba(BE_OP c)
        {
            BL_OP b = new BL_OP();
            GrabaBlobABaseDatosDesdeCarpetaTemporal bAdjunto = new GrabaBlobABaseDatosDesdeCarpetaTemporal();
            try
            {
                if (c.TXARCHIVONOMBRE.Text().Equals("0") || c.TXARCHIVONOMBRE.EsNulo())
                {
                    msgAdvertencia("Ingrese simbolo");
                }

                if (ModeloValido)
                {
                    c = b.Agregar(c);
                    if (!c.TXARCHIVONOMBRE.Text().Equals("1"))
                    {
                        bAdjunto.Simbolo(c);
                    }
                    pGrabarPrimeraEtapa(c);
                    c.TABEXPEDIENTE = enumTabExpediente.Etapa;
                    c.ESTADOPAGINA = enumEstadoPagina.Edicion;

                    msgExito("Se grabó el expediente, así como la primera etapa de inscripción. ");
                    //return View(Url.Action("Index", "Etapa", new { area = "OrgPolitica" }), new BE_Etapa(c.Cod_OP));                   
                }
                return View("OrganizacionPolitica", c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b.Dispose(); b = null;
                bAdjunto.Dispose(); bAdjunto = null;
            }
        }

        public ActionResult ExpedienteEdita(BE_OP c)
        {
            BL_OP b = new BL_OP();
            GrabaBlobABaseDatosDesdeCarpetaTemporal bAdjunto = new GrabaBlobABaseDatosDesdeCarpetaTemporal();
            try
            {
                if (c.TXARCHIVONOMBRE.Text().Equals("0") || c.TXARCHIVONOMBRE.EsNulo())
                {
                    msgAdvertencia("Ingrese simbolo");
                }
                if (ModeloValido)
                {
                    b.Editar(c);
                    if (!c.TXARCHIVONOMBRE.Text().Equals("1"))
                    {
                        bAdjunto.Simbolo(c);
                    }                   
                    c.TABEXPEDIENTE = enumTabExpediente.Expediente;
                    msgExito("Se actualizo el expediente");
                    //return View(Url.Action("Index", "Etapa", new { area = "OrgPolitica" }), new BE_Etapa(c.Cod_OP));
                }
                return View("OrganizacionPolitica", c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b.Dispose(); b = null;
                bAdjunto.Dispose(); bAdjunto = null;
            }
        }

        public ActionResult OrganizacionPolitica(BE_OP c)
        {
            BL_OP b = new BL_OP();
            BE_OP i = null;
            try
            {
                if (c.ESTADOPAGINA== enumEstadoPagina.Edicion) {
                    //i = b.Obtener_OP_Selecc(c);
                    i = b.Obtener_OP_Selecc(c);
                    i.TABEXPEDIENTE = c.TABEXPEDIENTE;
                    i.ESTADOPAGINA = c.ESTADOPAGINA;
                }
                else if (c.ESTADOPAGINA == enumEstadoPagina.Nuevo) { i = c; }
                return View(i);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b.Dispose(); b = null;
                i.Dispose(); i = null;
            }
        }

        public async Task<ActionResult> GetSimbolo(BE_OP c)
        {
            return await Task.Run(() =>
            {
                BL_OP b = new BL_OP();
                BE_OP i = new BE_OP();
                try
                {
                    i = b.GetSimbolo(c);
                    byte[] img = null;
                    if (i != null)
                    {
                        img = i.Img_Simbolo_Op;
                        return File(img, "image/jpg");
                    }
                    else
                    {
                        using (var ms = new MemoryStream())
                        {
                            Funciones.DibujaTexto("Sin Logo", new Font("Arial", 12.0f), Color.Black, Color.White).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            return File(ms.ToArray(), "image/jpg");
                        }
                    }
                }
                finally
                {
                    b.Dispose(); b = null;
                    i = null;
                }
            });
        }
    }
}