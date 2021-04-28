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

   public partial class CFM : Form
    {
        string id = "";
        int sumOfHours;
        Label l1 = new Label();
        Label l2 = new Label();

      manager c = new manager();
    
        public CFM()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.id = this.textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.sumOfHours = int.Parse(this.textBox2.Text);
            }
            catch
            {
                if (this.textBox2.Text != "")
                {
                    MessageBox.Show("Digit only");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {

                l1.Text = "Required field!";
                l1.Location = new Point(450, 160);
                this.Controls.Add(l1);
            }
            else
                l1.Text = "";
            if (this.textBox2.Text == "")
            {

                l2.Text = "Required field!";
                l2.Location = new Point(450, 210);
                this.Controls.Add(l2);
            }
            else
                l2.Text = "";

            if (this.textBox1.Text != "" && this.textBox2.Text != "")
            {
                double result = c.calculationOfSalary(id, sumOfHours);
                if (result == -1)
                    MessageBox.Show("The user does not exist in the system!");
                else
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("your salart is: " + result, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                        this.Close();
                }
            }
        }

        private void CFM_Load(object sender, EventArgs e)
        {

        }
    }
}
