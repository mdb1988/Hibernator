using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hibernator.DependencyInjection;
using Hibernator.General;

namespace Hibernator.WindowsFormsHost
{
    public partial class Form1 : Form
    {
        IWorker worker;
        public Form1()
        {
            InitializeComponent();
            var cont = Bootstrapper.LoadConfigFor(ApplicationMode.WindowsForms,this.richTextBox1);
            worker = cont.GetInstance<IWorker>();
            worker.Work();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            worker.Update(Convert.ToInt32(textBox1.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
