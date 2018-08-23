using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.DATA;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class PositionRepository : BaseRepository<Sys_Position>, IPositionRepository
    {
        public IEnumerable<Sys_Position_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal,
            string keyWord, string parentId)
        {
            try
            {
                ISugarQueryable<Sys_Position_Dto> entitys = _dbbase.SqlSugarClient
                    .Queryable<Sys_Position, Sys_ItemsDetail>((st, sc) => new object[]
                    {
                        JoinType.Left, st.Type == sc.EnCode
                    })
                    .Where((st, sc) => st.Name.Contains(keyWord) && st.ParentId == parentId)
                    .Select(
                        (st, sc) =>
                            new Sys_Position_Dto
                            {
                                Id = st.Id,
                                TypeName = sc.Name,
                                EnCode = st.EnCode,
                                Name = st.Name,
                                IsEnable = st.IsEnable,
                                SortCode = st.SortCode
                            });
                outTotal = 0;
                return entitys.ToPageList(pageIndex, pageSize, ref outTotal);
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }

        public IEnumerable<Sys_User_Dto> GetUserByPosition(int pageIndex, int pageSize, out int outTotal, string positionId)
        {
            try
            {
                ISugarQueryable<Sys_User_Dto> entitys = _dbbase.SqlSugarClient
                    .Queryable<Sys_User, Sys_UserPositionRelation>((st, sc) => new object[]
                    {
                        JoinType.Left, st.Id == sc.UserId
                    })
                    .Where((st, sc) => sc.PositionId == positionId)
                    .Select(
                        (st, sc) =>
                            new Sys_User_Dto
                            {
                                Id = st.Id,
                                Account = st.Account,
                                RealName = st.RealName,
                                TelPhone = st.TelPhone,
                                MobilePhone = st.MobilePhone,
                                Email = st.Email,
                                EmployeeId = st.EmployeeId,
                                Gender = st.Gender
                            });
                outTotal = 0;
                return entitys.ToPageList(pageIndex, pageSize, ref outTotal);
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }

        public Sys_Position_Dto GetPosition(string positionId)
        {
            ISugarQueryable<Sys_Position_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Sys_Position>()
                .Where(u => u.Id == positionId)
                .Select(u => new Sys_Position_Dto
                {
                    Id = u.Id,
                    TypeName = u.Name,
                    EnCode = u.EnCode,
                    Name = u.Name,
                    IsEnable = u.IsEnable,
                    SortCode = u.SortCode,
                    ParentId = u.ParentId
                });
            if (entitys.Count()==0)
                return null;
            else
            {
                return entitys.ToList().First();
            }
        }

        /// <summary>
        /// 通过岗位ID 获取子岗位(递归)
        /// </summary>
        /// <param name="PositionID"></param>
        /// <returns></returns>
        public IEnumerable<Sys_Position_Dto> GetChildPositionByPositionID(string parentId)
        {
            try
            {
                ISugarQueryable<Sys_Position_Dto> entitys = _dbbase.SqlSugarClient
                    .Queryable<Sys_Position, Sys_ItemsDetail>((st, sc) => new object[]
                    {
                        JoinType.Left, st.Type == sc.EnCode
                    })
                    .Where((st, sc) => st.ParentId == parentId)
                    .Select(
                        (st, sc) =>
                            new Sys_Position_Dto
                            {
                                Id = st.Id,
                                TypeName = sc.Name,
                                EnCode = st.EnCode,
                                Name = st.Name,
                                IsEnable = st.IsEnable,
                                SortCode = st.SortCode,
                                ParentId = st.ParentId
                            });
                return entitys.ToList().Concat(entitys.ToList().SelectMany(t => GetChildPositionByPositionID(t.Id.ToString())));
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }



    }
}

