using Microsoft.AspNetCore.Mvc.Filters;

namespace API2.Filters
{
    public class CookieFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.

            var cookieOpt = new CookieOptions()
            {
                Path = "/",
                Expires = DateTimeOffset.UtcNow.AddMinutes(1),
                IsEssential = true,
                HttpOnly = false,
                Secure = false,
            };

            //context.HttpContext.Response.Cookies.Append("MyCookieId", "SomeCookieID", cookieOpt);
        }
    }
}
