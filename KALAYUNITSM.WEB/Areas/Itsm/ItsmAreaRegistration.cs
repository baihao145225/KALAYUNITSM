using System.Web.Mvc;

namespace KALAYUNITSM.WEB.Areas.Itsm
{
    public class ItsmAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Itsm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Itsm_default",
                "Itsm/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}