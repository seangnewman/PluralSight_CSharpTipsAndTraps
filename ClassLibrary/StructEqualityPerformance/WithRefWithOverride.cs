using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.StructEqualityPerformance
{
    public struct WithRefWithOverride
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Description { get; set; }


        // The override bypasses reflection based approach and improves performance
        public override bool Equals(object obj)
        {

            
            if (!(obj is WithRefWithOverride))
            {
                return false;
            }

            var other = (WithRefWithOverride)obj;
            return X == other.X && Y == other.Y && Description == other.Description;
        }
    }

    // GetHashCode override and = != ommitted
}
