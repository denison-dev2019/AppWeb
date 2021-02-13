using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Util
{
    public class ConfiguracaoRegional
    {
        public static CultureInfo SQL()
        {
            var cultura = new CultureInfo("pt-BR");
            cultura.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            cultura.NumberFormat.NumberDecimalDigits = 4;
            cultura.NumberFormat.NumberDecimalSeparator = ".";
            return cultura;
        }
        public static CultureInfo BR()
        {
            var cultura = new CultureInfo("pt-BR");
            cultura.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            cultura.NumberFormat.NumberDecimalDigits = 2;
            cultura.NumberFormat.NumberDecimalSeparator = ",";
            return cultura;
        }
    }
}

