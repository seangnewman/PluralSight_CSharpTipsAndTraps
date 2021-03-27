using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Model.Tests
{
    public class NullCoalescingOperatorExample
    {
        [Fact]
        public void NoNullCoalescingOperator()
        {
            string inputName = null;
            string outputName;

            if (inputName is null)
            {
                outputName = "no name provided";
            }
            else
            {
                outputName = inputName;
            }
        }

        [Fact]
        public void NullCoalescingOperator()
        {
            string inputName = null;
            string outputName;

            // If the input value is null.. return no name provided
            outputName = inputName ?? "no name provided";
        }

        [Fact]
        public void NullCoalescingOperatorAndNullConditional()
        {
            string inputName = null;
            string upperName;

            //if (inputName is null)
            //{
            //    upperName = "no name provided";
            //}
            //else
            //{
            //    upperName = inputName.ToUpperInvariant();
            //}

            // If inputName is null then the ToUpperInvariant will not be called
            upperName = inputName?.ToUpperInvariant() ?? "no name provided";
        }

        [Fact]
        public void NullableValueTypes()
        {
            int? age = null;

            int result = age ?? -1;

        }

        [Fact]
        public void Chaining()
        {
            int? localDefaultAge = null;
            int globalDefaultAge = 99;

            int? age = null;

            // if age is null then use locaDefaultAge, if localDefaultAge is null then default globalDefaultAge
            int result = age ?? localDefaultAge ?? globalDefaultAge;
        }

    }
}
