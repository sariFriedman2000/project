using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectEndOfSimester
{
    class worker:ICalculation
    {
        string nameWorker;
        string idWorker;
        int numOfSaleTicket;
        string mangerIdOFWorker;
        double priceOfHour;
        
        public worker()
        {

        }
        public worker(string idWorker, string nameWorker, int numOfSaleTicket, string mangerIdOFWorker, double priceOfHour)
        {
            this.NameWorker = nameWorker;
            this.IdWorker = idWorker;
            this.NumOfSaleTicket = numOfSaleTicket;
            this.MangerIdOFWorker = mangerIdOFWorker;
            this.PriceOfHour = priceOfHour;
        }

        public string NameWorker { get => nameWorker; set => nameWorker = value; }
        public string IdWorker { get => idWorker; set => idWorker = value; }
        public int NumOfSaleTicket { get => numOfSaleTicket; set => numOfSaleTicket = value; }
        public string MangerIdOFWorker { get => mangerIdOFWorker; set => mangerIdOFWorker = value; }
        public double PriceOfHour { get => priceOfHour; set => priceOfHour = value; }

        public void reset()
        {
            this.NameWorker = null;
            this.IdWorker = null;
            this.NumOfSaleTicket = 0;
            this.MangerIdOFWorker = null;
            this.PriceOfHour = 0;
        }

        public double calculationOfSalary(string id, int sumOfHours)
        {
            for (int i = 0; i < Program.lWorker.Count; i++)
            {
                if(Program.lWorker[i].IdWorker.Equals(id))
                {
                    return Program.lWorker[i].priceOfHour * sumOfHours + Program.lWorker[i].numOfSaleTicket * 2;
                }
            }
            return -1;
        }
    }
}
