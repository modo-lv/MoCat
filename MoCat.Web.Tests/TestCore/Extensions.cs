using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MoCat.Web.Tests.TestCore {
  public static class Extensions {
    /// <summary>
    /// Convert an object's fields to key-value pairs.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static IEnumerable<KeyValuePair<String, String>> ToKeyValuePairs(this Object obj)
    {
      Type type = obj.GetType();
      PropertyInfo[] props = type.GetProperties();
      return props.Select(p => new KeyValuePair<String, String>(p.Name, p.GetValue(obj)!.ToString()));
    }
  }
}