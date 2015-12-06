using System;

namespace Hibernator.General
{
    public class ConsoleMessageDisplayer : IMessageDisplayer
    {
        public void DisplayMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(msg);
        }

        public string Message { get; set; }
    }
}