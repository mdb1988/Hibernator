using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Hibernator.General;
using StructureMap.Configuration.DSL;

namespace Hibernator.DependencyInjection
{
    public class WindowsFormsHibernator : Registry
    {
        public WindowsFormsHibernator()
        {
            For<IWorker>().Use<ConsoleWorker>();
            For<IMessageDisplayer>().Use<WindowsForms>();
        }
    }
}