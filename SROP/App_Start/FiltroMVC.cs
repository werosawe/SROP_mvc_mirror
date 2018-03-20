using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace SROP
{
    public class FiltroMVC : ActionFilterAttribute, IExceptionFilter, IActionFilter, IRequiresSessionState
    {
        void IExceptionFilter.OnException(ExceptionContext ec)
        {
            int STATUSCODE = new HttpException(null, ec.Exception).GetHttpCode();
            string MENSAJE = ec.Exception.Message;
            string ORIGEN = ec.Exception.Source.Text() + " - " + ec.Exception.TargetSite.ToString();
            if (ec.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                BE_MENSAJE m = null;
                if (ORIGEN != null)
                {
                    if (ORIGEN.Minuscula().Contains("oracle"))
                    {
                        int NU_INICIAL = MENSAJE.IndexOf("[");
                        int NU_FINAL = MENSAJE.IndexOf("]");
                        if (NU_INICIAL > 0 & NU_FINAL > 0)
                        {
                            MENSAJE = MENSAJE.Substring(NU_INICIAL, (NU_FINAL - NU_INICIAL) + 1) + ", Status Code = " + STATUSCODE;
                        }
                        m = new BE_MENSAJE(null, MENSAJE, enumTipoMensaje.Peligro);
                    }
                    else
                    {
                        m = new BE_MENSAJE(null, string.Concat(ORIGEN, ": ", MENSAJE, ", Status Code = ", STATUSCODE), enumTipoMensaje.Peligro);
                    }
                }

                ec.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet, //Not necessary for this example
                    Data = new
                    {
                        success = false,
                        error = true,
                        Message = m.Serializar()
                    }
                };

                ec.ExceptionHandled = true;
                ec.HttpContext.Response.Clear();
                ec.HttpContext.Response.StatusCode = STATUSCODE;
                ec.HttpContext.Response.TrySkipIisCustomErrors = true;

                //ec.ExceptionHandled = true;
                //ec.Result = new JsonResult
                //{
                //    Data = new { success = false, error = true, Message = m.Serializar() },
                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                //};
            }
            else
            {
                List<BE_MENSAJE> r = new List<BE_MENSAJE>();
                if (HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje] != null) { r = HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje].Text().DesSerializarLista<BE_MENSAJE>(); }
                r.Add(new BE_MENSAJE("", ec.Exception.Message, enumTipoMensaje.Peligro));
                HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje] = r.Serializar();


                ec.ExceptionHandled = true;
                ec.Result = new ViewResult()
                {
                    ViewName = ec.RouteData.Values["action"].Text(),
                    // MasterName = Master,new ViewDataDictionary<HandleErrorInfo>(model)
                    //ViewData = d,
                    TempData = ec.Controller.TempData
                };

            }

            BL_Error.ADD(ec.Exception);

            //ec.HttpContext.Response.Clear();
            //ec.HttpContext.Response.StatusCode = 500;
            //ec.HttpContext.Response.TrySkipIisCustomErrors = true;
        }

        //public FiltroMVC(string _ACCION = null, string _CONTROLADOR = null, bool _IR_A_VISTA_GENERICA = false)
        //{
        //    CONTROLADOR = _CONTROLADOR;
        //    ACCION = _ACCION;
        //    IR_A_VISTA_GENERICA = _IR_A_VISTA_GENERICA;
        //}

        //void OnActionExecuting(ActionExecutingContext filterContext);
        //void OnActionExecuted(ActionExecutedContext filterContext);

        //public void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    throw new NotImplementedException();
        //}


        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (something == true)
        //        filterContext.Result = RedirectToAction("DoSomething", "Section");
        //    else
        //        base.OnActionExecuting(filterContext);
        //}

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {

            // Ver despues como ponerlo en otro evento para que no se borre antes de tener que msotrar

            //filterContext.HttpContext.Session[CO_Constante.NO_VARIABLE_GLOBAL_MENSAJE] = null;

            string TXCONTROLADOR = filterContext.RouteData.Values["Controller"].Text();
            string TXACCION = filterContext.RouteData.Values["Action"].Text();
            if (PaginasExceptuadas(TXCONTROLADOR, TXACCION)) { return; }

            ////**//
            //BE_USUARIO Usuario = new BE_USUARIO();
            //BL_PAGINA b = new BL_PAGINA();
           
            //        Usuario.UserName = "admin";
            //        Usuario.UserId = "admin";
            //        Usuario.NombreUsuario = "Admintardore djsjjss";
            //        Usuario.Paginas = b.GetsActivo(new BE_PAGINA());
            //        Yoo.Yo(Usuario.Serializar());

            ////**//

            BE_USUARIO yo = Yoo.Yo();
            if (yo != null)
            {
                //Verificar paginas exceptuadas
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{
                    { "controller", "Account" },
                    { "action", "Login" },
                    { "area","" }
                });
            }
            //base.OnActionExecuting(filterContext);
        }

        private bool PaginasExceptuadas(string TXCONTROLADOR, string TXACCION)
        {
            List<PP> r = new List<PP>();
            r.Add(new PP("Account", "Login"));
            r.Add(new PP("Account", "LoginVerifica"));
            r.Add(new PP("Account", "Salir"));
            r.Add(new PP("Account", "Inicio"));
            r.Add(new PP("Account", "AcercaDe"));
            r.Add(new PP("Account", "PaginaIncorrecta"));
            r.Add(new PP("Manage", "*"));

            PP obj = r.Find(x => x.TXCONTROLADOR == TXCONTROLADOR && (x.TXACCION == "*" || x.TXACCION == TXACCION));
            if (obj == null)
            {
                return false;
            }
            else { return true; }
        }

    }


    public class PP
    {
        private string _TXCONTROLADOR;
        private string _TXACCION;
        public string TXCONTROLADOR { get { return _TXCONTROLADOR; } set { _TXCONTROLADOR = value; } }
        public string TXACCION { get { return _TXACCION; } set { _TXACCION = value; } }
        public PP(string __TXCONTROLADOR, string __TXACCION)
        {
            _TXCONTROLADOR = __TXCONTROLADOR;
            _TXACCION = __TXACCION;
        }
    }

}

