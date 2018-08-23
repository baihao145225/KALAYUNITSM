using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.SERVICE
{
    public class RoleService : BaseService<Sys_Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }
        public List<Sys_Role_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            return _roleRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord).ToList();
        }
        public override object Insert(Sys_Role model)
        {
            model.Id = Guid.NewGuid().ToString();
            model.IsEnable = model.IsEnable == null ? false : true;
            model.AllowEdit = model.AllowEdit == null ? false : true; 
            model.CreateUser = OperatorProvider.Instance.Current.Account;
            model.CreateTime = DateTime.Now;
            return _roleRepository.Insert(model);
        }
        public override bool Update(Sys_Role model)
        {
            model.IsEnable = model.IsEnable == null ? false : true;
            model.AllowEdit = model.AllowEdit == null ? false : true;
            return _roleRepository.Update(model);
        }
    }
}
