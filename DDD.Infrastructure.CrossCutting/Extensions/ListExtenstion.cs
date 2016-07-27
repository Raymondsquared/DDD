using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infrastructure.CrossCutting.Extensions
{
    public static class ListExtension
    {
        public static List<List<T>> Split<T>(this List<T> input, int size)
        {
            var result = new List<List<T>>();

            try
            {
                result = input
                    .Select((x, i) => new { Index = i, Value = x })
                    .GroupBy(x => x.Index / size)
                    .Select(x => x.Select(v => v.Value).ToList())
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
