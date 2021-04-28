using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectEndOfSimester
{
    class show
    {
        string nameOfShow;
        string idOfShow;
        int minAge;
        int lengthOfShow;
        int priceOfShow;

        public show()
        {

        }
        public show(string nameOfShow, string idOfShow, int minAge, int lengthOfShow, int priceOfShow)
        {
            this.NameOfShow = nameOfShow;
            this.IdOfShow = idOfShow;
            this.MinAge = minAge;
            this.LengthOfShow = lengthOfShow;
            this.PriceOfShow = priceOfShow;
        }

        public string NameOfShow { get => nameOfShow; set => nameOfShow = value; }
        public string IdOfShow { get => idOfShow; set => idOfShow = value; }
        public int MinAge { get => minAge; set => minAge = value; }
        public int LengthOfShow { get => lengthOfShow; set => lengthOfShow = value; }
        public int PriceOfShow { get => priceOfShow; set => priceOfShow = value; }
        public void reset()
        {
            this.NameOfShow = null;
            this.IdOfShow = null;
            this.MinAge = 0;
            this.LengthOfShow = 0;
            this.PriceOfShow = 0;

        }


    }
}
