using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using KALAYUNITSM.ENTITY;

namespace KALAYUNITSM.WEB
{
    public class AutoMapperConfiguration
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Sys_User, Sys_User_Dto>().ForMember(d => d.ExpirationDate, opt => opt.ResolveUsing<Sys_User_Resolver>());
                cfg.CreateMap<Sys_Role, Sys_Role_Dto>();
                cfg.CreateMap<Sys_Permission, Sys_Permission_Dto>();
                cfg.CreateMap<Sys_ItemsDetail, Sys_ItemsDetail_Dto>().ForMember(d => d.ItemId, opt => opt.ResolveUsing<Sys_Items_Resolver>());
                cfg.CreateMap<Sys_ItemsDetail_Dto, Sys_ItemsDetail>();
                cfg.CreateMap<Conf_SLA, Conf_SLA_Dto>();
                cfg.CreateMap<Conf_SLTs, Conf_SLTs_Dto>();
                cfg.CreateMap<Itsm_OrderChk, Itsm_OrderChk_Dto>();
                cfg.CreateMap<Itsm_OrderTemplete, Itsm_OrderTemplete_Dto>().ForMember(d => d.EffectName, opt => opt.MapFrom(s => s.EffectId.ToString())).ForMember(d => d.UrgencyName, opt => opt.MapFrom(s => s.UrgencyId.ToString()));
                //cfg.CreateMap<Sys_ItemsDetail, Sys_ItemsDetail_Dto>().ForMember(opt => LoadEntity(opt,                                                                        dto => dto.DeviceNameId,  IProductAppService.FindProduct);
            });
        }
    }

}