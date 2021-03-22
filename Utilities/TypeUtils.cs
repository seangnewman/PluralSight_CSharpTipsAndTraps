#define APPENDTIME
using System;
using System.Diagnostics;

namespace Utilities
{
    [Obsolete("This class will be removed in v2")]
    public class TypeUtils
    {
        public static string GetNameSpace(object o)
        {
            string result = "";


            // Only compile in debug mode
#if DEBUG
            result += "[DEBUG BUILD] ";
#endif

#if RELEASE
            result += "[RELEASE BUILD] ";
#endif

#if NETCOREAPP2_0
            result += $"{o.GetType().GetTypeInfo().Namespace}";
#else
            result += $"{o.GetType().Namespace}";
#endif

#if APPENDTIME
            result += $" Time: {DateTime.Now.ToShortTimeString()})";
#endif
            AppendDate(ref result);

            return result;

        }

        [Conditional("DEBUG")]
        private static void AppendDate(ref string result)
        {
            result += "" + DateTime.Now.ToShortDateString();
        }
    }
}
