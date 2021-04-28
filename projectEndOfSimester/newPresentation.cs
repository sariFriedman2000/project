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
    public partial class newPresentation : Form
    {
        presentation p = new presentation();
        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l4 = new Label();
        Label l5 = new Label();
        int hour, minute, year = DateTime.Now.Year, month = DateTime.Now.Month, day = DateTime.Now.Day;
        DateTime date;
        public newPresentation()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = this.comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox3.Text = this.comboBox2.Text;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.p.reset();
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.dateTimePicker1.Value = DateTime.Now;

        }

        private void button2_Click(object sender, EventArgs e)
       {
            int length = 0, lenthOfSomeShow = 0;
            Boolean degel = true;
            p.Dt = new DateTime(year, month, day, hour, minute, 0);
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            if (textBox1.Text == "")
            {
                l1.Text = "Required field!";
                l1.Location = new Point(630, 195);
                this.Controls.Add(l1);
            }
            else
                l1.Text = "";

            if (textBox2.Text == "")
            {
                l2.Text = "Required field!";
                l2.Location = new Point(630, 230);
                this.Controls.Add(l2);
            }
            else
                l2.Text = "";

            if (textBox3.Text == "")
            {
                l3.Text = "Required field!";
                l3.Location = new Point(630, 265);
                this.Controls.Add(l3);
            }
            else
                l3.Text = "";
            if (textBox4.Text == "")
            {
                l4.Text = "Required field!";
                l4.Location = new Point(630, 335);
                this.Controls.Add(l4);
            }
            else
                l4.Text = "";

            if (textBox5.Text == "")
            {
                l5.Text = "Required field!";
                l5.Location = new Point(630, 335);
                this.Controls.Add(l5);
            }
            else
                l5.Text = "";
            for (int i = 0; i < Program.lAEvent.Count; i++)
            {
                if (p.ShowId.Equals(Program.lAEvent[i].IdOfShow))
                    length = Program.lAEvent[i].LengthOfShow;

            }
            if(length==0)
            {
                for (int i = 0; i < Program.lcShow.Count; i++)
                {
                    if (p.ShowId.Equals(Program.lcShow[i].IdOfShow))
                        length = Program.lcShow[i].LengthOfShow;
                }
            }

            for (int i = 0; i < Program.lPR.Count; i++)
            {
                if (Program.lPR[i].HallId.Equals(p.HallId) && Program.lPR[i].Dt.Year==year && Program.lPR[i].Dt.Month==month && Program.lPR[i].Dt.Day==day)//Program.lPR[i].Dt.Date.Equals(date)
                {
                    for (int j = 0; j < Program.lAEvent.Count; j++)
                    {
                        if (Program.lAEvent[j].IdOfShow.Equals(Program.lPR[i].ShowId))
                        {
                            lenthOfSomeShow = Program.lAEvent[j].LengthOfShow;
                            break;
                        }
                    }
                    if(lenthOfSomeShow==0)
                        for (int j = 0; j < Program.lcShow.Count; j++)
                        {
                            if (Program.lcShow[j].IdOfShow.Equals(Program.lPR[i].ShowId))
                                lenthOfSomeShow = Program.lcShow[j].LengthOfShow;
                        }
                    if (hour * 60 + minute <= Program.lPR[i].Dt.Hour * 60 + Program.lPR[i].Dt.Minute && Program.lPR[i].Dt.Hour * 60 + Program.lPR[i].Dt.Minute <= hour * 60 + minute + length || Program.lPR[i].Dt.Hour * 60 + Program.lPR[i].Dt.Minute <= hour * 60 + minute && hour * 60 + minute <= Program.lPR[i].Dt.Hour * 60 + Program.lPR[i].Dt.Minute + lenthOfSomeShow)
                    {
                        MessageBox.Show("The hall is taken yet!");
                        degel = false;
                    }
                }
            }
            if(degel)
            {
                Boolean flag = false, flag2 = false;
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    for (int i = 0; i < comboBox1.Items.Count && !flag; i++)
                    {
                        if (textBox2.Text.Equals(comboBox1.Items[i]))
                            flag = true;
                    }
                    for (int i = 0; i < comboBox2.Items.Count && !flag2; i++)
                    {
                        if (textBox3.Text.Equals(comboBox2.Items[i]))
                            flag2 = true;
                    }
                    if (flag && flag2)
                    {
                        DialogResult d = new DialogResult();
                        d = MessageBox.Show("Details saved successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (d == DialogResult.OK)
                            this.Close();
                        Program.lPR.Add(p);
                        DataRow row = DAL.data.Tables["presentation"].NewRow();
                        row[0] = p.PresentationId;
                        row[1] = p.ShowId;
                        row[2] =p.HallId;
                        row[3] = p.Dt;
                        row[4] = p.FreePlaces;
                        DAL.data.Tables["presentation"].Rows.Add(row);
                    }
                    else
                    {
                        DialogResult d = new DialogResult();
                        d = MessageBox.Show("Incorrect Details!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            p.PresentationId = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            p.ShowId = textBox2.Text;
        }

        private void newPresentation_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.lSHall.Count; i++)
            {
                this.comboBox2.Items.Add(Program.lSHall[i].HallId);
            }
            for (int i = 0; i < Program.lcShow.Count; i++)
            {
                this.comboBox1.Items.Add(Program.lcShow[i].IdOfShow);
            }
            for (int i = 0; i < Program.lAEvent.Count; i++)
            {
                this.comboBox1.Items.Add(Program.lAEvent[i].IdOfShow);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            p.HallId = textBox3.Text;
            for (int i = 0; i < Program.lSHall.Count; i++)
            {
                if(Program.lSHall[i].HallId.Equals(p.HallId))
                    p.FreePlaces= Program.lSHall[i].NumOfPlaces;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            year = dateTimePicker1.Value.Year;
            month = dateTimePicker1.Value.Month;
            day = dateTimePicker1.Value.Day;
            date = new DateTime(year, month, day);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hour = int.Parse(this.textBox4.Text);
            }
            catch
            {
                if (this.textBox4.Text != "")
                {
                    MessageBox.Show("Digit only");
                }
            }
            if (textBox4.Text != "")
            {
                if (hour < 0 || hour > 24)
                {
                    textBox4.Text = "";
                    MessageBox.Show("Incorrect time");
                }
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                minute = int.Parse(this.textBox5.Text);
            }
            catch (FormatException)
            {
                if (this.textBox5.Text != "")
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Digit only");
                }
            }
            if (textBox5.Text != "")
            {
                if (minute < 0 || minute > 60)
                {
                    textBox5.Text = "";
                    MessageBox.Show("Incorrect time");
                }
            }
        }

        
    }
}
