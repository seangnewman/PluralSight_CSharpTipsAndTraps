using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateUtils
{
    public class DateFormatter
    {
        public string Format(DateTime date, string prefix="default ")
        {
            return prefix + date.ToShortDateString();
        }
    }
}
