using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ClassLibrary.Tests
{
    public class ObjectReferenceEqualsExample
    {

        [Fact]
        public void ExampleWhereReferenceTypeUsesValueEqualitySemantics()
        {
            Uri a = new Uri("https://pluralsight.com");
            Uri b = new Uri("https://pluralsight.com");

            var areEqual = a == b;

            bool isSameReference = object.ReferenceEquals(a, b);
            b = a;
            isSameReference = object.ReferenceEquals(a, b);
        }
    }
}
