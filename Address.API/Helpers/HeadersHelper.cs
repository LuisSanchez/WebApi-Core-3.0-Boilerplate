using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Address.API.Helpers
{
    internal static class HeadersHelper
    {
        private const string defaultLang = "es-ES";

        /// <summary>
        /// Gets the language from the header. // Obtiene el lenguaje del request del header.
        /// </summary>
        internal static void GetLanguage(HttpContext httpContext)
        {
            try
            {
                string lang = "";

                if (httpContext == null)
                {
                    SetLanguageAndCulture(defaultLang);
                }
                else
                {
                    var headers = httpContext.Request.Headers;

                    // Se asegura que se obtenga solo el primer lenguaje soportado.
                    string language = headers["Accept-Language"].ToString().Split(';').FirstOrDefault().Split(',').FirstOrDefault();

                    if (language.Trim().ToLower().Contains("es"))
                        lang = "es-ES";
                    else if (language.Trim().ToLower().Contains("en"))
                        lang = "en-US";
                    else
                        lang = defaultLang;

                    SetLanguageAndCulture(lang);
                }
            }
            catch (Exception)
            {
                SetLanguageAndCulture(defaultLang);
            }
        }

        /// <summary>
        /// Set language on the culture info object.
        /// </summary>
        /// <param name="lang"></param>
        private static void SetLanguageAndCulture(string lang)
        {
            NumberFormatInfo numberInfo = CultureInfo.CreateSpecificCulture(defaultLang).NumberFormat;
            CultureInfo info = new CultureInfo(lang)
            {
                NumberFormat = numberInfo
            };
            //later, we will if-else the language here
            info.DateTimeFormat.DateSeparator = "/";
            //info.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentUICulture = info;
            Thread.CurrentThread.CurrentCulture = info;
        }
    }
}