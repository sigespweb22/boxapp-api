using System;
using AutoMapper;

namespace BoxBack.Application.Extensions
{
    public static class AutoMapperCompatibilityExtensions
    {
        // Summary:
        //     Resolve destination member using a custom value resolver callback. Used instead
        //     of MapFrom when not simply redirecting a source member This method cannot be
        //     used in conjunction with LINQ query projection
        //
        // Parameters:
        //   resolver:
        //     Callback function to resolve against source type
        public static void ResolveUsing<TSource, TDestination, TMember, TResult>(this IMemberConfigurationExpression<TSource, TDestination, TMember> member, Func<TSource, TResult> resolver) => member.MapFrom((Func<TSource, TDestination, TResult>)((src, dest) => resolver(src)));
    }
}