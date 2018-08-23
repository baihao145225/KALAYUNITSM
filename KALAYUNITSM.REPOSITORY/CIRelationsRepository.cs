using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class CIRelationsRepository : BaseRepository<Conf_CIRelations>, ICIRelationsRepository
    {

        public IEnumerable<Conf_CIRelations_Dto> GetJoinList(string ciId)
        {
            try
            {
                ISugarQueryable<Conf_CIRelations_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Conf_CIRelations, Conf_Relations, Conf_CI, Conf_CI>((st, sc, sc1, sc2) => new object[] { 
                JoinType.Left, st.RelationId == sc.Id, 
                JoinType.Left, st.CINId == sc1.Id, 
                JoinType.Left, st.CIPId == sc2.Id 
            })
                .Where((st, sc, sc1, sc2) => st.CINId == ciId || st.CIPId == ciId)
                .Select((st, sc, sc1, sc2) => new Conf_CIRelations_Dto
                {
                    Id = st.Id,
                    CINName = sc1.Name,
                    CIPName = sc2.Name,
                    RelationName = sc.Name,
                    CreateTime = st.CreateTime,
                    Description = SqlFunc.IIF(st.IsReverse == false, sc.ForwardText.Replace("#", sc1.Name), sc.ReverseText.Replace("#", sc2.Name)),
                    IsEnable = st.IsEnable
                });
                return entitys.ToList();
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
    }
}
