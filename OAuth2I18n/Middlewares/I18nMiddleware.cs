using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2I18n.Middlewares
{
    public class I18nMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string cultureKey = context.Request.Headers["Accept-Language"];
            if (!string.IsNullOrEmpty(cultureKey))
            {
                if (CultureExists(cultureKey))
                {
                    var culture = new CultureInfo(cultureKey);
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
            }

            await next(context);
        }

        private static bool CultureExists(string cultureName)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures).Any(culture => string.Equals(culture.Name, cultureName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}