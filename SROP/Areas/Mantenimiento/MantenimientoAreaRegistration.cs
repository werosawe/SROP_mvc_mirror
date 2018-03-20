using System.Web.Http;
using System.Web.Mvc;

namespace SROP.Areas.Mantenimiento
{
    public class MantenimientoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Mantenimiento";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.Routes.MapHttpRoute(
                name: "MantenimientoApi",
                 routeTemplate: "Mantenimiento/api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            context.MapRoute(
                "Mantenimiento_default",
                "Mantenimiento/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}