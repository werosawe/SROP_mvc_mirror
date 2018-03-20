using System.Web.Http;
using System.Web.Mvc;

namespace SROP.Areas.Consulta
{
    public class ConsultaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Consulta";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.Routes.MapHttpRoute(
               name: "ConsultaApi",
                routeTemplate: "Consulta/api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );

            context.MapRoute(
                "Consulta_default",
                "Consulta/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}