using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.COMMON;

namespace KALAYUNITSM.WEB
{
    public class ChkLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;
        public ChkLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (OperatorProvider.Instance.Current == null)
            {
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Home/Login'</script>");
                //filterContext.Result = new RedirectResult("/Home/Login2");
                return;
            }
            if (Ignore == false)
            {
                return;
            }

        }
    }
}