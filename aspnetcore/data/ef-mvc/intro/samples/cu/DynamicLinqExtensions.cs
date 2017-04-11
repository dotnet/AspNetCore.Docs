using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

public static class DynamicLinqExtensions
{
    public static IQueryable<TElement> OrderBy<TElement>(
        this IQueryable<TElement> source,
        string propertyName,
        Type propertyType)
        => (IQueryable<TElement>)_dynamicOrderByMethodInfo
            .MakeGenericMethod(typeof(TElement), propertyType)
            .Invoke(null, new object[] { source, propertyName, false });

    public static IQueryable<TElement> OrderByDescending<TElement>(
        this IQueryable<TElement> source,
        string propertyName,
        Type propertyType)
        => (IQueryable<TElement>)_dynamicOrderByMethodInfo
            .MakeGenericMethod(typeof(TElement), propertyType)
            .Invoke(null, new object[] { source, propertyName, true });

    private static readonly MethodInfo _dynamicOrderByMethodInfo
        = typeof(DynamicLinqExtensions).GetTypeInfo().GetDeclaredMethod(nameof(DynamicOrderBy));

    private static IQueryable<TElement> DynamicOrderBy<TElement, TKey>(
        IQueryable<TElement> source,
        string propertyName,
        bool descending)
    {
        Expression<Func<TElement, TKey>> keySelector = e => EF.Property<TKey>(e, propertyName);

        return descending
            ? source.OrderByDescending(keySelector)
            : source.OrderBy(keySelector);
    }
}