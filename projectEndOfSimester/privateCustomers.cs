using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectEndOfSimester
{
    class privateCustomers:customer, Idiscount
    {
        string customersId;
        public privateCustomers()
        {
          
        }
        public privateCustomers(string customersId, string name,int num):base (name ,num)
        {
            this.CustomersId = customersId;
        }

        public string CustomersId { get => customersId; set => customersId = value; }
        public void reset()
        {
            base.reset();
            this.customersId = null;
        }

        public double calculation(int num, string id)
        {
            int numOfT = 0;
            for (int i = 0; i < Program.lPC.Count; i++)
            {
                if (Program.lPC[i].CustomersId.Equals(this.CustomersId))
                    numOfT = Program.lPC[i].NumOfTicket;
            }
            string idOfShow = "";
            double price = 0;
            for (int i = 0; i < Program.lPR.Count; i++)
            {
                if (Program.lPR[i].PresentationId.Equals(id))
                    idOfShow = Program.lPR[i].ShowId;
            }
            for (int i = 0; i < Program.lAEvent.Count; i++)
            {
                if (Program.lAEvent[i].IdOfShow.Equals(idOfShow))
                    price = Program.lAEvent[i].PriceOfShow;
            }
            if (price == 0)
                for (int i = 0; i < Program.lcShow.Count; i++)
                {
                    if (Program.lcShow[i].IdOfShow.Equals(idOfShow))
                        price = Program.lcShow[i].PriceOfShow;
                }
            double sum = num * price;
            double precent = 0;
            for (int i = 10; i <= numOfT && precent <= 50; i += 10)
            {
                precent += 5;
            }
            double temp = precent / 100 * sum;
            return sum - temp;
        }

    }
}
