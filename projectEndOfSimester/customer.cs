using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectEndOfSimester
{
    class customer
    {
        string nameCustomers;
        int numOfTicket;

        public customer()
        {
           
        }
        public customer(string nameCustomers, int numOfTicket)
        {
            this.NameCustomers = nameCustomers;
            this.NumOfTicket = numOfTicket;
        }

        public string NameCustomers { get => nameCustomers; set => nameCustomers = value; }
        public int NumOfTicket { get => numOfTicket; set => numOfTicket = value; }

        public void reset()
        {
           
            this.nameCustomers = null;
            this.numOfTicket = 0;
           
        }

    }
}
