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
    public partial class newWorker : Form
    {
        worker wr = new worker();
        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l5 = new Label();
        Label l4 = new Label();
        

        public newWorker()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sende, EventArgs e)
        {
            wr.NameWorker = this.textBox1.Text;
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                    wr.NumOfSaleTicket = int.Parse(this.textBox3.Text);
            }
            catch
            {
                this.textBox3.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }          
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            wr.IdWorker = this.textBox2.Text;
        }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            wr.MangerIdOFWorker = this.textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                    wr.PriceOfHour = double.Parse(this.textBox5.Text);
            }
            catch
            {
                this.textBox5.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wr.reset();
            this.textBox1.Text = null;
            this.textBox2.Text = null;
            this.textBox3.Text = null;
            this.textBox4.Text = null;
            this.textBox5.Text=null ;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            for (int i = 0; i < Program.lManager.Count && !flag; i++)
            {
                if (Program.lManager[i].IdManager.Equals(textBox4.Text))
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                wr.MangerIdOFWorker = "";
                textBox4.Text = "";
                MessageBox.Show("Incorrect ID!");
            }

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
            if (this.textBox3.Text == "")
            {

                l3.Text = "Required field!";
                l3.Location = new Point(440, 220);
                this.Controls.Add(l3);
            }
            else
                l3.Text = "";
            if (this.textBox4.Text == "")
            {

                l4.Text = "Required field!";
                l4.Location = new Point(440, 255);
                this.Controls.Add(l4);
            }
            else
                l4.Text = "";
            if (this.textBox5.Text == "")
            {

                l5.Text = "Required field!";
                l5.Location = new Point(440, 285);
                this.Controls.Add(l5);
            }
            else
                l5.Text = "";
           
            for (int i = 0; i <Program.lManager.Count; i++)
            {
                if (Program.lManager[i].IdManager.Equals(wr.MangerIdOFWorker))
                {
                    Program.lManager[i].NumOfSaleTicketOfWorkers += wr.NumOfSaleTicket;
                    int x = int.Parse(DAL.data.Tables["manger"].Rows[i][2].ToString());
                    x+= wr.NumOfSaleTicket;
                    DAL.data.Tables["manger"].Rows[i][2] = x;
                }
            }

            if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text != "" && this.textBox4.Text != "" && this.textBox5.Text != "")
            { 
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Details saved successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                    this.Close();
                Program.lWorker.Add(wr);
                DataRow row = DAL.data.Tables["worker"].NewRow();
                row[0] = wr.IdWorker;
                row[1] = wr.NameWorker;
                row[2] = wr.NumOfSaleTicket;
                row[3] = wr.MangerIdOFWorker;
                row[4] = wr.PriceOfHour;
                DAL.data.Tables["worker"].Rows.Add(row);
            }


        }

        private void newWorker_Load(object sender, EventArgs e)
        {

        }
    }
}
