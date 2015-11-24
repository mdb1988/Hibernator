using System.Runtime.InteropServices;

namespace Hibernator.General
{
    public class Hibernator
    {
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent); 
    }
}