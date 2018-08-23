using System;
using System.Collections.Generic;
using System.Linq;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.IREPOSITORY
{
    public interface IPositionRepository : IBaseRepository<Sys_Position>
    {
        IEnumerable<Sys_Position_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord, string parentId);

        IEnumerable<Sys_User_Dto> GetUserByPosition(int pageIndex, int pageSize, out int count, string positionId);

        Sys_Position_Dto GetPosition(string positionId);

        IEnumerable<Sys_Position_Dto> GetChildPositionByPositionID(string parentId);

    }
}
