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
    public partial class mainForm : Form
    {
        DAL d = new DAL();
        public mainForm()
        {
            InitializeComponent();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        { 
            d.updateDataBase();
            base.OnFormClosed(e);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            d.connectionToDataBase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kindOfWorker form = new kindOfWorker();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newShow form = new newShow();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            newHall form = new newHall();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            newPresentation formP = new newPresentation();
            formP.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Customers form = new Customers();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            invitadS form = new invitadS();
            form.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            d.updateDataBase();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            calculationForm form = new calculationForm();
            form.ShowDialog();
        }
    }
}
