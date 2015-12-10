using System;
using log4net;

namespace Hibernator.General
{
    public class ConsoleMessageDisplayer : IMessageDisplayer
    {
        private ILog logger = LogManager.GetLogger("Displayer");
        public void DisplayMessage(string msg)
        {
            logger.Info(msg);
        }

        public string Message { get; set; }
    }
}