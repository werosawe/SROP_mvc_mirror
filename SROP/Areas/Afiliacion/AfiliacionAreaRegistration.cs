using System.Web.Http;
using System.Web.Mvc;

namespace SROP.Areas.Afiliacion
{
    public class AfiliacionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Afiliacion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.Routes.MapHttpRoute(
                name: "AfiliacionApi",
                 routeTemplate: "Afiliacion/api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            context.MapRoute(
                "Afiliacion_default",
                "Afiliacion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}