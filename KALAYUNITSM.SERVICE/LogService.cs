using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.IREPOSITORY;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.SERVICE
{
    public class LogService : BaseService<Sys_Log>, ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            this._logRepository = logRepository;
        }
        public List<Sys_Log> GetPageList(int pageIndex, int pageSize, out int count, string keyWord)
        {
            var expression = ExtLinq.True<Sys_Log>();
            if (!keyWord.IsNullOrEmpty())
            {
                expression = expression.And(c => c.Message.Contains(keyWord));
            }
            expression = expression.And(c => c.Id != "");
            return _logRepository.GetPageData(pageIndex, pageSize, out count, expression, c => c.CreateTime).ToList();
        }
    }
}
