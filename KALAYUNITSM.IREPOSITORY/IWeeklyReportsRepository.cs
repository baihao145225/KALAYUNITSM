using KALAYUNITSM.ENTITY;
using KALAYUNITSM.ENTITY.WeeklyReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.IREPOSITORY
{
   public interface IWeeklyReportsRepository : IBaseRepository<WeeklyReports>
    {
       bool InsertWeeklyRepoets(WeeklyReports model);
    }
}
