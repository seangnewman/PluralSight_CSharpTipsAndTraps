using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor2
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor processor = new Processor();

            try
            {
                List<Person> people = processor.Process("Names.txt", "Ages.txt");

                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Name}, {person.Age}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex); ;
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
        }
    }
}
