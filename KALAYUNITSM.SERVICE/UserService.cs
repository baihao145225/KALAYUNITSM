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
    public class UserService : BaseService<Sys_User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public Sys_User GetByAccount(string account)
        {
            return _userRepository.GetByAccount(account);
        }

        public Sys_User_Dto GetByAccount2(string account)
        {
            return _userRepository.GetByAccount2(account);
        }

        public List<Sys_User_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            return _userRepository.GetPageJoinList(pageIndex, pageSize, out count, keyWord).ToList();
        }
        public override object Insert(Sys_User entity)
        {
            entity.Id = Tools.GuId(); 
            entity.CreateUser = OperatorProvider.Instance.Current.Account;
            entity.CreateTime = DateTime.Now;
            entity.Avatar = "/Images/avatar/user.png";
            return _userRepository.Insert(entity);
        }

        public override bool Update(Sys_User entity)
        {
            return _userRepository.Update(entity);
        }

        public bool Lock(object[] primaryKey)
        {
            return _userRepository.Lock(primaryKey);
        }
        public bool UpdateLogin(Sys_User entity)
        {
            entity.IsOnLine = true;
            entity.LastLoginTime = DateTime.Now;
            entity.PrevLoginTime = entity.LastLoginTime;
            entity.LoginCount += 1;
            return _userRepository.UpdateNoReturn(entity);
        }
    }
}
