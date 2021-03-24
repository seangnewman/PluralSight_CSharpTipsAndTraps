using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Report
    {
        public string ReportName { get; private set; }

        public Report()
        {
            Console.WriteLine("******** Creating report (default ctor) *********");
            ReportName = "Default";

            // Simulate resource intensive object creation
            Thread.Sleep(10000);
        }
        public Report(string reportName)
        {
            Console.WriteLine($"******** Creating report {reportName} *********");
            ReportName = reportName;

            // Simulate resource intensive object creation
            Thread.Sleep(10000);
        }

        public void Run()
        {
            Console.WriteLine("The report is good....");
        }
    }
}
