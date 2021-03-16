using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee();

            employee.FirstName = GetFirstName();
            employee.EmployeeCode = GetEmployeeCode();
            employee.ProductivityRating = GetProductivity();
            GetSkillsFor(employee);
            GetBioFor(employee);

            DisplayEmployee(employee);

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            //Console.ReadLine();
           
        }

        private static void DisplayEmployee(Employee employee)
        {
            Console.WriteLine("Employee Details");
            Console.WriteLine("-----------------");
            Console.WriteLine();

            #region String Formatting and String Interpolation
            //ToDo
            //Console.WriteLine("First Name: " + employee.FirstName + " Employee Code: " + employee.EmployeeCode);
            //string line = string.Format("First Name: {0} Employee Code: {1}", employee.FirstName, employee.EmployeeCode);
            //Console.WriteLine(line);
            //line = $"First Name: {employee.FirstName} Employee Code: {employee.EmployeeCode}";
            //Console.WriteLine(line);
            

            Console.WriteLine($"First Name: {employee.FirstName} Employee Code: {employee.EmployeeCode}");

            #endregion

            #region Formatting and Aligning Values
            string theHarderWay = "First Name: " + employee.FirstName.PadRight(20) + "Employee Code: " + employee.EmployeeCode.ToString().PadRight(5);
            Console.WriteLine(theHarderWay);
            // Using negative values aligns left
            string easierWay = string.Format("First Name: {0,-20} Employee Code: {1, -5}", employee.FirstName, employee.EmployeeCode);
            Console.WriteLine(easierWay);
            // Using interpolation
            Console.WriteLine($"First Name: {employee.FirstName, -20} Employee Code: {employee.EmployeeCode, -5}");
            // Right aligned
            Console.WriteLine($"First Name: {employee.FirstName,20} Employee Code: {employee.EmployeeCode,5}");
            #endregion

            #region Conditional Formatting for Positive, Negative and Zero Numbers
            Console.WriteLine($"Productivity rating: {employee.ProductivityRating}");
            const string threePartFormat = "(good employee) #;(bad employee) -#; (new employee - no productivity recorded yet)";
            Console.WriteLine(employee.ProductivityRating.ToString(threePartFormat));
            #endregion

            #region Building Strings with StringBuilder
            string skills = "";
            foreach (var skill in employee.Skills)
            {
                 skills += $"{skill}, ";
            }
            Console.WriteLine($"Skills: {skills}");         // Ignoring trailing comma for demo

            var sb = new StringBuilder();

            foreach (var skill in employee.Skills)
            {
                sb.Append(skill);
                sb.Append(", ");
            }
            //Console.WriteLine($"Skills: {sb.ToString()}");
            Console.WriteLine($"Skills: {sb}");
            #endregion
            #region Creating Custom Format Providers
            string prod = string.Format(new EmployeeProductivityFormatProvider(),
                                                            "Productivity rating: {0}",                                 // Formatting string
                                                            employee.ProductivityRating);                           // value o format

            Console.WriteLine(prod);
            #endregion  
        }

        private static void GetBioFor(Employee employee)
        {
            // Simulate getting bio from user-input
            employee.Bio = "A darn hard working employee, dash it the best we have.";
        }

        private static void GetSkillsFor(Employee employee)
        {
            // Simulate getting skills from input

            employee.Skills.Add("C#");
            employee.Skills.Add("HTML");
            employee.Skills.Add("SQL");
            employee.Skills.Add("JSON");
           
        }

        private static int GetProductivity()
        {
            Console.WriteLine("Please enter productivity rating (-100 to 100) enter 0 for new employees");
            int rating = Int32.Parse(Console.ReadLine());                         // additional validation omitted
            return rating;
        }

        private static char GetEmployeeCode()
        {
            while (true)
            {
                Console.WriteLine("Please enter employee code");
                #region Testing Char Unicode Validity
                char employeeCode = Console.ReadLine().First();         // Additional validtion omitted
                // For testing only
                //employeeCode = (char)888;

                UnicodeCategory uCategory = char.GetUnicodeCategory(employeeCode);

                bool isValidUnicode = uCategory != UnicodeCategory.OtherNotAssigned;

                if (!isValidUnicode)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: Invalid employee code(invalid character)");
                }
                else
                {
                    return employeeCode;
                }

                #endregion
                //return employeeCode;
            }
        }

        private static string GetFirstName()
        {
            while (true)
            {
                Console.WriteLine("Please enter first name");
                string firstName = Console.ReadLine();
                #region Simplifying String Empty and Null checking code
                //if (firstName == null || firstName.Length == 0 || IsAllWhiteSpace(firstName))
                // Simplify with string.IsNullOrWhiteSpace()
                if (string.IsNullOrWhiteSpace(firstName))
               
                {
                    Console.WriteLine("ERROR : Invalid first name");
                }
                else
                {
                    return firstName;
                }
                #endregion

            }
        }

        private static bool IsAllWhiteSpace(string s)
        {
            if (s.Replace(" ", "").Length == 0)
            {
                return true;
            }

            return false;
        }
    }
}
