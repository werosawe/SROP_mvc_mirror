using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SROP.Areas.OrgPolitica.Controllers
{
    public class SintesisController : Controller
    {
        public ActionResult Mantenimiento(BE_Sintesis c)
        {
            BL_Sintesis b = new BL_Sintesis();
            try
            {
                ViewBag.Cod_OP = c.Cod_OP;               
                BE_Sintesis i = b.Get(c);
                if (i == null) { ViewBag.ValorNuloSintesis = "En la Dirección Nacional de Registro de Organizaciones Políticas del Jurado Nacional de Elecciones, en cumplimiento del artículo 17° de la Ley de Organizaciones Políticas, Ley N° 28094 y los artículos 23°, 25°, 26°, 27°, 28°, 29° y 30° del Reglamento del Registro de Organizaciones Políticas, aprobado por Resolución N° 208-2015-JNE, pone en conocimiento de la ciudadanía que, con fecha DÍA de MES de AÑO se ha presentado ante esta unidad orgánica el/los señor/es ……………………………………………………, personero legal (Titular/Alterno) del (Partido Político, Movimiento Regional, Organización Política Local, Alianza Electoral o Fusión) …………………, ……DETALLAR ÁMBITO DE SER EL CASO ……, solicitando la inscripción de la referida organización política, alianza electoral o fusuión en el registro especial que conduce el Registro de Organizaciones Políticas. Para ello ha acreditado el cumplimiento de los requisitos señalados en el artículo 17 de la referida Ley, cuya síntesis es la siguiente:"; }
                return View(i);
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



        public async Task<ActionResult> GetSimbolo(BE_Sintesis c)
        {
            return await Task.Run(() =>
            {
                BL_Sintesis b = new BL_Sintesis();
                BE_Sintesis i = new BE_Sintesis();
                try
                {
                    i = b.GetSimbolo(c);
                    byte[] img = null;
                    if (i != null)
                    {
                        img = i.BLARCHIVO;
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