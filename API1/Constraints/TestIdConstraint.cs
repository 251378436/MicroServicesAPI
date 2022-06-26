
using Microsoft.AspNetCore.Routing;
using System.Globalization;

namespace API1.Constraints
{
    public class TestIdConstraint : IRouteConstraint
    {
        private readonly string _message;
        public TestIdConstraint(string message)
        {
            _message = message;
        }

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out var routeValue))
            {
                return false;
            }

            var routeValueString = Convert.ToString(routeValue, CultureInfo.InvariantCulture);

            if (string.IsNullOrEmpty(routeValueString))
            {
                return false;
            } else
            {
                if (routeValueString.Equals("1000"))
                    return true;
            }

            return false;
        }
    }
}
