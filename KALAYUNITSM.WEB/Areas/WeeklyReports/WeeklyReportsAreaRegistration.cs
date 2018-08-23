using System.Web.Mvc;

namespace KALAYUNITSM.WEB.Areas.WeeklyReports
{
    public class WeeklyReportsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WeeklyReports";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WeeklyReports_default",
                "WeeklyReports/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}