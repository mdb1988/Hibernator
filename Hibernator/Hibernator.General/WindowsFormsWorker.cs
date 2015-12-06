using System;
using System.Threading;

namespace Hibernator.General
{
    public class WindowsFormsWorker : BaseWorker
    {
        public WindowsFormsWorker(Watcher idleWatcher) : base(idleWatcher)
        {
            _watcherThread = new Thread(base.CheckIdleTime);
        }
    }
}