using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SROP.Areas.OrgPolitica.Controllers.api
{

    public class EtapaApiController : BaseApiController
    {
        private bool VerificaFechaEtapaAnterior(BE_Etapa c)
        {
            BL_Etapa bEtapa = new BL_Etapa();
            BE_Etapa EtapaAnt = new BE_Etapa();
            EtapaAnt.Cod_OP = c.Cod_OP;
            try
            {
                if (c.Cod_Correlativo == 1)
                {
                    return true;
                }
                if (c.Cod_Correlativo - 1 >= 0)
                {
                    EtapaAnt.Cod_Correlativo = c.Cod_Correlativo - 1;
                    EtapaAnt = bEtapa.Get(EtapaAnt);
                    if (EtapaAnt != null)
                    {
                        if (c.Fec_Estado_Insc < EtapaAnt.Fec_Estado_Insc) { return false; }
                    }
                }
                else
                {
                    EtapaAnt = bEtapa.GetQTEtapa(EtapaAnt);
                    if (EtapaAnt != null)
                    {
                        EtapaAnt.Cod_OP = c.Cod_OP;
                        if (EtapaAnt.QTEtapa == 0) { EtapaAnt.Cod_Correlativo = 1; }
                        EtapaAnt = bEtapa.Get(EtapaAnt);
                        if (EtapaAnt != null)
                        {
                            if (c.Fec_Estado_Insc < EtapaAnt.Fec_Estado_Insc) { return false; }
                        }
                    }
                }
                return true;
            }
            finally
            {
                bEtapa.Dispose(); bEtapa = null;
                EtapaAnt = null;
            }
        }

        private bool VerificaFechaEtapaPosterior(BE_Etapa c)
        {
            BL_Etapa bEtapa = new BL_Etapa();
            BE_Etapa EtapaPost = new BE_Etapa();
            EtapaPost.Cod_OP = c.Cod_OP;
            try
            {
                if (c.Cod_Correlativo > 0)
                {
                    if (c.ESTADOPAGINA == enumEstadoPagina.Insertar)
                    { // I
                        //c.Cod_Correlativo = c.Cod_Correlativo;
                    }
                    else
                    {
                        EtapaPost.Cod_Correlativo = c.Cod_Correlativo + 1;
                    }
                    EtapaPost = bEtapa.Get(EtapaPost);
                    if (EtapaPost != null)
                    {
                        if (EtapaPost.Fec_Estado_Insc != null)
                        {
                            if (c.Fec_Estado_Insc > EtapaPost.Fec_Estado_Insc)
                            {
                                return false;
                            }
                        }
                    }

                }
                return true;
            }
            finally
            {
                bEtapa.Dispose(); bEtapa = null;
                EtapaPost = null;
            }
        }

        private bool VerificaEtapaAnteriorIgual(BE_Etapa c)
        {
            BL_Etapa bEtapa = new BL_Etapa();
            BE_Etapa EtapaAnt = new BE_Etapa();
            EtapaAnt.Cod_OP = c.Cod_OP;
            try
            {
                if (c.Cod_Correlativo == 1)
                {
                    return true;
                }
                if (c.Cod_Correlativo - 1 >= 0)
                {
                    EtapaAnt.Cod_Correlativo = c.Cod_Correlativo - 1;
                    EtapaAnt = bEtapa.Get(EtapaAnt);
                    if (EtapaAnt != null)
                    {
                        if (c.Cod_Est_Insc == EtapaAnt.Cod_Est_Insc)
                        {
                            if (c.Cod_Correlativo == 1) { }
                            else { return false; }
                        }
                    }
                }
                else if (c.Cod_Correlativo == 0)
                {
                    //EtapaAnt = bEtapa.GetQTEtapa(EtapaAnt);
                    //if (EtapaAnt != null)
                    //{
                    //    if (EtapaAnt.QTEtapa == 0) { EtapaAnt.Cod_Correlativo = 1; }
                    //    else
                    //    {
                    //        EtapaAnt.Cod_Correlativo = EtapaAnt.QTEtapa;
                    //    }
                    //}
                    //EtapaAnt.Cod_OP = c.Cod_OP;
                    //EtapaAnt = bEtapa.Get(EtapaAnt);
                    //if (EtapaAnt != null)
                    //{
                    //    if (c.Cod_Est_Insc == EtapaAnt.Cod_Est_Insc)
                    //    {
                    //        return false;
                    //    }
                    //}
                    return false;
                }
                return true;
            }
            finally
            {
                bEtapa.Dispose(); bEtapa = null;
                EtapaAnt = null;
            }
        }

        private bool VerificaEtapaPrimera(BE_Etapa c)
        {
            if (c.Cod_Correlativo == 1)
            {
                if (c.Cod_Est_Insc  != "02")
                {
                    return false;
                }
            }
            return true;
        }

        private bool EnProcesoDespuesDeInscrito(BE_Etapa c)
        {
            BL_Etapa bEtapa = new BL_Etapa();
            BE_Etapa Etapa = new BE_Etapa();
            BL_EstadoInsc bEstadoInsc = new BL_EstadoInsc();
            BE_EstadoInsc EstadoInsc = new BE_EstadoInsc();
            try
            {
                Etapa.Cod_OP = c.Cod_OP;
                if (c.Cod_Correlativo == 0)
                {
                    Etapa = bEtapa.GetQTEtapa(Etapa);
                    Etapa.Cod_OP = c.Cod_OP;
                    if (Etapa != null)
                    {
                        if (Etapa.QTEtapa == 0) { Etapa.Cod_Correlativo = 1; }
                        else
                        {
                            Etapa.Cod_Correlativo = Etapa.QTEtapa;
                        }
                    }
                    Etapa = bEtapa.Get(Etapa);
                    if (Etapa != null)
                    {
                        if (Etapa.Cod_Est_Insc == "04")
                        {
                            EstadoInsc.Cod_Estado_Inscrip = c.Cod_Est_Insc;
                            EstadoInsc = bEstadoInsc.Get(EstadoInsc);
                            if (EstadoInsc != null)
                            {
                                if ((int)EstadoInsc.FLESTADOOP == 1)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            finally
            {
                bEtapa.Dispose(); bEtapa = null;
                bEstadoInsc.Dispose(); bEstadoInsc = null;
                Etapa = null; EstadoInsc = null;
            }
        }

        private bool InsertInscritoCancelado(BE_Etapa c)
        {
            if (c.ESTADOPAGINA == enumEstadoPagina.Insertar)
            {
                if (c.Cod_Est_Insc == CO_Constante.EstadoInscripcionOPInscrito|| c.Cod_Est_Insc == CO_Constante.EstadoInscripcionOPCancelado )
                {
                    return true;
                }
            }
            return false;
        }

        private bool CambiaEtapaInscrito(BE_Etapa c)
        {
            BL_Etapa bEtapa = new BL_Etapa();
            BE_Etapa Etapa = new BE_Etapa();
            Etapa.Cod_OP = c.Cod_OP;
            if (c.Cod_Correlativo > 0)
            {
                Etapa.Cod_Correlativo = c.Cod_Correlativo;
                Etapa = bEtapa.Get(Etapa);
                if (Etapa != null)
                {
                    if (Etapa.Cod_Est_Insc == CO_Constante.EstadoInscripcionOPInscrito)
                    {
                        if (c.Cod_Est_Insc == CO_Constante.EstadoInscripcionOPInscrito)
                        {

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private BE_Etapa Setea_Variables_para_Grabar(BE_Etapa c, BL_Etapa b)
        {
            BE_Etapa x = c;
            x.MTDCODEXPEDIENTE = b.Armar_Cod_Expediente_MTD(c.MTDEXPTXPREFIJO, Glo.Text(c.MTDEXPNUANNO), Glo.Text(c.MTDEXPNUEXPEDIENTE).PadLeft(6, '0'));

            if (x.Cod_Tipo_Etapa == "02")  // Si es Proceso Inscripción, Tipo de Cancelación debe ser 00
            {
                x.Cod_Tipo_Cancel = "00";
            }
            return x;
        }

        [HttpPost]
        public IHttpActionResult Graba([FromBody] BE_Etapa c)
        {
            if (c.Cod_Est_Insc == CO_Constante.EstadoInscripcionOPCancelado && c.Cod_Tipo_Cancel.Num() == 0)
            {
                if (c.Cod_Tipo_Cancel.Num() == 0)
                {
                    msgAdvertencia("Seleccione un motivo de cancelación.");
                }
                else
                {
                    c.Cod_Tipo_Cancel = null;
                    c.Des_Num_Resol = null;
                }
            }

            if (c.Cod_Est_Insc.EsNulo()) { msgAdvertencia("Seleccione una Etapa de Inscripción..."); }

            if (VerificaFechaEtapaAnterior(c) == false) { msgAdvertencia("Fecha no puede ser menor que la de etapa anterior..."); }

            if (VerificaFechaEtapaPosterior(c) == false) { msgAdvertencia("Fecha no puede ser mayor que la de etapa posterior..."); }

            if (VerificaEtapaAnteriorIgual(c) == false) { msgAdvertencia("Etapa actual no puede ser igual a la etapa anterior..."); }

            if (VerificaEtapaPrimera(c) == false) { msgAdvertencia("Primera Etapa debe ser Solicitud en Trámite..."); }

            if (EnProcesoDespuesDeInscrito(c) == true) { msgAdvertencia("Ultima Etapa: Inscrito, no puede insertar etapa en proceso..."); }

            if (InsertInscritoCancelado(c) == true) { msgAdvertencia("Si está insertando, no puede elegir las etapas INSCRITO o CANCELADO."); }

            if (CambiaEtapaInscrito(c) == true) { msgAdvertencia("Etapa: INSCRITO, no puede cambiar la etapa."); }

            BL_Etapa b = new BL_Etapa();
            try
            {
                if (ModeloValido)
                {

                    c = Setea_Variables_para_Grabar(c, b);

                    if (c.ESTADOPAGINA == enumEstadoPagina.Insertar)
                    {
                        b.Insertar(c);

                    }
                    else if (c.ESTADOPAGINA == enumEstadoPagina.Edicion)
                    {
                        b.Actualizar(c);

                    }
                    else if (c.ESTADOPAGINA == enumEstadoPagina.Nuevo)
                    {
                        //Case "A", "N" 'Append
                       c.Cod_Correlativo=  b.Agregar(c);
                        
                    }
                    if (c.Cod_Est_Insc == "04")
                    {

                        BL_OP bOP = new BL_OP();
                        bOP.Generar_Nro_Partida(new BE_OP(c.Cod_OP));
                        msgExito("ORGANIZACION POLITICA CON INSCRIPCION DEFINITIVA");
                        
                    }
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
                b.Dispose(); b = null;
            }
        }


        [HttpPost]
        public IHttpActionResult Elimina([FromBody] BE_Etapa c)
        {
            BL_Etapa b = new BL_Etapa();
            try
            {
                b.Eliminar(c);
                return Json(new
                {
                    data = c,
                    success = true,
                    Message = CO_Constante.msgExito()
                });
                //if (r == 1)
                //{
                //    return Json(new
                //    {
                //        data = c,
                //        success = true,
                //        Message = CO_Constante.msgExito()
                //    });
                //}
                //else
                //{
                //    return Json(new
                //    {
                //        data = c,
                //        success = false,
                //        Message = CO_Constante.msgAdvertencia("Hubo problemas al eliminar la etapa")
                //    });
                //}
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
        public IHttpActionResult GetsTipoEtapa([FromUri] BE_EstadoInsc c)
        {
            BL_EstadoInsc b = new BL_EstadoInsc();
            try
            {
                List<BE_EstadoInsc> r = b.Gets(c);
                return Json(new
                {
                    data = r,
                    success = true,
                    total = r.Count
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
