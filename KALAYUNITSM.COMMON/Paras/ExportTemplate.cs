using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.COMMON
{
    public static class ExportTemplate
    {
        public static string[] Permission_Export = { "模块名称", "编码", "Icon", "Type", "事件", "地址" };
        public static string[] Organization_Export = { "组织机构", "编码", "联系人", "电话", "地址", "类型", "创建日期" };
        public static string[] Log_Export = { "ID", "类型", "模块", "消息", "用户", "IP", "IP地址", "Browser", "Stacktrace", "时间" };
    }
}
