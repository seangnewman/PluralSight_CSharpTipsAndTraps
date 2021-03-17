using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee();

            employee.FirstName = GetFirstName();
            employee.ProductivityRating = GetProductivity();
            employee.DateOfBirth = GetDateOfBirth();
            employee.Salary = GetSalary();
            employee.Id = GenerateRandomId();
            employee.WorkDays = GenerateDefaultWorkDays();
            GetSkillsFor(employee);
            GetBioFor(employee);

            DisplayEmployee(employee);

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            //Console.ReadLine();
        }

        private static object GenerateRandomId()
        {

            #region Creating cryptographically secure random numbers
            using (RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[4];         // an integer is 4 bytes
                rnd.GetBytes(randomBytes);

               return  BitConverter.ToInt32(randomBytes, 0);

                

            }
             
            #endregion
            #region creating Random numbers
            //Random rnd = new Random();          // default system clock as seed
            //Random rnd2 = new Random(42);
            //Random rnd3 = new Random(42);

            //int x = rnd2.Next();
            //int y = rnd3.Next();
            //int z = rnd.Next();

            //return rnd.Next();
            #endregion  
        }


        private static BigInteger GetSalary()
        {
            #region Representing Arbitrarily Large Integer Values
            Console.WriteLine("Please enter salary");
            BigInteger value = BigInteger .Parse(Console.ReadLine());
            return value;
            #endregion
        }

        private static DateTime GetDateOfBirth()
        {
            #region Preventing Ambiguous DateTime Parsing/Mis-Parsing
            Console.WriteLine("Please enter date of birth");

            string input = Console.ReadLine();
            //DateTime dob = DateTime.Parse(input);
            DateTime dob = DateTime.ParseExact(input, "MM/dd/yyyy", null);

            #region Parsing DateTime with DateTimeStyles
            DateTime d1 = DateTime.Parse("01/12/2000");
            DateTime d2 = DateTime.Parse("01/12/2000", null, DateTimeStyles.AssumeUniversal);
            DateTime d3 = DateTime.Parse("01/12/2000", null, DateTimeStyles.AssumeLocal);
            DateTime d4 = DateTime.Parse("13:30:00");
            DateTime d5 = DateTime.Parse("13:30:00", null, DateTimeStyles.NoCurrentDateDefault);
            #endregion


            return dob;
            #endregion
        }

        private static List<int> GenerateDefaultWorkDays()
        {
            #region Generating Sequence of Integers
            var days = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                days.Add(i);
            }

            string temp = string.Join(", ", days);
             
            return days;

            //return Enumerable.Range(1, 5).Select(x => x * 2).ToList();
            #endregion
        }

        private static void DisplayEmployee(Employee employee)
        {
            Console.WriteLine("Employee Details");
            Console.WriteLine("-----------------");
            Console.WriteLine();

           

            Console.WriteLine($"First Name: {employee.FirstName} Employee Code: {employee.EmployeeCode}");

           
            string theHarderWay = "First Name: " + employee.FirstName.PadRight(20) + "Employee Code: " + employee.EmployeeCode.ToString().PadRight(5);
            Console.WriteLine(theHarderWay);
            // Using negative values aligns left
            string easierWay = string.Format("First Name: {0,-20} Employee Code: {1, -5}", employee.FirstName, employee.EmployeeCode);
            Console.WriteLine(easierWay);
            // Using interpolation
            Console.WriteLine($"First Name: {employee.FirstName,-20} Employee Code: {employee.EmployeeCode,-5}");
            // Right aligned
            Console.WriteLine($"First Name: {employee.FirstName,20} Employee Code: {employee.EmployeeCode,5}");
            
            Console.WriteLine($"Productivity rating: {employee.ProductivityRating}");
            const string threePartFormat = "(good employee) #;(bad employee) -#; (new employee - no productivity recorded yet)";
            Console.WriteLine(employee.ProductivityRating.ToString(threePartFormat));
            
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
            string prod = string.Format(new EmployeeProductivityFormatProvider(),
                                                            "Productivity rating: {0}",                                 // Formatting string
                                                            employee.ProductivityRating);                           // value o format

            Console.WriteLine(prod);

            Console.WriteLine($"Date of Birth: {employee.DateOfBirth}");

            Console.WriteLine($"Employee Id: {employee.Id}");

            string temp = string.Join(", ", employee.WorkDays);
            Console.WriteLine($"Work Days: {temp}");
            
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
            #region Parsing Strings into Numbers
            
            Console.WriteLine("Please enter productivity rating (-100 to 100) enter 0 for new employees");
             // NumberStyles can be used to specify ustom operations
            int rating = Int32.Parse(Console.ReadLine(), NumberStyles.Integer);
            #endregion

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
