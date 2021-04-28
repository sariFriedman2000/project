using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectEndOfSimester
{
    class businessCustomers : customer, Idiscount
    {
        string companyId;
        public businessCustomers()
        {
        }
        public double calculation(int num, string id)
        {
            int numOfT = 0;
            for (int i = 0; i < Program.lBCastumer.Count; i++)
            {
                if (Program.lBCastumer[i].CompanyId.Equals(this.CompanyId))
                    numOfT = Program.lBCastumer[i].NumOfTicket;
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
            if(price==0)
                for (int i = 0; i < Program.lcShow.Count; i++)
                {
                    if (Program.lcShow[i].IdOfShow.Equals(idOfShow))
                        price = Program.lcShow[i].PriceOfShow;
                }
            double sum = num * price;
            double precent = 0;
            for (int i = 100; i <= numOfT && precent <= 50; i+=100)
            {
                precent += 5;
            }
            double temp = precent / 100 * sum;
            return sum - temp;
        }


        public businessCustomers(string companyId, string name, int num):base(name, num)
        {
            this.CompanyId = companyId;
        }

        public string CompanyId { get => companyId; set => companyId = value; }

        public void reset()
        {
            base.reset();
            this.companyId = string.Empty;
        }
    }
}
