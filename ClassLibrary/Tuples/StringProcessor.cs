using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Tuples
{
    public class StringProcessor
    {
       
        public List<string> ToUpperAndWithLength(List<string> stringsToProcess)
        {
            var results = new List<string>();
            foreach (var s in stringsToProcess)
            {
                var result = Process(s);
                results.Add($"{result.Length}-{result.UpperCaseVersion}");
            }
            return results;
        }

        private (int Length, string UpperCaseVersion) Process(string s)
        {
            //return new Result
            //{
            //    Length = s.Length,
            //    UpperCaseVersion = s.ToUpper()
            //};

            return (s.Length, s.ToUpperInvariant());
        }
    }
}
