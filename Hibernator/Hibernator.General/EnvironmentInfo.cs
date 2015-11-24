using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hibernator.General
{
    public class EnvironmentInfo
    {
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();

        public static uint GetIdleTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            //TimeSpan t = TimeSpan.FromMilliseconds(millisecond);
            //format(t);
            //var s = TimeSpan.FromMilliseconds(lastInPut.dwTime);
            //format(s);

            return ((uint)Environment.TickCount - lastInPut.dwTime);
          //  return ((uint)millisecond - lastInPut.dwTime);
        }

        private static void format(TimeSpan t)
        {
            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s{3:D2}ms", t.Hours, t.Minutes, t.Seconds,t.Milliseconds);
            Console.WriteLine(answer);
        }

        public static long GetLastInputTime()
        {
            LASTINPUTINFO lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);

            if (!GetLastInputInfo(ref lastInPut))
            {
                throw new Exception(GetLastError().ToString());
            }

            return lastInPut.dwTime;
        }

        internal struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }
    }
}
