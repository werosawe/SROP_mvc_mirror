using System.Web.Http;
using System.Web.Mvc;

namespace SROP.Areas.Requisito
{
    public class RequisitoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Requisito";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.Routes.MapHttpRoute(
                 name: "RequisitoApi",
                  routeTemplate: "Requisito/api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }
              );

           context.MapRoute(
                "Requisito_default",
                "Requisito/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}