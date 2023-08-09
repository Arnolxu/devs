using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ArtadoDevs
{
    public class Errors
    {
        public static string ErrorMessage(string lang)
        {
            switch (lang)
            {
                case "en":
                    return "Something went wrong! Please make sure to fill in all required fields.";
                case "tr":
                    return "Bir hata oluştu! Lütfen tüm zorunlu alanları doldurduğunuzdan emin olunuz.";
                default:
                    return "Bir hata oluştu! Lütfen tüm zorunlu alanları doldurduğunuzdan emin olunuz.";
            }
        }
    }
}