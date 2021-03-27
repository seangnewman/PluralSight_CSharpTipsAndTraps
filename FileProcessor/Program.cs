using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            JoinNamesAndAges();

            SetOperations();

            Console.WriteLine("Press enter to exit");
        }

        private static void SetOperations()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter first sequence of ints (separated by commas):");
            IEnumerable<int> firstSequence = Console.ReadLine().Split(',').Select(x => int.Parse(x));

            Console.WriteLine("Please enter second sequence of ints (separated by commas):");
            IEnumerable<int> secondSequence = Console.ReadLine().Split(',').Select(x => int.Parse(x));

            IEnumerable<int> concat = firstSequence.Concat(secondSequence);
            Display(concat, "Concat results");

            // Union method removes duplicates from sequence
            IEnumerable<int> union = firstSequence.Union(secondSequence);
            Display(union, "Union results");

            // Intersect returns common values in both lists
            IEnumerable<int> intersect = firstSequence.Intersect(secondSequence);
            Display(intersect, "Intersect results");

            // Intersect returns elements in first sequence but not in  second
            IEnumerable<int> except = firstSequence.Except(secondSequence);
            Display(except, "Intersect results");

            string[] names = new[] { "Sarah", "Gentry", "Amrit" };
            IEnumerable<string> namesResult = names.Except(new[] { "Sarah", "Amrit", "Mark" });
            Display(namesResult, "String Except results");


            void Display<T>(IEnumerable<T> items, string title)
            {
                Console.WriteLine();
                Console.WriteLine(title);

                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }


        }

        private static void JoinNamesAndAges()
        {
            string[] names = File.ReadAllLines("Names.txt");
            string[] ages = File.ReadAllLines("Ages.txt");

            List<string> namesAndAges = Join(names, ages);
            Display(namesAndAges);

            List<string> namesAndages2 = JoinV2(names, ages);
            Display(namesAndages2);

            List<(string name, string age)> namesAndAges3 = JoinV3(names, ages);
            Console.WriteLine();
            Console.WriteLine("Output Tuples");
            foreach (var tuple in namesAndAges3)
            {
                Console.WriteLine($"{tuple.name}, {tuple.age}");
            }

            string[] namesExtra = File.ReadAllLines("NamesExtra.txt");
            List<string> namesAndAges4 = JoinV2(namesExtra, ages);
            Display(namesAndAges4);


            void Display(IEnumerable<string> strings)
            {
                Console.WriteLine();
                Console.WriteLine("Output: ");

                foreach (var @string in strings)
                {
                    Console.WriteLine(@string);
                }
            }
        }

        private static List<string> Join(string[] names, string[] ages)
        {
            List<string> joined = new List<string>();

            for (int i = 0; i < names.Length; i++)
            {
                joined.Add($"{names[i]}, {ages[i]}");
            }

            return joined;
        }

        private static List<string> JoinV2(string[] names, string[] ages)
        {
            //IEnumerable<string> joined = names.Zip(ages, (name, age) => $"{name}, {age}");
            //return joined.ToList();

            //Zip only merges sequences with equal items  In the case of NamesExtra the last entry (Sofia) wil not merge as there is no
            // corresponding age
            return names.Zip(ages, (name, age) => $"{name}, {age}").ToList();
        }

        private static List<(string name, string age)> JoinV3(string[] names, string[] ages)
        {
            return names.Zip(ages, (name, age) => (name, age)).ToList();
        }
    }
}
