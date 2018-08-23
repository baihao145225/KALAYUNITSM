using System;
using System.Collections.Generic;
using SqlSugar;
using KALAYUNITSM.DATA;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_Localtion : ITEntity
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public string Address { get; set; }
        public bool? IsEnable { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }
    }
}
