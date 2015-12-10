using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Hibernator.General;
using log4net.Config;
using StructureMap.Configuration.DSL;

namespace Hibernator.DependencyInjection
{
    public class ConsoleHibernatorRegistry : Registry
    {
        public ConsoleHibernatorRegistry()
        {
            XmlConfigurator.Configure();
            For<BaseWorker>().Use<ConsoleWorker>();
            For<IMessageDisplayer>().Use<ConsoleMessageDisplayer>();
        }

    }
}