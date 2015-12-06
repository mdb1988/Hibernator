using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hibernator.General;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Hibernator.DependencyInjection
{
    public class Bootstrapper
    {
        public static IContainer LoadConfigFor(ApplicationMode mode,Control form = null)
        {
            Registry reg = null;
            switch (mode)
            {
                case ApplicationMode.Console: reg = new ConsoleHibernatorRegistry();
                    break;
                case ApplicationMode.WindowsForms: reg = new WindowsFormsHibernatorRegistry(form);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode", mode, null);
            }
            var container = new Container(reg);

            return container;
        }
    }
}
