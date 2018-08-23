using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.ISERVICE;
using KALAYUNITSM.SERVICE;

namespace KALAYUNITSM.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPermissionService _permissionService;
        private readonly IUserService _userService;

        public HomeController(IPermissionService permissionService, IUserService userService)
        {
            this._permissionService = permissionService;
            this._userService = userService;

        }

        #region 视图层
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Error(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }
        [ChkLogin]
        public ActionResult Index()
        {
            if (OperatorProvider.Instance.Current != null)
            {
                ViewBag.SoftwareName = Configs.GetValue("SoftwareName");
                ViewBag.md5pwd = OperatorProvider.Instance.Current.LockPassword;
                return View();
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }
        [ChkLogin]
        public ActionResult Main()
        {
            return View();
        }
        [ChkLogin]
        public ActionResult Welcome()
        {



            return View();
        }
        #endregion

        #region 数据层
        public ActionResult GetLeftMenu()
        {
            string userid = OperatorProvider.Instance.Current.UserId;
            List<LayNavbar> listNavbar = new List<LayNavbar>();
            var listModules = _permissionService.GetListByUserId(userid);
            foreach (var item in listModules.Where(c => c.Type == ModuleType.Menu && c.Layer == 0).ToList())
            {
                LayNavbar navbarEntity = new LayNavbar();
                var listChildNav = listModules.Where(c => c.Type == ModuleType.Menu && c.Layer == 1 && c.ParentId == item.Id)
                    .Select(c => new LayChildNavbar() { href = c.Url, icon = c.Icon, title = c.Name }).ToList();
                navbarEntity.icon = item.Icon;
                navbarEntity.spread = false;
                navbarEntity.title = item.Name;
                navbarEntity.children = listChildNav;
                listNavbar.Add(navbarEntity);
            }
            return Content(listNavbar.ToJson());
        }
        [HttpGet]
        public ActionResult GetVerifyCode()
        {
            string code = "";
            byte[] ms = new VerifyCode().GetVerifyCode(out code);
            WebHelper.SetSession(SystemKeys.SESSION_KEY_VCODE, Encrypt.MD5Encrypt(code.ToLower()));
            Response.ClearContent();
            return File(ms, @"image/png");
        }
        #endregion

        #region 操作层

        [HttpGet]
        public ActionResult Exit()
        {
            if (OperatorProvider.Instance.Current != null)
            {
                OperatorProvider.Instance.Remove();
            }
            return Redirect("/Home/Login");
        }

        [HttpPost]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            try
            {
                if (Session[SystemKeys.SESSION_KEY_VCODE].IsEmpty() || Encrypt.MD5Encrypt(code.ToLower()) != Session[SystemKeys.SESSION_KEY_VCODE].ToString())
                {
                    return Content(new AjaxResult(ResultType.Warning.ToString(), SystemItemMsgs.USER_LOGIN_VERIFYCODE_ERROR, "", null).ToJson());
                }
                var userModel = _userService.GetByAccount2(username);
                if (userModel == null)
                {
                    LogHelper.Write(LevelType.Error, "系统登录", SystemItemMsgs.USER_LOGIN_USERNAME_ERROR, username);
                    return Content(new AjaxResult(ResultType.Warning.ToString(), SystemItemMsgs.USER_LOGIN_USERNAME_ERROR, "", null).ToJson());
                }
                if (userModel.IsLock != false)
                {
                    return Content(new AjaxResult(ResultType.Warning.ToString(), SystemItemMsgs.USER_LOGIN_USERLOCK_ERROR, "", null).ToJson());
                }
                if (userModel.IsEnable != true)
                {
                    return Content(new AjaxResult(ResultType.Warning.ToString(), SystemItemMsgs.USER_LOGIN_USERNOENABLED_ERROR, "", null).ToJson());
                }
                if (userModel.Password != Encrypt.MD5Encrypt(password.ToLower()))
                {
                    LogHelper.Write(LevelType.Error, "系统登录", SystemItemMsgs.USER_LOGIN_PASSWORD_ERROR, username);
                    return Content(new AjaxResult(ResultType.Warning.ToString(), SystemItemMsgs.USER_LOGIN_PASSWORD_ERROR, "", null).ToJson());
                }
                else
                {
                    Operator operatorModel = new Operator();
                    operatorModel.UserId = userModel.Id;
                    operatorModel.Account = userModel.Account;
                    operatorModel.LockPassword = userModel.Password;
                    operatorModel.RealName = userModel.RealName;
                    operatorModel.Avatar = userModel.Avatar;
                    operatorModel.CompanyName = "";
                    operatorModel.DepartmentName = userModel.OrganizationName;
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.PositionId = userModel.PositionId;			 
 
                    OperatorProvider.Instance.Current = operatorModel;
                    var userModel2 = _userService.GetByAccount(username);
                    _userService.UpdateLogin(userModel2);
                    LogHelper.Write(LevelType.Info, "系统登录", SystemItemMsgs.USER_LOGIN_CHK_SUCCESS, userModel.Account);
                    return Content(new AjaxResult(ResultType.Success.ToString(), SystemItemMsgs.USER_LOGIN_CHK_SUCCESS, "/Home/Index", null).ToJson());
                }
            }
            catch (Exception ex)
            {
                LogHelper.Write(LevelType.Error, "系统登录", ex.Message, "", ex.StackTrace);
                return Content(new AjaxResult(ResultType.Warning.ToString(), ex.Message, "", null).ToJson());
            }
        }
        #endregion
    }
}