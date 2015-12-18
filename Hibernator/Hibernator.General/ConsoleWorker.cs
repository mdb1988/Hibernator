using System;
using System.Threading;

namespace Hibernator.General
{
    public class ConsoleWorker : BaseWorker
    {
        private readonly Watcher _idleWatcher;

        public ConsoleWorker(Watcher idleWatcher) : base(idleWatcher)
        {
            _idleWatcher = idleWatcher;
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
                    Update(10000000,true);
                    base._suspendEvent.Reset();
                    Console.WriteLine("Set new timeout (in minutes)");
                    var newTimeout = Console.ReadLine();
                    var newT = Convert.ToInt16(newTimeout);
                    Update(newT,false);
                    lock (_idleWatcher.monitor)
                    {
                        Monitor.Pulse(_idleWatcher.monitor);
                    }
                    
                    _suspendEvent.Set();
                }
            }
        }
    }
}