using System;
using System.Linq;
using System.Linq.Expressions;

namespace IToNeo.ApplicationCore.Helpers
{
    public static class ExtensionHelper<T>
    {
        public static Expression<Func<T, object>> ConvertStringToExpression(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                try
                {
                    var parameter = Expression.Parameter(typeof(T));
                    var property = propertyName.Split(".").Aggregate<string, Expression>(parameter, (c, m) => Expression.Property(c, m));
                    var propAsObject = Expression.Convert(property, typeof(object));
                    var lambda = Expression.Lambda<Func<T, object>>(propAsObject, parameter);

                    return lambda;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return default;
        }
    }
}
