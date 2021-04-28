using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectEndOfSimester
{
    class presentation
    {
        string presentationId;
        string showId;
        string hallId;
        DateTime dt;
        int freePlaces;
        

        public presentation()
        {

        }
        public DateTime DateTime()
        {
            Console.WriteLine("Enter a date and time for show, please:");
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            return new DateTime(year, month, day, hour, minute, 0);
        }
        public presentation(string presentationId, string showId, string hallId, DateTime dt, int freePlaces)
        {
            this.presentationId = presentationId;
            this.showId = showId;
            this.hallId = hallId;
            this.dt = dt;
            this.FreePlaces = freePlaces;
        }

        public string PresentationId { get => presentationId; set => presentationId = value; }
        public string ShowId { get => showId; set => showId = value; }
        public string HallId { get => hallId; set => hallId = value; }
        public DateTime Dt { get => dt; set => dt = value; }
        public int FreePlaces { get => freePlaces; set => freePlaces = value; }

        public void reset()
        {
            this.PresentationId = "";
            this.ShowId = "";
            this.HallId = "";
            this.Dt = default;
            this.freePlaces = 0;
        }
    }

    
}
