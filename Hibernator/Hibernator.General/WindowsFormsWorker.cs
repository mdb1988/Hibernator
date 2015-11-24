using System;
using System.Threading;

namespace Hibernator.General
{
    public class WindowsFormsWorker : IWorker
    {
        private readonly Watcher _idleWatcher;
        private readonly Thread _watcherThread;
        private readonly Thread _listenerThread;
        readonly ManualResetEvent _suspendEvent = new ManualResetEvent(true);

        public WindowsFormsWorker(Watcher idleWatcher)
        {
            _idleWatcher = idleWatcher;
            _watcherThread = new Thread(CheckIdleTime);
           // _listenerThread = new Thread(Listen);
        }

        public void CheckIdleTime()
        {
            while (true)
            {
                _suspendEvent.WaitOne(Timeout.Infinite);
                _idleWatcher.Watch();
            }
        }


        //public void Listen()
        //{
        //_suspendEvent.Reset();
        //Update(TODO);
        //_suspendEvent.Set();
        //}

        public void Update(int timeout)
        {
            _idleWatcher.UpdateParams(timeout);
        }

        public void Work()
        {
            _watcherThread.Start();
          //  _listenerThread.Start();
        }
    }
}