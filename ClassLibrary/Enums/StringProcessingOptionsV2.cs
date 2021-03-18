using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Enums
{

    // Add flags attribute to indicate intent and provide ToString functionality
    [Flags]
    public enum StringProcessingOptionsV2
    {
        None = 0,
        ConvertToUppercase = 1,
        AddLength = 2,
        // Creating a composite value
        All = ConvertToUppercase | AddLength
    }
}
