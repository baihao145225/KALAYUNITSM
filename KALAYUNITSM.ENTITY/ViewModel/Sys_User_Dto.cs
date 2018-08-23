using System;
using System.Collections.Generic;
using System.Linq;

namespace KALAYUNITSM.ENTITY
{
    public class Sys_User_Dto
    {
        public string Id { get; set; }

        public string Account { get; set; }
        public string RealName { get; set; } 
        public string Password { get; set; }
        public string Avatar { get; set; }
        public bool? Gender { get; set; }
        public string TelPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string EmployeeId { get; set; }
        public string CompanyId { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string ExpirationDate { get; set; }
        public bool? IsEnable { get; set; }
        public bool? IsOnLine { get; set; }
        public bool? IsLock { get; set; }
        public List<string> RoleId { get; set; }
        //增加岗位
        public string PositionId { get; set; }
        public string PositionName { get; set; }
                //增加岗位
        public DateTime? LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        public int? SortCode { get; set; }
    }
}
