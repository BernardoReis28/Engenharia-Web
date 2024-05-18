using System.Text.RegularExpressions;

namespace Tutorial_06
{
    public class MyRulesConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeKey != "letter")
                return false; // reject any other than "letter"

            // regular expression to validade one char of the presented set
            return values[routeKey] is null || Regex.IsMatch((values[routeKey] as string), @"^[a-zA-ZÂÁÉÓ]$");
        }
    }
}
