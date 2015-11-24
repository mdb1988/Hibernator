using System;
using System.Threading;

namespace Hibernator.General
{
    public interface IWorker
    {
        //void CheckIdleTime();
        //void Listen();
        void Update();
        void Work();
    }

    public class ConsoleWorker : IWorker
    {
        private readonly Watcher _idleWatcher;
        private readonly Thread _watcherThread;
        private readonly Thread _listenerThread;
        readonly ManualResetEvent _suspendEvent = new ManualResetEvent(true);

        public ConsoleWorker(Watcher idleWatcher)
        {
         _idleWatcher = idleWatcher;
         _watcherThread = new Thread(CheckIdleTime);
         _listenerThread = new Thread(Listen);
        }


        public void CheckIdleTime()
        {
            while (true)
            {
                _suspendEvent.WaitOne(Timeout.Infinite);
                _idleWatcher.Watch();
            }
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
                    _suspendEvent.Reset();
                   Update();
                    _suspendEvent.Set();
                }
            }
        }

        public void Update()
        {
            Console.WriteLine("Set new timeout (in minutes)");
            var newTimeout = Console.ReadLine();
            var newT = Convert.ToInt16(newTimeout);
            _idleWatcher.UpdateParams(newT);
        }

        public void Work()
        {
            _watcherThread.Start();
            _listenerThread.Start();
        }
    }
}
