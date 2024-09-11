using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//GetMin方法实现
public static class TransformExtensions
{
    
    public static T GetMin<T>(this IEnumerable<T> source, Func<T, float> selector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));

        // Return the element with the smallest value based on the selector function
        return source.OrderBy(selector).FirstOrDefault();
    }
}
