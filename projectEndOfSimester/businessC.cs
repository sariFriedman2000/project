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
    public partial class businessC : Form
    {
        businessCustomers bc = new businessCustomers();
        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l4 = new Label();
        string idS = "";
        public businessC()
        {
            InitializeComponent();
        }

        private void businessC_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bc.CompanyId = this.textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bc.NameCustomers = this.textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                    bc.NumOfTicket = int.Parse(this.textBox3.Text);
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
            idS = textBox4.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double result = bc.calculation(bc.NumOfTicket, idS);
            MessageBox.Show(string.Format("Total cost of tickets after discount is {0}", result));
        }

        private void button3_Click(object sender, EventArgs e)
        
        {
            Boolean flag = false;
            if (this.textBox1.Text == "")
            {
                l1.Text = "Required field!";
                l1.Location = new Point(373, 105);
                this.Controls.Add(l1);
            }
            else
                l1.Text = "";
            if (this.textBox2.Text == "")
            {
                l2.Text = "Required field!";
                l2.Location = new Point(373, 155);
                this.Controls.Add(l2);
            }
            else
                l2.Text = "";
            if (this.textBox3.Text == "")
            {
                l3.Text = "Required field!";
                l3.Location = new Point(373, 207);
                this.Controls.Add(l3);
            }
            else
                l3.Text = "";
            if (this.textBox4.Text == "")
            {
                l4.Text = "Required field!";
                l4.Location = new Point(373, 255);
                this.Controls.Add(l4);
            }
            else
                l4.Text = "";

       
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text!="")
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
                    for (int i = 0; i < Program.lBCastumer.Count && !flag; i++)
                    {
                        if (Program.lBCastumer[i].CompanyId.Equals(bc.CompanyId))
                        {
                            Program.lBCastumer[i].NumOfTicket += int.Parse(textBox3.Text);
                            int x = int.Parse(DAL.data.Tables["businessCustomer"].Rows[i][2].ToString());
                            x += bc.NumOfTicket;
                            DAL.data.Tables["businessCustomer"].Rows[i][2] = x;
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        Program.lBCastumer.Add(bc);
                        DataRow row = DAL.data.Tables["businessCustomer"].NewRow();
                        row[0] = bc.CompanyId;
                        row[1] = bc.NameCustomers;
                        row[2] = bc.NumOfTicket;
                        DAL.data.Tables["businessCustomer"].Rows.Add(row);
                    }
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Details saved successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                        this.Close();
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.bc.reset();
            this.textBox1.Text = null;
            this.textBox2.Text = null;
            this.textBox3.Text = null;
        }

        
    }
}
