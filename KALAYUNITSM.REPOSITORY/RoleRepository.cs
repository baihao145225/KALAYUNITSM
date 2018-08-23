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
    public class RoleRepository : BaseRepository<Sys_Role>, IRoleRepository
    {
        public IEnumerable<Sys_Role_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord)
        {
            try
            {
                ISugarQueryable<Sys_Role_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Sys_Role, Sys_ItemsDetail>((st, sc) => new object[] { 
                JoinType.Left, st.Type == sc.EnCode 
            })
                .Where((st, sc) => st.Name.Contains(keyWord))
                .Select((st, sc) => new Sys_Role_Dto { Id = st.Id, TypeName = sc.Name, EnCode = st.EnCode, Name = st.Name, IsEnable = st.IsEnable, SortCode = st.SortCode });
                outTotal = 0;
                return entitys.ToPageList(pageIndex, pageSize, ref outTotal);
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
    }
}
