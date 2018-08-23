using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB.Areas.Manage.Controllers
{
    [ChkLogin]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUserRoleRelationService _userRoleRelationService;
        private readonly IPermissionService _permissionService;
        private readonly IUserPositionRelationService _userPositionRelationService;

        public UserController(IUserService userService, IUserRoleRelationService userRoleRelationService, IPermissionService permissionService, IUserPositionRelationService userPositionRelationService)
        {
            this._userService = userService;
            this._userRoleRelationService = userRoleRelationService;
            this._permissionService = permissionService;
            this._userPositionRelationService = userPositionRelationService;
        }

        #region 视图层
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        #endregion

        #region 数据层
        public ActionResult GetJsonData(int curr, int nums, string keyWord)
        {
            int count;
            var pageData = _userService.GetPageList(curr, nums, out count, keyWord);

            List<Sys_User_Dto> output = AutoMapper.Mapper.Map<List<Sys_User_Dto>>(pageData);
            var result = new LayUI<Sys_User_Dto>()
            {
                result = true,
                msg = "success",
                data = output,
                count = count
            };
            return Content(result.ToJson());
        }

        [HttpPost]
        public ActionResult GetForm(string primaryKey)
        {
            var entity = _userService.Get(primaryKey);
            Sys_User_Dto dto = AutoMapper.Mapper.Map<Sys_User_Dto>(entity);
            dto.RoleId = _userRoleRelationService.GetList(entity.Id).Select(c => c.RoleId).ToList();

            var pids = _userPositionRelationService.GetList(entity.Id).Select(c => c.PositionId).ToList();
            if (pids.Count !=0)
                dto.PositionId = pids[0];
            else
            {
                dto.PositionId = "";
            }
            return Content(dto.ToJson());
        }

        [HttpPost]
        public ActionResult GetPermission()
        {
            var userId = OperatorProvider.Instance.Current.UserId;
            var modules = _permissionService.GetListByUserId(userId);
            return Content(modules.ToJson());
        }

        [HttpPost]
        public ActionResult GetParent()
        {
            var data = _userService.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (Sys_User item in data)
            {
                TreeSelectModel model = new TreeSelectModel();
                model.id = item.Account;
                model.text = item.RealName;
                model.parentId = "1000";
                treeList.Add(model);
            }
            return Content(treeList.ToTreeSelectJson());
        }
        #endregion

        #region 操作层

        public ActionResult SaveForm(Sys_User model, string password, string roleIds, string positionIds)
        {
            if (model.Id.IsNullOrEmpty())
            {
                model.Password = Encrypt.MD5Encrypt(password.ToLower());
                model.IsLock = false;
                //创建用户基本信息。
                var userId = _userService.Insert(model).ToString();
                //创建用户角色信息。
                _userRoleRelationService.SetRole(userId, roleIds.ToStrArray());
                _userPositionRelationService.SetPosition(userId, positionIds);

                return userId != null ? Success() : Errors();
            }
            else
            {
                //更新用户角色信息。
                _userRoleRelationService.SetRole(model.Id, roleIds.ToStrArray());
                _userPositionRelationService.SetPosition(model.Id, positionIds);
                return _userService.Update(model) ? Success() : Errors();
            }
        }

        [HttpPost]
        public ActionResult CheckAccount(string account)
        {
            var userEntity = _userService.GetByAccount(account);
            if (userEntity != null)
            {
                return Errors(SystemItemMsgs.USER_CHK_USED_ERROR);
            }
            return Success(SystemItemMsgs.USER_CHK_ALLOW_SUCCESS);
        }

        [HttpPost]
        public ActionResult Delete(string primaryKey)
        {
            return _userService.Delete(primaryKey.ToStrArray()) ? Success() : Errors();

        }

        [HttpPost]
        public ActionResult Lock(string primaryKey)
        {
            return _userService.Lock(primaryKey.ToStrArray()) ? Success() : Errors();

        }
        #endregion
    }
}