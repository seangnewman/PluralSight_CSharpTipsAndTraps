using System;
using System.Collections.Generic;
using System.Numerics;

namespace Chapter2
{
    class Employee
    {
        public string FirstName { get; set; }
        public char EmployeeCode { get; set; }
        public int ProductivityRating { get; set; }
        public List<string> Skills { get; } = new List<string>();

        public string Bio { get; set; }
        public List<int> WorkDays { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public object Id { get; internal set; }
        public BigInteger Salary { get; internal set; }
    }
}
