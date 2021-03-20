using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Project project1 = new Project { Name = "Better UI" };
            //Project project2 = new AgileProject { Name = "Better UI" };

            List<Person> team = new List<Person>
            {
                new Person("Sarah"),
                new Person("Amrit", 22),
                new Person("Anna", 42, "female")

            };

            DisplayTeam(team);

            Console.WriteLine();
            DisplayPerson("The team: ", team[0]);

            Console.WriteLine();
            Display("First person in team", team[0]);

            Console.WriteLine();
            Display("Project and leader", project1, team[0]);

            Console.WriteLine();
            //Display("Project and team", new object[] { project1, team[0], team[1], team[2] });
            Display("Project and team", project1, team[0], team[1], team[2]);

            Console.WriteLine();
            Display("Project and team", team.ToArray());


            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.WriteLine();

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

        private static void Display(string title, object  o)
        {
            Console.WriteLine(title);
            Console.WriteLine(o);
        }

        private static void DisplayPerson(string title, Person person)
        {
            Console.WriteLine(title);
            Console.WriteLine($"{person.Name, -20} {person.Age, -5} {person.Gender, -10}");
        }

        private static void DisplayTeam(List<Person> team)
        {
            Console.WriteLine("Team");
            Console.WriteLine("----");
            foreach (var person in team)
            {
                Console.WriteLine($"{person.Name, -20} {person.Age, -5} {person.Gender, -10}");
            }
        }
    }
}
