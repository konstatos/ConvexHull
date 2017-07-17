using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Tests
{
  public static class CompareExt
  {
    /// <summary>
    /// Сортируем и преобразуем в строку для сранения
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="l"></param>
    /// <returns></returns>
    public static string ToStr<T>(this List<T> l)
    {
      return string.Join(",", l.OrderBy(x => x.ToString()));
    }
  }
}
