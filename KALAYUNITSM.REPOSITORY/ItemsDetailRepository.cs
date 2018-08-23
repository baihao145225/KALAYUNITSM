using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class ItemsDetailRepository : BaseRepository<Sys_ItemsDetail>, IItemsDetailRepository
    {
        public IEnumerable<Sys_ItemsDetail_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string itemId)
        {
            try
            {
                ISugarQueryable<Sys_ItemsDetail_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Sys_ItemsDetail, Sys_Item>((st, sc) => new object[] { 
                JoinType.Left, st.ItemId == sc.Id 
            })
                .Where((st, sc) => st.ItemId == itemId)
                .Select((st, sc) => new Sys_ItemsDetail_Dto { Id = st.Id, ItemId = sc.Name, EnCode = st.EnCode, Name = st.Name, IsEnable = st.IsEnable, SortCode = st.SortCode });

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
