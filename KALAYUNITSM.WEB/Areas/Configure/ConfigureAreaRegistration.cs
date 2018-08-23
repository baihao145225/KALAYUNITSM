using System.Web.Mvc;

namespace KALAYUNITSM.WEB.Areas.Configure
{
    public class ConfigureAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Configure";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Configure_default",
                "Configure/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}