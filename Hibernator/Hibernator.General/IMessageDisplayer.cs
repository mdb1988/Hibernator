using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Hibernator.General
{
    public interface IMessageDisplayer
    {
        void DisplayMessage(string msg);
        string Message { get; set; }
    }
}