using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Array方法实现
public static class ArrayExtensions
{
    public static T ArrayFind<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                return item;
            }
        }
        return default(T); // Return default value if no match is found
    }
}
