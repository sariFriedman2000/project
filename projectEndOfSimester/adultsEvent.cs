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
    public partial class adultsEvent : Form
    {
        adultEvent ad = new adultEvent();
        public adultsEvent()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ad.NameOfShow = this.textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ad.IdOfShow = this.textBox2.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(textBox4.Text!="")
                    ad.MinAge = int.Parse(this.textBox4.Text);
            }
            catch
            {
                this.textBox4.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                    ad.LengthOfShow = int.Parse(this.textBox3.Text);
            }
            catch
            {
                this.textBox3.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                    ad.PriceOfShow = int.Parse(this.textBox5.Text);
            }
            catch
            {
                this.textBox5.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
        }
      
        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l5 = new Label();
        Label l4 = new Label();
       
        private void button2_Click_1(object sender, EventArgs e)
        {
            ad.reset();
            this.textBox1.Text = null;
            this.textBox2.Text = null;
            this.textBox3.Text = null;
            this.textBox4.Text = null;
            this.textBox5.Text = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {

                l1.Text = "Required field!";
                l1.Location = new Point(345,104);
                this.Controls.Add(l1);
            }
            else
                l1.Text = "";
            if (this.textBox2.Text == "")
            {

                l2.Text = "Required field!";
                l2.Location = new Point(345, 144);
                this.Controls.Add(l2);
            }
            else
                l2.Text = "";
            if (this.textBox3.Text == "")
            {

                l3.Text = "Required field!";
                l3.Location = new Point(345, 184);
                this.Controls.Add(l3);
            }
            else
                l3.Text = "";
            if (this.textBox4.Text == "")
            {

                l4.Text = "Required field!";
                l4.Location = new Point(345, 224);
                this.Controls.Add(l4);
            }
            else
                l4.Text = "";
            if (this.textBox5.Text == "")
            {

                l5.Text = "Required field!";
                l5.Location = new Point(345, 264);
                this.Controls.Add(l5);
            }
            else
                l5.Text = "";
            if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text != "" && this.textBox4.Text != "" && this.textBox5.Text != "")
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Details saved successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)

                    this.Close();
            }
            Program.lAEvent.Add(ad);
            DataRow row = DAL.data.Tables["adultEvent"].NewRow();
            row[0] = ad.IdOfShow;
            row[1] = ad.NameOfShow;
            row[2] = ad.MinAge;
            row[3] = ad.LengthOfShow;
            row[4] = ad.PriceOfShow;
            DAL.data.Tables["adultEvent"].Rows.Add(row);
        }
    }
}
