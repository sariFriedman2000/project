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
    public partial class childrensShow : Form
    {
        childrenShow cs = new childrenShow();

        public childrensShow()
        { 

            InitializeComponent();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cs.NameOfShow = this.textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            cs.IdOfShow = this.textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                    cs.LengthOfShow = int.Parse(textBox3.Text);
            }
            catch
            {
                this.textBox3.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text != "")
                    cs.MinAge = int.Parse(this.textBox4.Text);
            }
            catch
            {
                this.textBox4.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                    cs.PriceOfShow = int.Parse(this.textBox5.Text);
            }
            catch
            {
                this.textBox5.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text != "")
                    cs.MaxAge = int.Parse(this.textBox6.Text);
            }
            catch
            {
                this.textBox6.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l5 = new Label();
        Label l4 = new Label();
        Label l6 = new Label();
        private void button2_Click(object sender, EventArgs e)
        {
            cs.reset();
            this.textBox1.Text = null;
            this.textBox2.Text = null;
            this.textBox3.Text = null;
            this.textBox4.Text = null;
            this.textBox5.Text = null;
            this.textBox6.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                l1.Text = "Required field!";
                l1.Location = new Point(375, 105);
                this.Controls.Add(l1);
            }
            else
                l1.Text = "";
            if (this.textBox2.Text == "")
            {

                l2.Text = "Required field!";
                l2.Location = new Point(375, 145);
                this.Controls.Add(l2);
            }
            else
                l2.Text = "";
            if (this.textBox3.Text == "")
            {

                l3.Text = "Required field!";
                l3.Location = new Point(375, 185);
                this.Controls.Add(l3);
            }
            else
                l3.Text = "";
            if (this.textBox4.Text == "")
            {

                l4.Text = "Required field!";
                l4.Location = new Point(375, 225);
                this.Controls.Add(l4);
            }
            else
                l4.Text = "";
            if (this.textBox5.Text == "")
            {
                l5.Text = "Required field!";
                l5.Location = new Point(375, 265);
                this.Controls.Add(l5);
            }
            else
                l5.Text = "";
            if (this.textBox6.Text == "")
            {
                l6.Text = "Required field!";
                l6.Location = new Point(375, 305);
                this.Controls.Add(l6);
            }
            else
                l6.Text = "";
            if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text != "" && this.textBox4.Text != "" && this.textBox5.Text != ""&& this.textBox6.Text != "")
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Details saved successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                    this.Close();
                Program.lcShow.Add(cs);
                DataRow row = DAL.data.Tables["childrenShow"].NewRow();
                row[0] = cs.IdOfShow;
                row[1] = cs.NameOfShow;
                row[2] = cs.MinAge;
                row[3] = cs.MaxAge;
                row[4] = cs.LengthOfShow;
                row[5] = cs.PriceOfShow;
                DAL.data.Tables["childrenShow"].Rows.Add(row);
            }

        }

        private void childrensShow_Load(object sender, EventArgs e)
        {

        }
    }
}
