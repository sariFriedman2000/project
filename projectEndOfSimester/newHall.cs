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
    public partial class newHall : Form
    {
        showHall hall = new showHall();
        Label l1 = new Label();
        Label l2 = new Label();
        public newHall()
        {
            InitializeComponent();
        }
       
            

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            hall.HallId = textBox1.Text;
        }

        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                    hall.NumOfPlaces = int.Parse(textBox2.Text);
            }
            catch
            {
                this.textBox2.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                l1.Text = "Required field!";
                l1.Location = new Point(355, 140);
                this.Controls.Add(l1);
            }
            else
                l1.Text = "";

            if (textBox2.Text == "")
            {
                l2.Text = "Required field!";
                l2.Location = new Point(355, 200);
                this.Controls.Add(l2);
            }
            else
                l2.Text = "";

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                DialogResult d = new DialogResult();
                d = MessageBox.Show("Details saved successfully!");
                if (d == DialogResult.OK)
                {
                    this.Close();
                }
                Program.lSHall.Add(hall);
                DataRow row = DAL.data.Tables["showHall"].NewRow();
                row[0] = hall.HallId;
                row[1] = hall.NumOfPlaces;
                DAL.data.Tables["showHall"].Rows.Add(row);
            
        }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hall.reset();
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
