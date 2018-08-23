using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class OrganizationRepository : BaseRepository<Sys_Organization>, IOrganizationRepository
    {
        public long GetChildCount(string parentid)
        {
            return base.GetCount(c => c.ParentId == parentid);
        }
        public IEnumerable<Sys_Organization_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord, string parentId)
        {
            try
            {
                ISugarQueryable<Sys_Organization_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Sys_Organization, Sys_Organization>((st, sc) => new object[] { 
                JoinType.Left, st.ParentId == sc.Id 
            })
                .Where((st, sc) => st.Name.Contains(keyWord) && st.ParentId == parentId)
                .Select((st, sc) => new Sys_Organization_Dto { Id = st.Id, Type = sc.Name, EnCode = st.EnCode, Name = st.Name, Address = st.Address, TelPhone = st.TelPhone, Contacts = st.Contacts, SortCode = st.SortCode });

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
