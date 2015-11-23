using Hibernator.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hibernator.ConsoleHost
{
    public class Program
    {
        static Watcher w = new Watcher();
        static Thread listenThread = new Thread(Listener);
        static Thread watcherThread = new Thread(Watch);
        static ManualResetEvent _suspendEvent = new ManualResetEvent(true);

        public static void Main(string[] args)
        {

            var started = DateTime.Now;
            Console.WriteLine("Started hibernate watch at " + started);
            listenThread = new Thread(Listener);
            listenThread.Start();
            watcherThread = new Thread(Watch);
            watcherThread.Start();
        }


        public static void Watch()
        {
            while (true)
            {
                _suspendEvent.WaitOne(Timeout.Infinite);
                w.Watch();
            }

        }

        public static void Listener()
        {
            while (true)
            {

                if ((!(Console.KeyAvailable && Console.ReadLine() == "change")))
                {

                }
                else
                {
                    _suspendEvent.Reset();
                    Do();
                    _suspendEvent.Set();
                }
            }
        }

        public static void Do()
        {
            Console.WriteLine("Set new timeout (in minutes)");
            var newTimeout = Console.ReadLine();
            var newT = Convert.ToInt16(newTimeout);
            w.UpdateParams(newT);
        }

    }
}
