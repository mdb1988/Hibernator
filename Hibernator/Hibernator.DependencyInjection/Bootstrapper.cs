using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hibernator.General;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Hibernator.DependencyInjection
{
    public class Bootstrapper
    {
        private static readonly Dictionary<ApplicationMode,Registry> Dictionary = new Dictionary<ApplicationMode, Registry>()
        {
            {ApplicationMode.Console, new ConsoleHibernator()},
            {ApplicationMode.WindowsForms, new WindowsFormsHibernator()},
        };

        public static IContainer LoadConfigFor(ApplicationMode mode)
        {
            var container = new Container(Dictionary[mode]);
            return container;
        }
    }
}
