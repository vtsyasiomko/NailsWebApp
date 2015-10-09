using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace NailsApp.Common.Extensions
{
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Map destination value to property when destination property already initialized or generate value of property otherwise
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="mappingExpression"></param>
        /// <param name="destinationMember"></param>
        /// <param name="generateFunction"></param>
        /// <returns></returns>
        public static IMappingExpression<TSource, TDestination> ForMemberGenerateOnCreate<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, object>> destinationMember,
            Action<TSource, TDestination> generateFunction)
        {
            return mappingExpression.ForMember(destinationMember, opt => opt.Ignore())
                                    .ForMember(destinationMember, opt => opt.UseDestinationValue())
                                    .AfterMap(generateFunction);
        }
    }
}
