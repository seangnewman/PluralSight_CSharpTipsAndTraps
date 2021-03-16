using System.Collections.Generic;

namespace Chapter1
{
    class Employee
    {
        public string FirstName { get; set; }
        public char EmployeeCode { get; set; }
        public int ProductivityRating { get; set; }
        public List<string> Skills { get; } = new List<string>();

        public string Bio { get; set; }


    }
}
