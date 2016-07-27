using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public class CsvHelper
    {
        public static string Serialize<T>(IEnumerable<T> items)
        {
            var csv = string.Empty;

            if (items.Any())
            {
                Type myType = typeof (T);
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                foreach (var item in items)
                {
                    var itemCsv = string.Empty;
                    foreach (PropertyInfo prop in props)
                    {
                        itemCsv += prop.GetValue(item, null);
                        itemCsv += ",";
                    }

                    csv += itemCsv.Remove(itemCsv.Length - 1) + Environment.NewLine;
                }


            }

            return csv;
        }

        public static IEnumerable<string> SerializeToList<T>(IEnumerable<T> items)
        {
            var csv = new List<string>();

            if (items.Any())
            {
                Type myType = typeof (T);
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                foreach (var item in items)
                {
                    var itemCsv = string.Empty;
                    foreach (PropertyInfo prop in props)
                    {
                        itemCsv += prop.GetValue(item, null);
                        itemCsv += ",";
                    }

                    csv.Add(itemCsv.Remove(itemCsv.Length - 1));
                }
            }

            return csv;
        }
    }
}
