using System;
using System.Runtime.InteropServices.ComTypes;

namespace Hibernator.General
{
    public interface IMessageDisplayer
    {
        void DisplayMessage(string msg);
    }

    public class WindowsForms : IMessageDisplayer
    {
        public void DisplayMessage(string msg)
        {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(msg);   
        }
    }

    public class ConsoleMessageDisplayer : IMessageDisplayer
    {
        public void DisplayMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(msg);
        }
    }
}