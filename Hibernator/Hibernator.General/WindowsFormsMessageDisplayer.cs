using System;
using System.Windows.Forms;

namespace Hibernator.General
{
    public class WindowsFormsMessageDisplayer : IMessageDisplayer
    {
        private readonly Control _control;

        public WindowsFormsMessageDisplayer(Control control)
        {
            _control = control;
        }

        public void DisplayMessage(string msg)
        {
            var action = new Action(() => _control.Text = msg);
            action.Invoke();
        }

        public string Message { get; set; }
    }
}