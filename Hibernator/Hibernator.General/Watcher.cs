using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hibernator.General
{
    public class Watcher
    {
        private readonly IMessageDisplayer _messageDisplayer;
        private DateTime _from = DateTime.Now;
        private bool _hibernatedBefore = false;
        private int _timeOut = 70;
        
        public void UpdateParams(int timeout)
        {
            _timeOut = timeout;
            _messageDisplayer.DisplayMessage("Current timeout: " + (_timeOut));
        }
      
        public Watcher(IMessageDisplayer messageDisplayer)
        {
            _messageDisplayer = messageDisplayer;
        }

        public void Watch()
        {
            Thread.Sleep(1000);
            var idle = EnvironmentInfo.GetIdleTime();
            TimeSpan t = TimeSpan.FromMilliseconds(idle);
            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", t.Hours, t.Minutes, t.Seconds);
            _messageDisplayer.DisplayMessage("idle for " + answer);
            if (idle > ((_timeOut * 60000)))
            {
                if (_hibernatedBefore)
                {
                    var suspendAt = _from.AddMinutes(_timeOut);
                    _messageDisplayer.DisplayMessage("Idle time reached. Will suspend at " + suspendAt);
                    if (DateTime.Now > suspendAt)
                    {
                        _messageDisplayer.DisplayMessage("shutting down at " + DateTime.Now);
                        Hibernator.SetSuspendState(true, true, true);
                        UpdateParamsAfterSuspend();
                    }
                }
                else
                {
                    _messageDisplayer.DisplayMessage("shutting down at " + DateTime.Now);
                    Hibernator.SetSuspendState(true, true, true);
                    UpdateParamsAfterSuspend();
                }
            }
        }

        public void UpdateParamsAfterSuspend()
        {
            _from = DateTime.Now;
            _hibernatedBefore = true;
            _messageDisplayer.DisplayMessage("Updated params after suspend.");

        }
    }
}
