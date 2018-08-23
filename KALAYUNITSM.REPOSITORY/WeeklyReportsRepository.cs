using KALAYUNITSM.ENTITY.WeeklyReports;
using KALAYUNITSM.IREPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.REPOSITORY
{
    public class WeeklyReportsRepository : BaseRepository<WeeklyReports>, IWeeklyReportsRepository
    {
     public bool InsertWeeklyRepoets(WeeklyReports model)
        {
           return base.Insert(model);
        }
    }
}
