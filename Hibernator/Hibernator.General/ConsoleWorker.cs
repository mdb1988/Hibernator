using System;
using System.Threading;

namespace Hibernator.General
{
    public class ConsoleWorker : BaseWorker
    {

        public ConsoleWorker(Watcher idleWatcher) : base(idleWatcher)
        {
            base._watcherThread = new Thread(base.CheckIdleTime);
            base._listenerThread = new Thread(Listen);
        }
     

        public void Listen()
        {
            while (true)
            {
                if ((!(Console.KeyAvailable && Console.ReadLine() == "change")))
                {
                }
                else
                {
                    base._suspendEvent.Reset();
                    Console.WriteLine("Set new timeout (in minutes)");
                    var newTimeout = Console.ReadLine();
                    var newT = Convert.ToInt16(newTimeout);
                    Update(newT);
                    _suspendEvent.Set();
                }
            }
        }
    }
}