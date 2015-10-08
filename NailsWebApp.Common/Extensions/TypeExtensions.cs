using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NailsWebApp.Common.Extensions
{
    public static class TypeExtensions
    {
        public static TExpected GetAttributeValue<T, TExpected>(this MemberInfo member, Func<T, TExpected> expression)
             where T : Attribute
        {
            if (member == null || expression == null)
                throw new ArgumentNullException();

            var value = GetAttributesInternal<T>(member).Select(expression)
                                                        .SingleOrDefault();

            return value;
        }

        private static IEnumerable<T> GetAttributesInternal<T>(MemberInfo member) where T : Attribute
        {
            return member.GetCustomAttributes(typeof(T), false)
                         .Cast<T>();
        }

        /// <summary>
        /// Getting method name of object.
        /// </summary>
        /// <typeparam name="T">Type where to look for</typeparam>
        /// <param name="expression">Property being checked</param>
        /// <returns>Requested property name</returns>
        public static string PropertyName<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as UnaryExpression;
            if (body != null)
            {
                var operand = body.Operand as MemberExpression;
                if (operand == null)
                {
                    throw new Exception("Operand is required");
                }

                return operand.Member.Name;
            }

            var member = expression.Body as MemberExpression;
            if (member != null)
            {
                return member.Member.Name;
            }

            throw new Exception("Name can not be resolved");
        }

        /// <summary>
        /// Getting method name of object.
        /// </summary>
        /// <typeparam name="TModel">Model type</typeparam>
        /// <typeparam name="TItem">Object type</typeparam>
        /// <param name="expression">Property being checked</param>
        /// <returns>Requested property name</returns>
        public static string PropertyName<TModel, TItem>(Expression<Func<TModel, TItem>> expression)
        {
            var body = expression.Body as UnaryExpression;
            if (body != null)
            {
                var operand = body.Operand as MemberExpression;
                if (operand == null)
                {
                    throw new Exception("Operand is required");
                }

                return operand.Member.Name;
            }

            var member = expression.Body as MemberExpression;
            if (member != null)
            {
                return member.Member.Name;
            }

            throw new Exception("Name can not be resolved");
        }

        /// <summary>
        /// Type's full name
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <returns>Type full name</returns>
        public static string TypeFullName<T>()
        {
            return typeof(T).FullName;
        }

        /// <summary>
        /// Type's name
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <returns>Type name</returns>
        public static string TypeName<T>()
        {
            return typeof(T).Name;
        }
    }
}
