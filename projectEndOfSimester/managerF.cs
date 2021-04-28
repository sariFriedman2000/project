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
    public partial class managerF : Form
    {

       manager m = new manager();
        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l5 = new Label();
        Label l4 = new Label();
        public managerF()
        {
            InitializeComponent();
        }

        private void managerF_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            m.NameManager = this.textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            m.IdManager = this.textBox2.Text;
        }

        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                   m.PriceOfHour = int.Parse(this.textBox5.Text);
            }
            catch
            {
                this.textBox5.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {

                l1.Text = "Required field!";
                l1.Location = new Point(440, 150);
                this.Controls.Add(l1);
            }
            else
                l1.Text = "";
            if (this.textBox2.Text == "")
            {

                l2.Text = "Required field!";
                l2.Location = new Point(440, 183);
                this.Controls.Add(l2);
            }
            else
                l2.Text = "";
            if (this.textBox5.Text == "")
            {

                l3.Text = "Required field!";
                l3.Location = new Point(440, 220);
                this.Controls.Add(l3);
            }
            else
                l3.Text = "";
           
           
            if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox5.Text != "")
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Details saved successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                    this.Close();
                Program.lManager.Add(m);
                DataRow row = DAL.data.Tables["manger"].NewRow();
                row[0] = m.IdManager;
                row[1] = m.NameManager;
                row[2] = m.NumOfSaleTicketOfWorkers;
                row[3] = m.PriceOfHour;
                DAL.data.Tables["manger"].Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m.reset();
            this.textBox1.Text = null;
            this.textBox2.Text = null;
            this.textBox5.Text = null;
        }
    }
}
