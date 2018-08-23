using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;

namespace KALAYUNITSM.REPOSITORY
{
    public class UserRepository : BaseRepository<Sys_User>, IUserRepository
    {
        public Sys_User GetByAccount(string account)
        {
            return base.GetFirst(t => t.Account == account);
        }

        public Sys_User_Dto GetByAccount2(string account)
        {
            try
            {
                ISugarQueryable<Sys_User_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Sys_User, Sys_Organization, Sys_UserPositionRelation>((st, sc, su) => new object[] { 
                JoinType.Left, st.OrganizationId == sc.Id ,
                JoinType.Left,st.Id == su.UserId
            })
                .Where((st, sc, su) => st.Account == account)
                .Select((st, sc, su) => new Sys_User_Dto { OrganizationName = sc.Name, Id = st.Id, Account = st.Account, Email = st.Email, MobilePhone = st.MobilePhone, TelPhone = st.TelPhone, ExpirationDate = st.ExpirationDate.ToString(), RealName = st.RealName, EmployeeId = st.EmployeeId, IsEnable = st.IsEnable, SortCode = st.SortCode, LastLoginTime = st.LastLoginTime, PositionId = su.PositionId, IsLock = st.IsLock, Password = st.Password });


                return entitys.First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }
        public IEnumerable<Sys_User_Dto> GetPageJoinList(int pageIndex, int pageSize, out int outTotal, string keyWord)
        {
            try
            {
                ISugarQueryable<Sys_User_Dto> entitys = _dbbase.SqlSugarClient.Queryable<Sys_User, Sys_Organization, Sys_UserPositionRelation, Sys_Position>((st, sc, su, sp) => new object[] { 
                JoinType.Left, st.OrganizationId == sc.Id ,
                JoinType.Left,st.Id == su.UserId,
                JoinType.Left,su.PositionId == sp.Id
            })
                .Where((st, sc) => st.Account.Contains(keyWord) || st.RealName.Contains(keyWord) || st.EmployeeId.Contains(keyWord))
                .Select((st, sc, su, sp) => new Sys_User_Dto { OrganizationName = sc.Name, Id = st.Id, Account = st.Account, Email = st.Email, MobilePhone = st.MobilePhone, TelPhone = st.TelPhone, ExpirationDate = st.ExpirationDate.ToString(), RealName = st.RealName, EmployeeId = st.EmployeeId, IsEnable = st.IsEnable, SortCode = st.SortCode, LastLoginTime = st.LastLoginTime, PositionId = su.PositionId, IsLock = st.IsLock, PositionName = sp.Name });

                outTotal = 0;
                return entitys.ToPageList(pageIndex, pageSize, ref outTotal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }



        public bool Lock(object[] keys)
        {
            try
            {
                foreach (var key in keys)
                {
                    Sys_User entity = _dbbase.SqlSugarClient.Queryable<Sys_User>().InSingle(key);
                    int count = _dbbase.SqlSugarClient.Updateable(entity).ReSetValue(c => c.IsLock == true).Where(true).ExecuteCommand();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbbase.SqlSugarClient.Close();
            }
        }

    }
}
