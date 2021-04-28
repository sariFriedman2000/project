using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projectEndOfSimester
{
    class Program:Form
    {
        public static List<manager> lManager = new List<manager>();
        public static List<presentation> lPR = new List<presentation>();
        public static List<showHall> lSHall = new List<showHall>();
        public static List<adultEvent> lAEvent = new List<adultEvent>();
        public static List<businessCustomers> lBCastumer = new List<businessCustomers>();
        public static List<childrenShow> lcShow = new List<childrenShow>();
        public static List<worker> lWorker = new List<worker>();
        public static List<privateCustomers> lPC = new List<privateCustomers>();
        static void Main(string[] args)
        { 
            mainForm main = new mainForm();
            Application.Run(main);


        }

        




















        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(292, 261);
            this.Name = "Program";
            this.Load += new System.EventHandler(this.Program_Load);
            this.ResumeLayout(false);

        }

        private void Program_Load(object sender, EventArgs e)
        {

        }
    }
}
