using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ContosoUniversityBlazor.Helpers
{
    /// <summary>
    /// See RirinDesuyo answer
    /// https://www.reddit.com/r/dotnet/comments/l2g3ps/does_anyone_know_what_to_use_in_place_of/
    /// </summary>
    public static class ContosoUniversityHelper
    {
        public static string DisplayFor<T>(this T model, Expression<Func<T, object>> propertyExpression)
        {
            Expression body = propertyExpression;
            if (body is LambdaExpression expression)
            {
                body = expression.Body;
            }

            if (!(body is MemberExpression memberExpression))
            {
                throw new InvalidOperationException("Expression is not a property");
            }

            var displayAttribute = memberExpression.Member.GetCustomAttributes(typeof(DisplayAttribute), false).OfType<DisplayAttribute>().First();

            return displayAttribute.Name;
        }
    }
}
