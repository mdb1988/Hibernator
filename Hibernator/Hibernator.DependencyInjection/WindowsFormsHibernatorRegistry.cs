using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Hibernator.General;
using StructureMap.Configuration.DSL;

namespace Hibernator.DependencyInjection
{
    public class WindowsFormsHibernatorRegistry : Registry
    {
        public WindowsFormsHibernatorRegistry(Control form)
        {
            For<IWorker>().Use<WindowsFormsWorker>();
            For<IMessageDisplayer>().Use<WindowsFormsMessageDisplayer>().Ctor<Control>("form").Is(form);
        }
    }
}