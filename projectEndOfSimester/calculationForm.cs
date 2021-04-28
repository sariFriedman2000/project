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
    public partial class calculationForm : Form
    {
        public calculationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CFM form = new CFM();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CFW form = new CFW();
            form.ShowDialog();
        }
    }
}
