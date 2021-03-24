using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class GreetingGenerator
    {
        public static string GreetingPrefix;

        static  GreetingGenerator()
        {
            GreetingPrefix = "Hi!";
            //throw new Exception("Simulated exception in static ctor");
        }

        public string Generate()
        {
            bool isAfternoon = DateTime.Now.Hour >= 12;

            if (isAfternoon)
            {
                return " and good afternnon";
            }

            return " and good morning";
        }
    }
}
