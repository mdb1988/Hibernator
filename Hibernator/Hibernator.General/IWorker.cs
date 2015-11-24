using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernator.General
{
    interface IWorker
    {
        void Watch();
        void Listen();
        void Update();
    }
}
