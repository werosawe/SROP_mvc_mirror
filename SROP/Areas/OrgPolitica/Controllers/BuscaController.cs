using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SROP.Areas.OrgPolitica
{
    public class BuscaController : BaseController
    {
        // GET: OrgPolitica/Busqueda
        public ActionResult Index(BE_BusquedaOP c)
        {
            return View(c);
        }

        public PartialViewResult OrganizacionPoliticaLista(BE_BusquedaOP c)
        {
            BE_BusquedaOP paramOP = new BE_BusquedaOP();
            BL_BusquedaOP b = new BL_BusquedaOP();
            try
            {
                paramOP.Des_OP = c.Des_OP.Text();
                paramOP.ID_Asistente = c.ID_Asistente;
                paramOP.Cod_Tipo_OP = c.Cod_Tipo_OP;
                paramOP.ID_EstadoOP = c.ID_EstadoOP;

                BE_BusquedaOP.FecEstado paramFec;
                paramFec.FecIni = c.FEINICIAL;
                paramFec.FecFin = c.FEFINAL;

                List<BE_BusquedaOP> r = new List<BE_BusquedaOP>();
                r = b.BusquedaOP_x_Parametros(paramOP, paramFec, r);             
                r = Filtra_Por_Departamento(r);

                //int o = int.Parse("dd");
                if (ModeloValido)
                {
                    return PartialView(r.Paginar<BE_BusquedaOP>(c.NUPAGINAACTUAL));
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
                paramOP.Dispose(); paramOP = null;
            }
        }

        public List<BE_BusquedaOP> Filtra_Por_Departamento(List<BE_BusquedaOP> r)
        {
            //Dim LISTA As New List(Of BE_BusquedaOP)
            BE_USUARIO USUARIO = new BE_USUARIO();
            BL_USUARIO b = new BL_USUARIO();
            try
            {
                USUARIO.UserId = Yoo.UserId;
                USUARIO = b.GetDatos_User(USUARIO);
                if (Funciones.Es_Registrador_Provincia(USUARIO.CodPerfil))
                {
                    r = b.Filtra_OP_Por_Departamento(r, USUARIO);
                }
                return r;
            }          
            finally { b.Dispose(); b = null; USUARIO.Dispose(); USUARIO = null; }
        }

    }
}