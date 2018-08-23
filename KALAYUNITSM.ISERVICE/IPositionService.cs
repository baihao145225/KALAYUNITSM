using System;
using System.Collections.Generic;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.ISERVICE
{
    public interface IPositionService : IBaseService<Sys_Position>
    {
        List<Sys_Position_Dto> GetPageList(int pageIndex, int pageSize, out int count, string keyWord, string parentId);

        //获取该岗位下的人
        List<Sys_User_Dto> GetUserByPosition(int pageIndex, int pageSize, out int count, string PositionId);

        List<Sys_Position_Dto> GetChildPositionByPositionID(string PositionId);

        Sys_Position_Dto GetPosition(string PositionId);
    }
}
