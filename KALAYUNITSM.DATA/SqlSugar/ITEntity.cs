using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace KALAYUNITSM.DATA
{
    public interface ITEntity
    {
        DateTime? CreateTime { get; set; }
        int? SortCode { get; set; }
        int ChkState { get; set; }

    }


    /// <summary>
    /// 数据状态
    /// </summary>
    [Flags]
    public enum ChkState : int
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 1, //使用位标志后这里不要设置为0x0
        /// <summary>
        /// 已删除
        /// </summary>
        [Description("已删除")]
        Deleted = 2,

        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Ban = 4
    }
}
