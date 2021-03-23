using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        const string InputFileName = "logo.png";
        const string EncodedFileName = "logo.txt";
        const string DecodedFileName = "logo_decoded.png";
        static void Main(string[] args)
        {
            {
                //Project project1 = new Project { Name = "Better UI" };
                ////Project project2 = new AgileProject { Name = "Better UI" };

                //List<Person> team = new List<Person>
                //{
                //    new Person("Sarah"),
                //    new Person("Amrit", 22),
                //    new Person("Anna", 42, "female")

                //};

                //DisplayTeam(team);

                //Console.WriteLine();
                //DisplayPerson("The team: ", team[0]);

                //Console.WriteLine();
                //Display("First person in team", team[0]);

                //Console.WriteLine();
                //Display("Project and leader", project1, team[0]);

                //Console.WriteLine();
                ////Display("Project and team", new object[] { project1, team[0], team[1], team[2] });
                //Display("Project and team", project1, team[0], team[1], team[2]);

                //Console.WriteLine();
                //Display("Project and team", team.ToArray());


                //Console.WriteLine();
                //Console.WriteLine("Press enter to exit");
                //Console.WriteLine();
            }
            #region Casting and Conversions
            ConvertFileToBase64();
            ConvertFileFromBase64();
            ConvertIntToBinary();
            //ConvertDateTimeToBinary();
            //ChangeTypeExample();
            //ChangeTypeExampleV2();
            //ChangeTypeExampleV3();
            ConvertCharacterToNumber();
            #endregion

            object name = "Sarah";

            // Not able to cast to Person, throws and exception
            // Person p = (Person)name;
            // But using as does not throw exception, it returns null if the cast does not work
            Person p = name as Person;

            // If an attempt to dereference name, a null reference is returned
            // Console.WriteLine(p.Name0;
            // so need to check for null
            if( p == null)
            {
                p = new Person { Name = "Default" };
            }





            Console.WriteLine("Press enter to exit");

        }

        private static void ConvertCharacterToNumber()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter a single character representing a numeric value");
            char character = Console.ReadLine().First();

             

            double d = char.GetNumericValue(character);
            Console.WriteLine($"The character has a numeric value of : {d}");

        }

        private static void ChangeTypeExampleV3()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the type to conver to: (System.Int32) (System.Double) (System.Int64)");
            string requestedType = Console.ReadLine();

            object value = 42;
            Type targetType = Type.GetType(requestedType, true);

            object convertedValue = Convert.ChangeType(value, targetType);
            Console.WriteLine($"Converted value: {convertedValue} is a {convertedValue.GetType()}");


        }

        private static void ChangeTypeExampleV2()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the type to conver to: (i)nt (d)ouble (l)ong");
            string requestedType = Console.ReadLine();

            object value = 42;

            Type targetType = null;

            switch (requestedType)
            {
                case "i":
                    targetType = typeof(int);
                    break;
                case "d":
                    targetType = typeof(double);
                    break;
                case "l":
                    targetType = typeof(long);
                    break;

                default:
                    throw new NotSupportedException();
            }

            object convertedValue = Convert.ChangeType(value, targetType);
            Console.WriteLine($"Converted value: {convertedValue} is a {convertedValue.GetType()}");


        }

        private static void ChangeTypeExample()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the type to conver to: (i)nt (d)ouble (l)ong");
            string requestedType = Console.ReadLine();

            object value = 42;

            switch (requestedType)
            {
                case "i":
                    int i = (int)value;
                    Console.WriteLine($"Converted value: {i}");
                    break;
                case "d":
                    double d = (double)value;
                    Console.WriteLine($"Converted value: {d}");
                    break;
                case "l":
                    long l = (long)value;
                    Console.WriteLine($"Converted value: {l}");
                    break;

                default:
                    throw new NotSupportedException();
            }


        }

        private static void ConvertDateTimeToBinary()
        {
            DateTime now = DateTime.Now;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Original now = {now}");

            long nowbinary = now.ToBinary();
            byte[] nowBytes = BitConverter.GetBytes(nowbinary);
            Console.WriteLine($"Now byes  = '{string.Join(" ", nowBytes)}'");

            long nowBinaryConvertedBack = BitConverter.ToInt64(nowBytes, 0);

            DateTime nowConvertedBack = DateTime.FromBinary(nowBinaryConvertedBack);

            Console.WriteLine($"Now converted back = {nowConvertedBack}");

        }

        private static void ConvertIntToBinary()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Please enter your age: ");
            string input = Console.ReadLine();

            int age = int.Parse(input);

            byte[] intBytes = BitConverter.GetBytes(age);

            Console.WriteLine($"age {age} int bytes = '{string.Join(" ", intBytes)}'");

           
        }

        private static void ConvertFileFromBase64()
        {
            string base64String = File.ReadAllText(EncodedFileName);
            byte[] fileBytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(DecodedFileName, fileBytes);
        }

        private static void ConvertFileToBase64()
        {
            byte[] originalBytes = File.ReadAllBytes(InputFileName);
            Console.WriteLine($"Original file size {originalBytes.Length} byes");

            string base64String = Convert.ToBase64String(originalBytes);

            File.WriteAllText(EncodedFileName, base64String);

            var encodedFileInfo = new FileInfo(EncodedFileName);

            Console.WriteLine($"Base64 encoded file size {encodedFileInfo.Length} byes");
        }

        //private static void Display(string title, object[] objects)
        //{
        //    Console.WriteLine(title);
        //    foreach (var obj in objects)
        //    {
        //        Console.WriteLine(obj);
        //    }
        //}

        //params keyword specifies an indeterminate number of arguments
        private static void Display(string title, params object[] objects)
        {
            Console.WriteLine(title);

            foreach (var obj in objects)
            {
                Console.WriteLine(obj);
            }
        }

        private static void Display(string title, Object o, Object o2)
        {
            Console.WriteLine(title);
            Console.WriteLine(o);
            Console.WriteLine(o2);
        }

        private static void Display(string title, object o)
        {
            Console.WriteLine(title);
            Console.WriteLine(o);
        }

        private static void DisplayPerson(string title, Person person)
        {
            Console.WriteLine(title);
            Console.WriteLine($"{person.Name,-20} {person.Age,-5} {person.Gender,-10}");
        }

        private static void DisplayTeam(List<Person> team)
        {
            Console.WriteLine("Team");
            Console.WriteLine("----");
            foreach (var person in team)
            {
                Console.WriteLine($"{person.Name,-20} {person.Age,-5} {person.Gender,-10}");
            }
        }
    }
}
