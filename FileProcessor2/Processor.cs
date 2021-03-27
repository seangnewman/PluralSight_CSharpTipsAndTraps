using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor2
{
    class Processor
    {
        public List<Person> Process(string nameFilePath, string ageFilePathe)
        {
            string[] names = LoadFileContents(nameFilePath);
            string[] ages = LoadFileContents(ageFilePathe);

            return names.Zip(ages,
                                            (name, age) => new Person { Name = name, Age = int.Parse(age) }).ToList();
        }

        private string[] LoadFileContents(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
