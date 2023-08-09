using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtadoDevs
{
    public class Lang
    {
        public static void Culture()
        {
            System.Globalization.CultureInfo cul = System.Threading.Thread.CurrentThread.CurrentUICulture;
            string lang = cul.TwoLetterISOLanguageName;
            HttpCookie cookielang = HttpContext.Current.Request.Cookies["Lang"];
            if (cookielang != null && cookielang.Value != null)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookielang.Value);
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookielang.Value);
            }
            else
            {
                System.Globalization.CultureInfo kultur = System.Threading.Thread.CurrentThread.CurrentUICulture;
                lang = kultur.TwoLetterISOLanguageName;

                if (lang == "tr".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr");
                }
                else if (lang == "en".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                }
                else if (lang == "fr".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr");
                }
                else if (lang == "de".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de");
                }
                else if (lang == "az".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("az");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("az");
                }
                else if (lang == "it".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("it");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("it");
                }
                else if (lang == "ru".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru");
                }
                else if (lang == "zh".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh");
                }
                else if (lang == "es".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es");
                }
                else if (lang == "pt".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt");
                }
                else if (lang == "ko".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ko");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ko");
                }
                else if (lang == "jp".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("jp");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("jp");
                }
                else if (lang == "hu".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hu");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("hu");
                }
                else if (lang == "bg".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("bgg");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("bg");
                }
                else if (lang == "bs".ToLower())
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("bs");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("bs");
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                }
            }
        }
    }
}