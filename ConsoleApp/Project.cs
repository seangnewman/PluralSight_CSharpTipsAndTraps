// Clock exists in both namespaces
// Use alias to reolve

using AnalogClock = ConsoleApp.Analog;
using DigitalClock = ConsoleApp.Digital.Clock;

namespace ConsoleApp
{
    class Project
    {
        public string Name { get; set; }

        public AnalogClock.Clock TimeLeft { get; set; }     // Analog
        public DigitalClock TimeElapsed { get; set; } // Digital

        public Project()
        {

            // This can result in issues as the Initialize method is virtual, dangerous to call within constructor
            // No way to tell how Initialize() is implemented in derived classes/types
            Initialize();
        }

        protected virtual void Initialize()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
