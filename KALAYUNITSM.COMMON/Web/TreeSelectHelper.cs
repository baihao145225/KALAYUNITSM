using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KALAYUNITSM.COMMON
{
    public static class TreeSelectHelper
    {
        public static string ToTreeSelectJson(this List<TreeSelectModel> data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(ToTreeSelectJson(data, "1000", ""));
            sb.Append("]");
            return sb.ToString();
        }
        private static string ToTreeSelectJson(List<TreeSelectModel> data, string parentId, string blank)
        {
            StringBuilder sb = new StringBuilder();
            var childList = data.FindAll(t => t.parentId == parentId);

            var tabline = "";
            if (parentId != "1000")
            {
                tabline = "　　";
            }
            if (childList.Count > 0)
            {
                tabline = tabline + blank;
            }
            foreach (TreeSelectModel entity in childList)
            {
                entity.text = tabline + entity.text;
                string strJson = JsonConvert.SerializeObject(entity);
                sb.Append(strJson);
                sb.Append(ToTreeSelectJson(data, entity.id, tabline));
            }
            return sb.ToString().Replace("}{", "},{");
        }
    }
    public class TreeSelectModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string parentId { get; set; }
        public object data { get; set; }
    }
}
