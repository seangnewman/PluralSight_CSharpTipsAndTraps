using System;
using System.Runtime.CompilerServices;
using Xunit;
 

namespace Model.Tests
{
    public class PersonShould
    {
        [Fact]
        public void NotifyWhenNameChanged()
        {
            Person sut = new Person();
            Assert.PropertyChanged(sut, "Name", () => sut.Name = "Amrit");
        }

        [Fact]
        public void NotifyWhenAgeChanged()
        {
            Person sut = new Person();
            Assert.PropertyChanged(sut, "Age", () => sut.Age = 42);
        }

        [Fact]
        public void OtherExamples()
        {
            string whatFile = WhatFileCalledMe();
            string whatLine = WhatLineCalledMe();
        }

        private string WhatLineCalledMe([CallerFilePath] string callingFile = null)
        {
            return "I was called from file" + callingFile;
        }

        private string WhatFileCalledMe([CallerLineNumber] int callingLineNum = 0)
        {
            return "I was called from file" + callingLineNum;
        }
    }
}
