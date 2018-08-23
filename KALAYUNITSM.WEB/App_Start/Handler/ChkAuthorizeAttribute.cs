using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB
{
    public class ChkAuthorizeAttribute : AuthorizeAttribute
    {

        public bool Ignore = true;
        public ChkAuthorizeAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }

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
                StringBuilder sbScript = new StringBuilder();
                filterContext.HttpContext.Response.Write("<script type='text/javascript'>top.location.href = '/Home/Error?msg=对不起，您没有该功能的使用权限。'</script>");
            }
        }

    }
}