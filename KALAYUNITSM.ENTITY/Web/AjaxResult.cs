using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.ENTITY
{
    /// <summary>
    /// 通用AJAX请求响应数据格式模型
    /// </summary>
    public class AjaxResult
    {
        public AjaxResult(object state, string message, string url, object data = null)
        {
            this.state = state;
            this.message = message;
            this.url = url;
            this.data = data;
        }
        /// <summary>
        /// 结果类型
        /// </summary>
        public object state { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回地址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 返回数据。
        /// </summary>
        public object data { get; set; }
    }

    /// <summary>
    /// 结果类型枚举。
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// 警告。
        /// </summary>
        Warning = 0,

        /// <summary>
        /// 成功。
        /// </summary>
        Success = 1,

        /// <summary>
        /// 异常。
        /// </summary>
        Errors = 2,

        /// <summary>
        /// 消息。
        /// </summary>
        Exception = 3,

        /// <summary>
        /// 消息。
        /// </summary>
        Info = 6
    }
}
