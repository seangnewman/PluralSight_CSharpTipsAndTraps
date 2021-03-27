using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Model.Tests
{
    public class ShortCircuitingConditionalOperatorsExample
    {
        [Fact]
        public void NonShortCircuit()
        {
            const string name = "Sarah";
            bool isValid = false;

            // Short circuiting logical AND
            //bool shouldContinue = isValid && CheckName(name);

            //even if the first value is false,  both conditions are false
            //bool shouldContinue = isValid & CheckName(name);
          //  bool shouldContinue = isValid || CheckName(name);

            //even if the first value is false,  both conditions are false
            bool shouldContinue = isValid | CheckName(name);

            bool CheckName(string nameToCheck)
            {
                return nameToCheck == "Sarah";
            }

        }
    }
}
