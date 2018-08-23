using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IUserRepository : IBaseRepository<Sys_User>
    {
        Sys_User GetByAccount(string account);
        Sys_User_Dto GetByAccount2(string account);
        IEnumerable<Sys_User_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord);
        bool Lock(object[] keys);
    }
}
