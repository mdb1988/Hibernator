using Hibernator.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hibernator.DependencyInjection;
using Microsoft.Win32;

namespace Hibernator.ConsoleHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cont = Bootstrapper.LoadConfigFor(ApplicationMode.Console,null);
            var worker = cont.GetInstance<IWorker>();
            worker.Work();
        }
    }
}
