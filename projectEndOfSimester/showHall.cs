using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectEndOfSimester
{
    class showHall
    {
        string hallId;
        int numOfPlaces;

        public showHall(string hallId, int numOfPlaces)
        {
            this.HallId = hallId;
            this.NumOfPlaces = numOfPlaces;
        }

        public showHall()
        {

        }

        public string HallId { get => hallId; set => hallId = value; }
        public int NumOfPlaces { get => numOfPlaces; set => numOfPlaces = value; }

        public void reset()
        {
            this.hallId = null;
            this.numOfPlaces = 0;
        }

    }
}
