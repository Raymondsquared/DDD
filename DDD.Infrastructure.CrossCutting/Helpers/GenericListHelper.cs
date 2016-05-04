using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Infrastructure.CrossCutting.Attributes;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public static class GenericListHelpter
    {
        public static void AddIfNotExist<T>(this List<T> list, T item)
        {
            try
            {
                if (list != null && item != null)
                {
                    var isExist = false;

                    if (list.Count > 0)
                    {
                        var uniqueProperties = typeof(T).GetProperties().Where(prop => prop.IsDefined(typeof(UniqueAttribute), false));

                        foreach (var listItem in list)
                        {
                            var duplicates = new List<bool>();

                            foreach (var property in uniqueProperties)
                            {
                                var listItemValue = listItem.GetType().GetProperty(property.Name).GetValue(listItem);
                                var itemValue = item.GetType().GetProperty(property.Name).GetValue(item);

                                if (listItemValue.Equals(itemValue))
                                    duplicates.Add(true);
                                else
                                    duplicates.Add(false);
                            }

                            if (duplicates.TrueForAll(d => d))
                            {
                                isExist = true;
                            }
                        }
                    }

                    if (!isExist)
                    {
                        list.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private static object GetDefaultValue(Type t)
        {
            object result = null;

            if (t.IsValueType)
            {
                result = Activator.CreateInstance(t);
            }
            else
            {
                if (t == typeof(string))
                {
                    result = string.Empty;
                }
            }

            return result;
        }
    }
}
