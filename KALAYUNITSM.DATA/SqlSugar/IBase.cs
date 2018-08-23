using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;

namespace KALAYUNITSM.DATA
{
    public interface IBase : IDisposable
    {
        SqlSugarClient SqlSugarClient { get; }
    }
}
