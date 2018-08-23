using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB
{
    public class ChkActionAuthorizeAttribute : ActionFilterAttribute
    {

        public bool Ignore = true;
        public ChkActionAuthorizeAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var account = OperatorProvider.Instance.Current.Account;
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            bool hasPermission = AutoFacConfig.Resolve<IPermissionService>().ActionValidate(account, action);
            if (!hasPermission)
            {
                filterContext.HttpContext.Response.StatusCode = 401;//无权限状态码   
                //filterContext.Result = new RedirectToRouteResult(routeValue);
                /* StringBuilder script = new StringBuilder();
                script.Append("<script>alert('对不起，您没有权限访问当前页面。');</script>");
                filterContext.Result = new ContentResult() { Content = script.ToString() };*/
                // StringBuilder sbScript = new StringBuilder();
                //filterContext.HttpContext.Response.Write("<script type='text/javascript'>alert('非常遗憾！您的权限不足，访问被拒绝！');location.href = '/Home/Index';</script>");
            }
            if (Ignore)
            {
                return;
            };
        }


    }
}