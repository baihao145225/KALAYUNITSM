using System;
using System.ComponentModel;

namespace KALAYUNITSM.ENTITY
{
    public enum UrgencyLevelEnums
    {
        危急 = 0,
        高 = 1,
        中 = 2,
        低 = 3
    }
    public enum EffectLevelEnums
    {
        服务 = 0,
        部门 = 1,
        个人 = 2
    }
    public enum OrdersStatusEnums
    {
        已登记 = 1,
        已分派 = 2,
        已解决 = 4, 
        已关闭 = 8,
        处理中 = OrdersStatusEnums.已登记 | OrdersStatusEnums.已分派,
        已结束 = OrdersStatusEnums.已关闭  
    }
    public enum OrderFromEnums
    {
        电话 = 0,
        邮件 = 1,
        监控 = 2,
        门户 = 3
    }
    public enum OrderSolutionResultEnums
    {
        已解决 = 0,
        部分解决 = 1,
        未解决 = 2
    }
    public enum ServiceCatalogTypeEnums
    {
        远程 = 0,
        现场 = 1,
        远程和现场 = 2
    }
}
