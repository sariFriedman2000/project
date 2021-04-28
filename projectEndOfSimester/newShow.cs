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
    public partial class newShow : Form
    {
        public newShow()
        {
            InitializeComponent();
        }

        private void newShow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adultsEvent form = new adultsEvent();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            childrensShow form = new childrensShow();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
