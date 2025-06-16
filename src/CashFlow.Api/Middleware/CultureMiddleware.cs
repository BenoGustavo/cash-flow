using System.Globalization;

namespace CashFlow.Api.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next)
        {
            this._next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public async Task Invoke(HttpContext context)
        {
            string? culture = context.Request.Headers.AcceptLanguage.FirstOrDefault(); 

            var cultureInfo = new CultureInfo(culture ?? "en");

            if (string.IsNullOrWhiteSpace(culture) == false) { 
                cultureInfo = new CultureInfo(culture);
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
