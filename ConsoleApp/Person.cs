using System;
namespace ConsoleApp
{
    internal class Person
    {
        private const string DefaultGender = "default";
        public string Name { get; internal set; }
        public int Age { get; internal set; }
        public string Gender { get; internal set; }


        //public Person(string name)
        //{
        //    Name = name;
        //    Age = -1;
        //    Gender = DefaultGender;
        //}

        //public Person(string name, int age) 
        //{
        //    Name = name;
        //    Age = age;
        //    Gender = DefaultGender;
        //}
        public Person()
        {

        }
        public Person(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        // Constructor Chaining
        public Person(string name) : this(name, -1, DefaultGender)
        {

        }

        public Person(string name, int age) : this(name, age, DefaultGender)
        {

        }
        public override string ToString()
        {
            return Name;
        }

       
    }
}