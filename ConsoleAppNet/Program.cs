using DateUtils;
using System;
using System.Text;
using Utilities;

namespace ConsoleAppNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "Hi";
            //StringBuilder b = new StringBuilder();

            //Console.WriteLine($"variable {nameof(a)}  is from {TypeUtils.GetNameSpace(a)}");
            //Console.WriteLine($"variable {nameof(b)}  is from {TypeUtils.GetNameSpace(b)}");

            //Console.WriteLine("Press Enter to exit");
            //Console.ReadLine();''

            var formatter = new DateFormatter();

            string formatNow = formatter.Format(DateTime.Now);

            Console.WriteLine(formatNow);



        }
    }
}
