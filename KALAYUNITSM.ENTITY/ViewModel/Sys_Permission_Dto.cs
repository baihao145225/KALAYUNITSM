using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KALAYUNITSM.ENTITY
{
    public class Sys_Permission_Dto
    {
        public string Id { get; set; }
        public string ParentId { get; set; } 
        public string EnCode { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; } 
        public string JsEvent { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Description { get; set; } 
        public DateTime? CreateTime { get; set; } 
    }
}
