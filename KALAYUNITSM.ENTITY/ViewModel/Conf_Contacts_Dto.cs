using System;
using System.Collections.Generic;
using System.Linq;

namespace KALAYUNITSM.ENTITY
{
    public class Conf_Contacts_Dto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string TelPhone { get; set; }
        public bool? IsEnable { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? SortCode { get; set; }
        public int ChkState { get; set; }

    }
}
