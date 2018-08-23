using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.DATA;
using KALAYUNITSM.IREPOSITORY;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.SERVICE
{
    public class PermissionService : BaseService<Sys_Permission>, IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRoleAuthorizeRepository _roleAuthorizeRepository;
        private readonly IUserRoleRelationRepository _userRoleRelationRepository;
        public PermissionService(IPermissionRepository permissionRepository, IRoleAuthorizeRepository roleAuthorizeRepository,
     IUserRoleRelationRepository userRoleRelationRepository)
        {
            this._permissionRepository = permissionRepository;
            this._roleAuthorizeRepository = roleAuthorizeRepository;
            this._userRoleRelationRepository = userRoleRelationRepository;
        }


        #region 数据层 
        public List<Sys_Permission> GetListByUserId(string userId)
        {
            //a.根据用户ID查询角色ID集合 （一对多关系）
            var listRoleIds = _userRoleRelationRepository.GetList(userId).Select(c => c.RoleId).ToList();
            //b.根据角色ID查询权限ID集合 （多对多关系）
            var listModuleIds = _roleAuthorizeRepository.GetList().Where(c => listRoleIds.Contains(c.RoleId)).Select(c => c.ModuleId).ToList();
            //c.根据权限ID集合查询所有权限实体。
            return _permissionRepository.GetList().Where(c => listModuleIds.Contains(c.Id) && c.IsEnable == true).ToList();
        }

        public List<Sys_Permission> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            var expression = ExtLinq.True<Sys_Permission>();
            if (!keyWord.IsNullOrEmpty())
            {
                expression = expression.And(c => c.Name.Contains(keyWord));
            }
            return _permissionRepository.GetPageData(pageIndex, pageSize, out count, expression).ToList();
        }
        public long GetChildCount(string parentId)
        {
            return _permissionRepository.GetChildCount(parentId);
        }
        public bool ActionValidate(string userid, string action)
        {
            var authorizeModules = new List<Sys_Permission>();
            authorizeModules = WebHelper.GetCache<List<Sys_Permission>>("authorize_modules_" + userid);
            if (authorizeModules == null)
            {
                authorizeModules = this.GetListByUserId(userid);
                //设置缓存有效时间120分钟。
                WebHelper.SetCache<List<Sys_Permission>>("authorize_modules_" + userid, authorizeModules, DateTime.Now.AddMinutes(120));
            }
            foreach (var item in authorizeModules)
            {
                if (!string.IsNullOrEmpty(item.Url))
                {
                    string[] url = item.Url.Split('?');
                    if (url[0].ToLower() == action.ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region 操作层
        public override object Insert(Sys_Permission model)
        {
            model.Id = Tools.GuId();
            model.Layer = _permissionRepository.Get(model.ParentId).Layer += 1;
            model.IsEnable = model.IsEnable == null ? false : true;
            model.IsEdit = model.IsEdit == null ? false : true;
            model.IsPublic = model.IsPublic == null ? false : true; 
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CreateTime = DateTime.Now;
            return _permissionRepository.Insert(model);
        }
        public override bool Update(Sys_Permission model)
        {
            model.Layer = _permissionRepository.Get(model.ParentId).Layer += 1;
            model.IsEnable = model.IsEnable == null ? false : true;
            model.IsEdit = model.IsEdit == null ? false : true;
            model.IsPublic = model.IsPublic == null ? false : true;
            var updateColumns = new List<string>() { "EnCode", "Name" };
            return _permissionRepository.Update(model);
        }
        public bool Delete(params string[] primaryKeys)
        {
            //删除权限与角色的对应关系。
            _roleAuthorizeRepository.Delete(primaryKeys);
            if (_permissionRepository.Delete(primaryKeys))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
