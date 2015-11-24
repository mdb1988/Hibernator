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
    public class ConsoleHibernator : Registry
    {
        public ConsoleHibernator()
        {
            For<IWorker>().Use<ConsoleWorker>();
            For<IMessageDisplayer>().Use<ConsoleMessageDisplayer>();
        }

    }
}