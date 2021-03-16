using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class EmployeeProductivityFormatProvider : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Formatting occurs in this method
            int rating = (int)arg;

            if (rating == 0)
                return $"{rating} (new employee)";
            if (rating > 0)
            {
                return $"{rating} (good employee)";
            }

            return $"{rating} (bad employee)";
        }

        public object GetFormat(Type formatType)
        {
            // Tells caller wihich object provides formatting capability
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }
    }
}
