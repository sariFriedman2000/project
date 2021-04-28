using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectEndOfSimester
{
    class childrenShow : show
    {
        int maxAge;
        public childrenShow()
        {

        }
        public childrenShow(string id, string name, int minAge, int maxAge,  int lengthOfShow, int priceOfShow) : base(id, name, minAge, lengthOfShow, priceOfShow)
        {
            this.MaxAge = maxAge;
        }

        public int MaxAge { get => maxAge; set => maxAge = value; }
        public void reset1()
        {
            this.maxAge = 0;
        }
    }
}