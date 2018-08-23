using System;
using System.Collections.Generic;
using System.Linq;

namespace KALAYUNITSM.ENTITY
{
    public class Sys_Role_Dto
    {
        public string Id { get; set; }
        public string EnCode { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
        public string Name { get; set; }
        public bool? IsEnable { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public string State { get; set; }
    }
}
