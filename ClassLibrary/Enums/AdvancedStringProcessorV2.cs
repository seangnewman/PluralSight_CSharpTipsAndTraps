using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Enums
{
    public class AdvancedStringProcessorV2
    {
        public List<string> Process(List<string> stringsToProcess, StringProcessingOptionsV2 options)
        {
            bool noProcessingIsRequired = options == StringProcessingOptionsV2.None;
            bool conversionToUppderCaseIsRequired = (options & StringProcessingOptionsV2.ConvertToUppercase) != 0;
            bool addingLengthIsRequired = options.HasFlag(StringProcessingOptionsV2.AddLength);

            var processedString = new List<string>();

            foreach (var originalString in stringsToProcess)
            {
                string temp = "";

                if (noProcessingIsRequired)
                {
                    processedString.Add(originalString);
                    continue;
                }

                if (addingLengthIsRequired)
                {
                    temp += $"{originalString.Length}-";
                }
                if (conversionToUppderCaseIsRequired)
                {
                    temp += originalString.ToUpperInvariant();
                }
                else
                {
                    temp += originalString;
                }

                processedString.Add(temp);

            }

            return processedString;

        }
    }
}
