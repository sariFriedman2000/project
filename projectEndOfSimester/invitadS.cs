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
    public partial class invitadS : Form
    {
        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l4 = new Label();
        Label l5 = new Label();
        Label l6 = new Label();
        string idcustomer="";
        string idp="";
        DateTime time = new DateTime(2021, 03, 10);
        int age = 0;
        int numberOfTickets = 0;
        string idWorker = "";
        public invitadS()
        {
            InitializeComponent();
        }

        private void invitadS_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.lBCastumer.Count; i++)
            {
                this.comboBox1.Items.Add(Program.lBCastumer[i].CompanyId);
            }
            for (int i = 0; i < Program.lPC.Count; i++)
            {
                this.comboBox1.Items.Add(Program.lPC[i].CustomersId);
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idcustomer = comboBox1.SelectedItem.ToString();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            idp = comboBox2.SelectedItem.ToString();
            string show="";
            string id = comboBox2.SelectedItem.ToString();
            for (int i = 0; i < Program.lPR.Count; i++)
            {
                if (Program.lPR[i].PresentationId.Equals(id))
                    show = Program.lPR[i].ShowId;
            }
            for (int i = 0; i < Program.lPR.Count; i++)
            {
                if (Program.lPR[i].ShowId.Equals(show))
                    comboBox3.Items.Add(Program.lPR[i].Dt);
                
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            time = (DateTime)comboBox3.SelectedItem;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                    this.age = int.Parse(this.textBox1.Text);
            }
            catch
            {
                this.textBox1.Text = string.Empty;
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("The value must be numeric!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                     numberOfTickets = int.Parse(this.textBox2.Text);
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this.textBox1.Text == "")
            {

                l1.Text = "Required field!";
                l1.Location = new Point(310, 140);
                this.Controls.Add(l1);
            }
            else
                l1.Text = "";
            if (this.textBox2.Text == "")
            {

                l2.Text = "Required field!";
                l2.Location = new Point(310, 200);
                this.Controls.Add(l2);
            }
            else
                l2.Text = "";
            if (this.textBox3.Text == "")
            {

                l3.Text = "Required field!";
                l3.Location = new Point(310, 270);
                this.Controls.Add(l3);
            }
            else
                l3.Text = "";

            if (this.comboBox1.Text == "") 
            {
                l4.Text = "Required field!";
                l4.Location = new Point(600, 150);
                this.Controls.Add(l4);
            }
            else
                l4.Text = "";
            if (this.comboBox2.Text=="")
            {
                l5.Text = "Required field!";
                l5.Location = new Point(475, 255);
                this.Controls.Add(l5);
            }
            else
                l5.Text = "";
            if (this.comboBox3.Text == "")
            {
                l6.Text = "Required field!";
                l6.Location = new Point(475, 150);
                this.Controls.Add(l6);
            }
            else
                l6.Text = "";
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != ""&&comboBox2.Text != ""&& comboBox3.Text != "")
            {
                for (int i = 0; i < Program.lPR.Count; i++)
                {
                    if (Program.lPR[i].PresentationId.Equals(idp))
                    {
                        if (Program.lPR[i].FreePlaces > numberOfTickets)
                        {
                            Program.lPR[i].FreePlaces -= numberOfTickets;
                            int x = int.Parse(DAL.data.Tables["presentation"].Rows[i][4].ToString());
                            x -= numberOfTickets;
                            DAL.data.Tables["presentation"].Rows[i][4] = x;
                            DialogResult d = new DialogResult();
                            d = MessageBox.Show("Your order has been successfully received!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (d == DialogResult.OK)
                                this.Close();
                        }
                        else
                            MessageBox.Show("There are not enough places available in the hall!");
                    }
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string idManager = "";
            idWorker = this.textBox3.Text;
            for (int i = 0; i < Program.lWorker.Count; i++)
            {
                if (Program.lWorker[i].IdWorker.Equals(idWorker))
                {
                    Program.lWorker[i].NumOfSaleTicket += numberOfTickets;
                    idManager = Program.lWorker[i].MangerIdOFWorker;
                    int x = int.Parse(DAL.data.Tables["worker"].Rows[i][2].ToString());
                    x += numberOfTickets;
                    DAL.data.Tables["worker"].Rows[i][2] = x;
                }
            }
            for (int i = 0; i < Program.lManager.Count; i++)
            {
                if (Program.lManager[i].Equals(idManager))
                    Program.lManager[i].NumOfSaleTicketOfWorkers += numberOfTickets;
                int x = int.Parse(DAL.data.Tables["manger"].Rows[i][2].ToString());
                x += numberOfTickets;
                DAL.data.Tables["manger"].Rows[i][2] = x;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.lcShow.Count; i++)
            {
                if (Program.lcShow[i].MinAge <= age && Program.lcShow[i].MaxAge >= age)
                    for (int j = 0; j < Program.lPR.Count; j++)
                    {
                        if (Program.lPR[j].ShowId == Program.lcShow[i].IdOfShow)
                            comboBox2.Items.Add(Program.lPR[j].PresentationId);
                    }
            }
            for (int i = 0; i < Program.lAEvent.Count; i++)
            {
                if (Program.lAEvent[i].MinAge <= age)
                    for (int j = 0; j < Program.lPR.Count; j++)
                    {
                        if (Program.lPR[j].ShowId == Program.lAEvent[i].IdOfShow)
                            comboBox2.Items.Add(Program.lPR[j].PresentationId);
                    }
            }
        }
    }
}
