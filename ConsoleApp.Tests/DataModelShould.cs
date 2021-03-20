using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleApp.Tests
{
    public class DataModelShould
    {
        [Fact]
        public void HavDefaultStatus()
        {
            var sut = new DataModel();
            Assert.Equal("New", sut.Status);
        }

        [Fact]
        public void ClearStatus()
        {
            var sut = new DataModel();
            sut.ClearStatus();
            Assert.Equal("", sut.Status);
        }
    }
}
