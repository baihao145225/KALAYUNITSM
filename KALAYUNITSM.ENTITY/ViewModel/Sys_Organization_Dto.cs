using System;

namespace KALAYUNITSM.ENTITY
{
    public class Sys_Organization_Dto
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string EnCode { get; set; }
        public string Type { get; set; }
        public string TelPhone { get; set; }
        public string Contacts { get; set; }
        public string Address { get; set; }
        public int? SortCode { get; set; }

    }
}
