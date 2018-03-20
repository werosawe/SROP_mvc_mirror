using System.Web.Http;
using System.Web.Mvc;

namespace SROP.Areas.ExpedienteDigital
{
    public class ExpedienteDigitalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ExpedienteDigital";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.Routes.MapHttpRoute(
               name: "ExpedienteDigitalApi",
                routeTemplate: "ExpedienteDigital/api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );

            context.MapRoute(
                "ExpedienteDigital_default",
                "ExpedienteDigital/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}