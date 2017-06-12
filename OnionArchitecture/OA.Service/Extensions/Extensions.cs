using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OA.Service.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Converts the first letter of each word in the string to upper case and the rest to lower case.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToProper(this string s)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sourcEntities"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> Active<TEntity>(this IQueryable<TEntity> sourcEntities) where TEntity : class, ISoftDeletable
        {
            return sourcEntities.Where(s => !s.IsDeleted);

        }
        /// <summary>
        /// Generic extension method for getting distinct data form any entity
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            return source.Where(element => seenKeys.Add(keySelector(element)));
        }
        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// http://extensionmethod.net/csharp/ienumerable-t/orderby-string-sortexpression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sortExpression"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, string sortExpression)
        {
            sortExpression += "";
            string[] parts = sortExpression.Split(' ');
            bool descending = false;
            if (parts.Length > 0 && parts[0] != "")
            {
                var property = parts[0];

                if (parts.Length > 1)
                {
                    descending = parts[1].ToLower().Contains("esc");
                }
                PropertyInfo prop = typeof(T).GetProperty(property);
                if (prop == null)
                {
                    throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");
                }

                if (descending)
                    return list.OrderByDescending(x => prop.GetValue(x, null));
                return list.OrderBy(x => prop.GetValue(x, null));
            }
            return list;
        }
    }
}
