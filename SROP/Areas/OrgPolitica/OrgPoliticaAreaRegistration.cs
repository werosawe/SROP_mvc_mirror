using System.Web.Http;
using System.Web.Mvc;

namespace SROP.Areas.OrgPolitica
{
    public class OrgPoliticaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "OrgPolitica";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
               name: "OrgPoliticaApi",
                routeTemplate: "OrgPolitica/api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
            );
            context.MapRoute( 
                "OrgPolitica_default",
                "OrgPolitica/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}