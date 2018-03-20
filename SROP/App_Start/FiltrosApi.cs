using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using System.Web.Http.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Web.Routing;

namespace SROP
{
    public class FiltroApiError : ExceptionFilterAttribute //, ActionFilterAttribute
    {
        public static bool EsObjeto(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}") || input.StartsWith("[") && input.EndsWith("]");
        }

        public override void OnException(HttpActionExecutedContext ec)
        {
            string MENSAJE = ec.Exception.Message;
            string ORIGEN = ec.Exception.Source.Text();
            BE_MENSAJE m = null;
            if (MENSAJE.Contains("|"))
            {
                int NUINICIO = MENSAJE.IndexOf("|");
                int NUFINAL = MENSAJE.LastIndexOf("|");
                MENSAJE = MENSAJE.Substring(NUINICIO + 1, (NUFINAL - NUINICIO) - 1);
                //if (EsObjeto(MENSAJE))
                //{

                //}
                //else
                //{
                //    //TXMENSAJE = TXMENSAJE.Replace(@"""", "").Replace(@"/", "").Replace(@"\", "").Replace("'", "").Replace("-", "").Replace(":", " ").Replace(",", " ").Replace(".", " ").Replace("(", " ").Replace(")", " ");

                //    //TXMENSAJE = new BE_MENSAJE(4, TXMENSAJE).Serializar();
                //}

                m = new BE_MENSAJE(null, MENSAJE, enumTipoMensaje.Peligro);
            }
            else
            {
                m = new BE_MENSAJE(null, MENSAJE, enumTipoMensaje.Peligro);
                //if (EsObjeto(TXMENSAJE)==false)
                //    {
                //        TXMENSAJE = TXMENSAJE.Replace(@"""", "").Replace(@"/", "").Replace(@"\", "").Replace("'", "").Replace("-", "").Replace(":", " ").Replace(",", " ").Replace(".", " ").Replace("(", " ").Replace(")", " ");
                //        //TXMENSAJE = new BE_MENSAJE(4, TXMENSAJE).Serializar();
                //    }
                //TXMENSAJE = new BE_MENSAJE(4, TXMENSAJE).Serializar();
            }

            //var response = new
            //{
            //    Mensaje = m.Serializar()
            //};

            //context.Response = request.CreateResponse(HttpStatusCode.BadRequest, response);
            ec.Response = ec.Request.CreateErrorResponse(HttpStatusCode.BadRequest, m.Serializar());

            //context.Response = new HttpResponseMessage()
            //{
            //    Content = new StringContent(m.Serializar()),               

            //};
            BL_Error.ADD(ec.Exception);
            //base.OnException(actionExecutedContext);

            //context.Response = new JsonResult
            //{
            //    Data = new { Mensaje = m.Serializar() },
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};


        }

      
    }



    public class FiltroApiAccion : ActionFilterAttribute //, 
    {

        public override void OnActionExecuting(HttpActionContext actionContext)//, string filter
        {
            HttpContext.Current.Session[CO_Constante.VariableGlobalMensaje] = null;

            if (actionContext.ControllerContext.RouteData.Values["controller"].Text() != "UsuarioApi" &&
                actionContext.ControllerContext.RouteData.Values["action"].Text() != "GetLogin")
            {

                //BE_USUARIO i = ME.MEE();
                //if (i == null)
                //{
                //    Funciones.Advertencia("Session ha caducado",1);

                //}
            }
          
            // object d = actionContext.ActionArguments[0];
            // pre-processing
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //post-processing
        }

    }


}


