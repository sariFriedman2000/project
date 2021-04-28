using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace projectEndOfSimester
{
    class DAL
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-H96SLJD;Initial Catalog=culturalCenter;Integrated Security=True");
        string query1 = "select * from adultEvent";
        string query2 = "select * from businessCustomer";
        string query3 = "select * from childrenShow";
        string query4 = "select * from manger";
        string query5 = "select * from presentation";
        string query6 = "select * from showHall";
        string query7 = "select * from privateCustomers";
        string query8 = "select * from worker";
        
        public static DataSet data = new DataSet("culturalCenter");

        public static SqlDataAdapter table1;
        public static SqlDataAdapter table2;
        public static SqlDataAdapter table3;
        public static SqlDataAdapter table4;
        public static SqlDataAdapter table5;
        public static SqlDataAdapter table6;
        public static SqlDataAdapter table7;
        public static SqlDataAdapter table8;
        
        public void updateDataBase()
        { 
            table1.Update(data, "adultEvent");
            table2.Update(data, "businessCustomer");
            table3.Update(data, "childrenShow");
            table4.Update(data, "manger");
            table5.Update(data, "presentation");
            table6.Update(data, "showHall");
            table7.Update(data, "privateCustomers");
            table8.Update(data, "worker");
            for (int i = 0; i < data.Tables.Count; i++)
            {
                data.Tables[i].AcceptChanges();
            }  
        }

        public void connectionToDataBase()
        {
            table1 = new SqlDataAdapter(query1, connection);
            table1.Fill(data, "adultEvent");
            DataRowCollection temp = data.Tables[0].Rows;
            SqlCommandBuilder b1 = new SqlCommandBuilder(table1);
            
            for (int i = 0; i < temp.Count; i++)
            {
                Program.lAEvent.Add(new adultEvent(temp[i][0].ToString().Trim(), temp[i][1].ToString().Trim(), (int)temp[i][2], (int)temp[i][3], (int)temp[i][4]));
            }

            table2 = new SqlDataAdapter(query2, connection);
            table2.Fill(data, "businessCustomer");
            temp = data.Tables[1].Rows;
            SqlCommandBuilder b2 = new SqlCommandBuilder(table2); 
            for (int i = 0; i < temp.Count; i++)
            {
                Program.lBCastumer.Add(new businessCustomers(temp[i][0].ToString().Trim(), temp[i][1].ToString().Trim(), (int)temp[i][2]));
            }

            table3 = new SqlDataAdapter(query3, connection);
            table3.Fill(data, "childrenShow");
            temp = data.Tables[2].Rows;
            SqlCommandBuilder b3 = new SqlCommandBuilder(table3);
            for (int i = 0; i < temp.Count; i++)
            {
                Program.lcShow.Add(new childrenShow(temp[i][0].ToString().Trim(), temp[i][1].ToString().Trim(), (int)temp[i][2], (int)temp[i][3], (int)temp[i][4], (int)temp[i][5]));
            }

            table4 = new SqlDataAdapter(query4, connection);
            table4.Fill(data, "manger");
            temp = data.Tables[3].Rows;
            SqlCommandBuilder b4 = new SqlCommandBuilder(table4);
            for (int i = 0; i < temp.Count; i++)
            {
                Program.lManager.Add(new manager(temp[i][0].ToString().Trim(), temp[i][1].ToString().Trim(), (int)temp[i][2], (double)(int)temp[i][3]));
            }

            table5 = new SqlDataAdapter(query5, connection);
            table5.Fill(data, "presentation");
            temp = data.Tables[4].Rows;
            SqlCommandBuilder b5 = new SqlCommandBuilder(table5);
            for (int i = 0; i < temp.Count; i++)
            {
                Program.lPR.Add(new presentation(temp[i][0].ToString().Trim(), temp[i][1].ToString().Trim(), temp[i][2].ToString().Trim(), (DateTime)temp[i][3], (int)temp[i][4]));
            }


            table6 = new SqlDataAdapter(query6, connection);
            table6.Fill(data, "showHall");
            temp = data.Tables[5].Rows;
            SqlCommandBuilder b6 = new SqlCommandBuilder(table6);
            for (int i = 0; i < temp.Count; i++)
            {
                Program.lSHall.Add(new showHall(temp[i][0].ToString().Trim(), (int)temp[i][1]));
            }

            table7 = new SqlDataAdapter(query7, connection);
            table7.Fill(data, "privateCustomers");
            temp = data.Tables[6].Rows;
            SqlCommandBuilder b7 = new SqlCommandBuilder(table7);
            for (int i = 0; i < temp.Count; i++)
            {
                Program.lPC.Add(new privateCustomers(temp[i][0].ToString().Trim(), temp[i][1].ToString().Trim(), (int)temp[i][2]));
            }

            table8 = new SqlDataAdapter(query8, connection);
            table8.Fill(data, "worker");
            temp = data.Tables[7].Rows;
            SqlCommandBuilder b8 = new SqlCommandBuilder(table8);
            for (int i = 0; i < temp.Count; i++)
            {
                Program.lWorker.Add(new worker(temp[i][0].ToString().Trim(), temp[i][1].ToString().Trim(), (int)temp[i][2], temp[i][3].ToString().Trim(), (double)(int)temp[i][4]));
            }
        }
    }
}
