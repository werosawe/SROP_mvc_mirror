using System.Web.Http;
using System.Web.Mvc;

namespace SROP.Areas.Archivo
{
    public class ArchivoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Archivo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapHttpRoute(
               name: "ArchivoApi",
                routeTemplate: "Archivo/api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            context.MapRoute(
                "Archivo_default",
                "Archivo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}