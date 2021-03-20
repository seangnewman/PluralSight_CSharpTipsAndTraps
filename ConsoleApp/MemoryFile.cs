using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class MemoryFile
    {
        public byte[] Bytes { get;  }
        public MemoryFile(string path)
        {
            Bytes = File.ReadAllBytes(path);

            // validation/error checking ommitted
        }


        // Reserved key words can be used by prefixing the keyword with the @ symbol
        public void SetFirstByte(byte @byte)
        {
            Bytes[0] = @byte;
        }

        public byte this[int i] { get =>  Bytes[i]; set => Bytes[i] = value;  }
    }

    
}
