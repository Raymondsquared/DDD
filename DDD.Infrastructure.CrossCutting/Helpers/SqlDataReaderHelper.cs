using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public static class SqlDataReaderHelper
    {
        public static T GetValue<T>(this SqlDataReader reader, string key, T defaultValue)
        {
            T result;
            try
            {
                result = (T)reader[key];
            }
            catch (Exception)
            {
                result = defaultValue;

            }
            return result;
        }

        public static T ToObject<T>(this SqlDataReader reader)
        {
            var result = Activator.CreateInstance<T>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    foreach (PropertyInfo prop in result.GetType().GetProperties())
                    {
                        try
                        {
                            if (!object.Equals(reader[prop.Name], DBNull.Value))
                            {
                                if (prop.CanWrite)
                                    prop.SetValue(result, reader[prop.Name], null);
                            }
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }
            }

            return result;
        }

        public static List<T> ToListOfObjects<T>(this SqlDataReader reader)
        {
            var result = new List<T>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            if (!Equals(reader[prop.Name], DBNull.Value))
                            {
                                if (prop.CanWrite)
                                    prop.SetValue(obj, reader[prop.Name], null);
                            }
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }

                    result.Add(obj);
                }
            }
            return result;
        }


        public async static Task<T> ToObject<T>(this Task<SqlDataReader> reader)
        {
            var result = Activator.CreateInstance<T>();
            if ((await reader).HasRows)
            {
                while ((await reader).Read())
                {
                    foreach (PropertyInfo prop in result.GetType().GetProperties())
                    {
                        if (!object.Equals((await reader)[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(result, (await reader)[prop.Name], null);
                        }
                    }
                }
            }
            return result;
        }


        public async static Task<List<T>> ToListOfObjectsAsync<T>(this Task<SqlDataReader> reader)
        {
            var result = new List<T>();
            if ((await reader).HasRows)
            {
                while ((await reader).Read())
                {
                    var obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (!Equals((await reader)[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, (await reader)[prop.Name], null);
                        }
                    }

                    result.Add(obj);
                }
            }

            return result;
        }
    }
}
