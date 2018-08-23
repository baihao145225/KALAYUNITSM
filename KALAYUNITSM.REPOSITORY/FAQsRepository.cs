using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class FAQsRepository : BaseRepository<Itsm_FAQs>, IFAQsRepository
    {
        public Itsm_FAQs_Dto GetById(string Id)
        {
            try
            {
                ISugarQueryable<Itsm_FAQs_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Itsm_FAQs, Itsm_FAQsCategory>((st, sc) => new object[] { 
                JoinType.Left, st.CategoryId == sc.Id 
            })
                .Where((st, sc) => st.Id == Id)
                .Select((st, sc) => new Itsm_FAQs_Dto
                {
                    Id = st.Id,
                    Name = st.Name,
                    EnCode = st.EnCode,
                    CategoryName = sc.Name,
                    Author = st.Author,
                    KeyWords = st.KeyWords,
                    Description = st.Description,
                    Hits = st.Hits,
                    CreateTime = st.CreateTime,
                    SortCode = st.SortCode,
                    IsEnable = st.IsEnable
                });
                return entitys.First();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public bool UpdateCount(string Id)
        {
            return _dbbase.SqlSugarClient.Updateable<Itsm_FAQs>().UpdateColumns(c => new Itsm_FAQs() { Hits = c.Hits + 1 }).Where(c => c.Id == Id).ExecuteCommand() > 0;
        }
        public IEnumerable<Itsm_FAQs_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord, string categoryId)
        {
            try
            {
                ISugarQueryable<Itsm_FAQs_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Itsm_FAQs, Itsm_FAQsCategory, Sys_User>((st, sc, sc1) => new object[] { 
                JoinType.Left, st.CategoryId == sc.Id 
                ,JoinType.Left, st.Author == sc1.Account 
            })
                .Where((st, sc, sc1) => st.Name.Contains(keyWord))
                .Select((st, sc, sc1) => new Itsm_FAQs_Dto
                {
                    Id = st.Id,
                    Name = st.Name,
                    EnCode = st.EnCode,
                    CategoryName = sc.Name,
                    Author = sc1.RealName,
                    KeyWords = st.KeyWords,
                    CreateTime = st.CreateTime,
                    Hits = st.Hits,
                    SortCode = st.SortCode,
                    IsEnable = st.IsEnable
                });

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
