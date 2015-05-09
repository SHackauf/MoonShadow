using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyUtils
{
    public class ReflectionUtils
    {
        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression", "Expression is null!");

            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                var unary = expression.Body as UnaryExpression;
                if (unary != null && unary.NodeType == ExpressionType.Convert)
                    body = unary.Operand as MemberExpression;
            }

            if (body == null || body.Member.MemberType != MemberTypes.Property)
                throw new ArgumentException("Property expression was not found.", "expression");
            return body.Member.Name;
        }
    }
}
