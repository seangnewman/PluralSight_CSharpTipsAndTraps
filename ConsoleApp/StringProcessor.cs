using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{ 
    public class StringProcessor
    { 
       
        public List<string> ToUpperAndWithLength(List<string> stringsToProcess)
        {
            var results = new List<string>();
            foreach (var s in stringsToProcess)
            {
                //var result = Process(s);
                //results.Add($"{result.Length}-{result.UpperCaseVersion}");
                Process(s);
            }
            return results;

            // Local Function defined in C#7
             void Process(string s)
            {
                results.Add($"{s.Length}-{s.ToUpperInvariant()}");
            }
        }

        //private (int Length, string UpperCaseVersion) Process(string s)
        //{
         

        //    return (s.Length, s.ToUpperInvariant());
        //}
    }
}
