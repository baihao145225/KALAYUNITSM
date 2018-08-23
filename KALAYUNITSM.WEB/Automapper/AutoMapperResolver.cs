using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using KALAYUNITSM.ENTITY;
using KALAYUNITSM.COMMON;
using KALAYUNITSM.ISERVICE;

namespace KALAYUNITSM.WEB
{

    public class Sys_Items_Resolver : IValueResolver<Sys_ItemsDetail, Sys_ItemsDetail_Dto, string>
    {
        public string Resolve(Sys_ItemsDetail source, Sys_ItemsDetail_Dto destination, string ItemName, ResolutionContext context)
        {
            return new Guid().ToString();
        }
    }
    public class Sys_User_Resolver : IValueResolver<Sys_User, Sys_User_Dto, string>
    {
        public string Resolve(Sys_User source, Sys_User_Dto destination, string ItemName, ResolutionContext context)
        {
            return string.Format("{0:d}", source.ExpirationDate);
        }
    }
    public class Itsm_Orders_Resolver : IValueResolver<Itsm_Orders, Itsm_Orders_Dto, string>
    {
        public string Resolve(Itsm_Orders source, Itsm_Orders_Dto destination, string ItemName, ResolutionContext context)
        {
            return Enum.GetName(typeof(OrdersStatusEnums), source.StatusCode);
        }
    }
}