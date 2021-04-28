using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectEndOfSimester
{
    public partial class kindOfWorker : Form
    {
        public kindOfWorker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            managerF form = new managerF();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newWorker form = new newWorker();
            form.ShowDialog();
        }
    }
}
