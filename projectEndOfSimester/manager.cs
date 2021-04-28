using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectEndOfSimester
{
    class manager:ICalculation
    {
        string nameManager;
        string idManager;
        int numOfSaleTicketOfWorkers;
        double priceOfHour;
        public manager()
        {
          

        }
        public string NameManager { get => nameManager; set => nameManager = value; }
        public string IdManager { get => idManager; set => idManager = value; }
        public int NumOfSaleTicketOfWorkers { get => numOfSaleTicketOfWorkers; set => numOfSaleTicketOfWorkers = value; }
        public double PriceOfHour { get => priceOfHour; set => priceOfHour = value; }

        public manager(string id, string name, int numOfSale, double price)
        {
            this.nameManager = name;
            this.idManager = id;
            this.numOfSaleTicketOfWorkers = numOfSale;
            this.priceOfHour = price;
        }

        public double calculationOfSalary(string id, int sumOfHours)
        {
            double result = 0;
            for (int i = 0; i < Program.lManager.Count; i++)
            {
                if (Program.lManager[i].IdManager.Equals(id))
                {                  
                    result = sumOfHours * Program.lManager[i].priceOfHour+ Program.lManager[i].NumOfSaleTicketOfWorkers;
                    if (numOfSaleTicketOfWorkers > 1000)
                        result += 100;
                    return result;
                }
            }
            return -1;
        }
        public void reset()
        {
            this.nameManager = null;
            this.IdManager = null;
            this.numOfSaleTicketOfWorkers = 0;
            this.PriceOfHour = 0;
        }
    }
}
