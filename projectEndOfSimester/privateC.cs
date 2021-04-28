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
    public partial class privateC : Form
    {
        privateCustomers pc = new privateCustomers();
        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l4 = new Label();
        string idS = "";
        public privateC()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pc.CustomersId = this.textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pc.NameCustomers= this.textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                    pc.NumOfTicket = int.Parse(this.textBox3.Text);
            }
            catch
            {
                this.textBox3.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double result = pc.calculation(pc.NumOfTicket, idS);
            MessageBox.Show(string.Format("Total cost of tickets after discount is {0}", result));
        }
            
           
        private void button2_Click(object sender, EventArgs e)
        {
            pc.reset();
            this.textBox1.Text = null;
            this.textBox2.Text = null;
            this.textBox3.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            if (this.textBox1.Text == "")
            {

                l1.Text = "Required field!";
                l1.Location = new Point(382, 122);
                this.Controls.Add(l1);
            }
            else
                l1.Text = "";
            if (this.textBox2.Text == "")
            {

                l2.Text = "Required field!";
                l2.Location = new Point(382, 170);
                this.Controls.Add(l2);
            }
            else
                l2.Text = "";
            if (this.textBox3.Text == "")
            {

                l3.Text = "Required field!";
                l3.Location = new Point(382, 217);
                this.Controls.Add(l3);
            }
            else
                l3.Text = "";
            if (this.textBox4.Text == "")
            {

                l4.Text = "Required field!";
                l4.Location = new Point(382, 263);
                this.Controls.Add(l4);
            }
            else
                l4.Text = "";
            if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.textBox3.Text != "" && textBox4.Text != "")
            {
                Boolean flag1 = false;
                for (int i = 0; i < Program.lPR.Count; i++)
                {
                    if (Program.lPR[i].PresentationId.Equals(idS))
                        flag1 = true;
                }
                if (!flag1)
                {
                    textBox4.Text = "";
                    MessageBox.Show("Incorrect ID");
                }
                else
                {
                    for (int i = 0; i < Program.lPC.Count && !flag; i++)
                    {
                        if (Program.lPC[i].CustomersId.Equals(pc.CustomersId))
                        {
                            Program.lPC[i].NumOfTicket += int.Parse(textBox3.Text);
                            int x = int.Parse(DAL.data.Tables["privateCustomers"].Rows[i][2].ToString());
                            x += pc.NumOfTicket;
                            DAL.data.Tables["privateCustomers"].Rows[i][2] = x;
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        Program.lPC.Add(pc);
                        DataRow row = DAL.data.Tables["privateCustomers"].NewRow();
                        row[0] = pc.CustomersId;
                        row[1] = pc.NameCustomers;
                        row[2] = pc.NumOfTicket;
                        DAL.data.Tables["privateCustomers"].Rows.Add(row);
                    }
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Details saved successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                        this.Close();
                }        
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            idS = textBox4.Text;
        }
    }
}
