using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IUserService : IBaseService<Sys_User>
    {
        Sys_User GetByAccount(string account);

        Sys_User_Dto GetByAccount2(string account); 


        List<Sys_User_Dto> GetPageList(int curr, int nums, out int count, string keyWord);
        bool UpdateLogin(Sys_User model);
        bool Lock(object[] primaryKey);
    }
}
