using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AutoMapper;

namespace KALAYUNITSM.WEB
{
    public static class AutoMapperHelper
    {

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            //IEnumerable<T> 类型需要创建元素的映射 
            Mapper.Initialize(c =>
                       {
                           c.CreateMap<TSource, TDestination>();
                       });
            return Mapper.Map<List<TDestination>>(source);
        }
        /// <summary>
        /// 类型映射
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
            where TSource : class
            where TDestination : class
        {
            if (source == null) return destination;
            Mapper.Initialize(c =>
            {
                c.CreateMap<TSource, TDestination>();
            });
            return Mapper.Map(source, destination);
        }
    }
}