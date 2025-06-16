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
            var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

            string requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault() ?? "en";

            var cultureInfo = new CultureInfo(requestedCulture);

            var isCultureValid = 
                string.IsNullOrWhiteSpace(requestedCulture) == false
                && supportedCultures.Exists(culture => culture.Name.Equals(requestedCulture));

            if (isCultureValid) { 
                cultureInfo = new CultureInfo(requestedCulture);
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
