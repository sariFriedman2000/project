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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            privateC form = new privateC();
            form.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
           businessC form = new businessC();
            form.ShowDialog();
        }

        
    }
}
