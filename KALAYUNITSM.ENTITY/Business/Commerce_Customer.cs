using System;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Commerce_Customer : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; } 
        public string Name { get; set; }
        public string EnCode { get; set; }
        public string TelPhone { get; set; }
        public string Contacts { get; set; }
        public string Address { get; set; }
        public bool? IsEnable { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }

    }
}
